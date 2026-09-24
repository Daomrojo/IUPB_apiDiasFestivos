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
    public class TipoFestivoRepositorio : ITipoFestivoRepositorio
    {
        private readonly DiasFestivosContext contexto;

        public TipoFestivoRepositorio(DiasFestivosContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<TipoFestivo> Agregar(TipoFestivo TipoFestivo)
        {
            
            contexto.TiposFestivos.Add(TipoFestivo);
            
            await contexto.SaveChangesAsync();
            
            return contexto.TiposFestivos.FirstOrDefault(tipoFestivo => tipoFestivo.Id == TipoFestivo.Id);
        }

        public async Task<IEnumerable<TipoFestivo>> Buscar(int IndiceDato, string Texto)
        {
            return await contexto.TiposFestivos
                .Where(tipoFestivo => IndiceDato == 1 && tipoFestivo.Tipo.Contains(Texto))
                .OrderBy(tipoFestivo => tipoFestivo.Tipo)
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var TipoFestivoExistente = await contexto.TiposFestivos.FindAsync(Id);
            if (TipoFestivoExistente == null)
            {
                return false;
            }
            try
            {
                
                contexto.TiposFestivos.Remove(TipoFestivoExistente);
                
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<TipoFestivo> Modificar(TipoFestivo TipoFestivo)
        {
            
            var TipoFestivoExistente = await contexto.TiposFestivos.FindAsync(TipoFestivo.Id);
            if (TipoFestivoExistente == null)
            {
                return null;
            }
            
            contexto.Entry(TipoFestivoExistente).CurrentValues.SetValues(TipoFestivo);
            
            await contexto.SaveChangesAsync();

            
            return contexto.TiposFestivos.FirstOrDefault(tipoFestivo => tipoFestivo.Id == TipoFestivo.Id);
        }

        public async Task<TipoFestivo> Obtener(int Id)
        {
            return await contexto.TiposFestivos
                .FirstOrDefaultAsync(tipoFestivo => tipoFestivo.Id == Id);
        }

        public async Task<IEnumerable<TipoFestivo>> ObtenerTodos()
        {
            return await contexto.TiposFestivos
                .OrderBy(tipoFestivo => tipoFestivo.Id)
                .ToArrayAsync();
        }
    }
}
