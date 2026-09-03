using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidiasfestivos.dominio
{
    [Table("Festivo")]
    public class Festivo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public required string Nombre { get; set; }

        [Column("Dia")]
        public int Dia { get; set; }

        [Column("Mes")]
        public int Mes { get; set; }

        [Column("DiasPascua")]
        public int DiasPascua { get; set; }

        [Column("IdPais")]
        public int IdPais { get; set; }

        public Pais? Pais { get; set; }

        [Column("IdTipo")]
        public int IdTipo { get; set; }

        public TipoFestivo? TipoFestivo { get; set; }
    }
}
