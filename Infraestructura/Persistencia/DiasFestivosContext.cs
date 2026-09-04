using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apidiasfestivos.dominio;

namespace apidiasfestivos.infraestructura.Persistencia
{
    public class DiasFestivosContext : DbContext
    {
        public DbSet<TipoFestivo> TiposFestivos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Festivo> Festivos { get; set; }

        protected override void OnModelCreating(ModelBuilder constructor)
        {
            //Definición de la entidad TipoFestivo (Clave Primaria e Índice Único)
            constructor.Entity<TipoFestivo>(entidadTipoFestivo =>
            {
                entidadTipoFestivo.HasKey(e => e.Id);
                entidadTipoFestivo.HasIndex(e => e.Tipo).IsUnique();
            });

            //Definición de la entidad Pais (Clave Primaria e Índice Único)
            constructor.Entity<Pais>(entidadPais =>
            {
                entidadPais.HasKey(e => e.Id);
                entidadPais.HasIndex(e => e.Nombre).IsUnique();
            });

            //Definición de la entidad Festivo (Clave Primaria)
            constructor.Entity<Festivo>(entidadFestivo =>
            {
                entidadFestivo.HasKey(e => e.Id);
            });

            // Clave foránea: Relación entre Festivo y Pais (un festivo pertenece a un país)
            constructor.Entity<Festivo>()
                .HasOne(e => e.Pais)
                .WithMany()
                .HasForeignKey(e => e.IdPais);

            // Clave foránea: Relación entre Festivo y TipoFestivo (un festivo pertenece a un tipo de festivo)
            constructor.Entity<Festivo>()
                .HasOne(e => e.TipoFestivo)
                .WithMany()
                .HasForeignKey(e => e.IdTipo);
        }
    }
}
