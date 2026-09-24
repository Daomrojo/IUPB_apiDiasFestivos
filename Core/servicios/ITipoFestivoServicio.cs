using System.Collections.Generic;
using System.Threading.Tasks;
using apidiasfestivos.dominio;

namespace apidiasfestivos.core.servicios
{
    public interface ITipoFestivoServicio
    {
        Task<IEnumerable<TipoFestivo>> ObtenerTodos();

        Task<TipoFestivo> Obtener(int Id);

        Task<IEnumerable<TipoFestivo>> Buscar(int IndiceDato, string Texto);

        Task<TipoFestivo> Agregar(TipoFestivo TipoFestivo);

        Task<TipoFestivo> Modificar(TipoFestivo TipoFestivo);

        Task<bool> Eliminar(int Id);
    }
}