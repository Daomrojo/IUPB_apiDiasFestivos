using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apidiasfestivos.core.repositorios;
using apidiasfestivos.dominio;
using apidiasfestivos.infraestructura.Persistencia;

namespace apidiasfestivos.infraestructura.Repositorios
{
    public class FestivoRepositorio : IFestivoRepositorio
    {
        private readonly DiasFestivosContext contexto;

        public FestivoRepositorio(DiasFestivosContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Festivo> Agregar(Festivo Festivo)
        {
            contexto.Festivos.Add(Festivo);
            await contexto.SaveChangesAsync();
            return contexto.Festivos.FirstOrDefault(festivo => festivo.Id == Festivo.Id);
        }

        public async Task<IEnumerable<Festivo>> Buscar(int IndiceDato, string Texto)
        {
            return await contexto.Festivos
                .Where(festivo => IndiceDato == 1 && festivo.Nombre.Contains(Texto))
                .Include(festivo => festivo.Pais)
                .Include(festivo => festivo.TipoFestivo)
                .OrderBy(festivo => festivo.Nombre)
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var FestivoExistente = await contexto.Festivos.FindAsync(Id);
            if (FestivoExistente == null)
            {
                return false;
            }
            try
            {
               
                contexto.Festivos.Remove(FestivoExistente);
               
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Festivo> Modificar(Festivo Festivo)
        {
            
            var FestivoExistente = await contexto.Festivos.FindAsync(Festivo.Id);
            if (FestivoExistente == null)
            {
                return null;
            }
            
            contexto.Entry(FestivoExistente).CurrentValues.SetValues(Festivo);
            
            await contexto.SaveChangesAsync();

          
            return contexto.Festivos.FirstOrDefault(festivo => festivo.Id == Festivo.Id);
        }

        public async Task<Festivo> Obtener(int Id)
        {
            return await contexto.Festivos
                .Include(festivo => festivo.Pais)
                .Include(festivo => festivo.TipoFestivo)
                .FirstOrDefaultAsync(festivo => festivo.Id == Id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerPorPais(int IdPais)
        {
            return await contexto.Festivos
                .Where(festivo => festivo.IdPais == IdPais)
                .Include(festivo => festivo.Pais)
                .Include(festivo => festivo.TipoFestivo)
                .OrderBy(festivo => festivo.Nombre)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Festivo>> ObtenerPorTipo(int IdTipo)
        {
            return await contexto.Festivos
                .Where(festivo => festivo.IdTipo == IdTipo)
                .Include(festivo => festivo.Pais)
                .Include(festivo => festivo.TipoFestivo)
                .OrderBy(festivo => festivo.Nombre)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await contexto.Festivos
                .Include(festivo => festivo.Pais)
                .Include(festivo => festivo.TipoFestivo)
                .OrderBy(festivo => festivo.Nombre)
                .ToArrayAsync();
        }
    }
}
