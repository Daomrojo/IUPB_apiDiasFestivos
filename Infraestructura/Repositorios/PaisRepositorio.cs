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
    public class PaisRepositorio : IPaisRepositorio
    {
        private readonly DiasFestivosContext contexto;

        public PaisRepositorio(DiasFestivosContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Pais> Agregar(Pais Pais)
        {
            
            contexto.Paises.Add(Pais);
         
            await contexto.SaveChangesAsync();
            
            return contexto.Paises.FirstOrDefault(pais => pais.Id == Pais.Id);
        }

        public async Task<IEnumerable<Pais>> Buscar(int IndiceDato, string Texto)
        {
            return await contexto.Paises
                .Where(pais => IndiceDato == 1 && pais.Nombre.Contains(Texto))
                .OrderBy(pais => pais.Nombre)
                .ToArrayAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var PaisExistente = await contexto.Paises.FindAsync(Id);
            if (PaisExistente == null)
            {
                return false;
            }
            try
            {
               
                contexto.Paises.Remove(PaisExistente);
            
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Pais> Modificar(Pais Pais)
        {
            
            var PaisExistente = await contexto.Paises.FindAsync(Pais.Id);
            if (PaisExistente == null)
            {
                return null;
            }
            
            contexto.Entry(PaisExistente).CurrentValues.SetValues(Pais);
           
            await contexto.SaveChangesAsync();

           
            return contexto.Paises.FirstOrDefault(pais => pais.Id == Pais.Id);
        }

        public async Task<Pais> Obtener(int Id)
        {
            return await contexto.Paises
                .FirstOrDefaultAsync(pais => pais.Id == Id);
        }

        public async Task<IEnumerable<Pais>> ObtenerTodos()
        {
            return await contexto.Paises
                .OrderBy(pais => pais.Nombre)
                .ToArrayAsync();
        }
    }
}
