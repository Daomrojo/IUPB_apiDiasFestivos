using System.Collections.Generic;
using System.Threading.Tasks;
using apidiasfestivos.dominio;

namespace apidiasfestivos.core.servicios
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<IEnumerable<Festivo>> ObtenerPorPais(int IdPais);

        Task<Festivo> Obtener(int Id);

        Task<IEnumerable<Festivo>> Buscar(int IndiceDato, string Texto);

        Task<Festivo> Agregar(Festivo Festivo);

        Task<Festivo> Modificar(Festivo Festivo);

        Task<bool> Eliminar(int Id);

        // Métodos requeridos por la prueba de negocio
        Task<bool> EsFestivo(int IdPais, int Anio, int Mes, int Dia);

        Task<IEnumerable<Festivo>> ObtenerFestivosPorAnio(int IdPais, int Anio);
    }
}
