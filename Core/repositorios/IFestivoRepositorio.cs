using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apidiasfestivos.dominio;

namespace apidiasfestivos.core.repositorios
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<IEnumerable<Festivo>> ObtenerPorPais(int IdPais);

        Task<IEnumerable<Festivo>> ObtenerPorTipo(int IdTipo);

        Task<Festivo> Obtener(int Id);

        Task<IEnumerable<Festivo>> Buscar(int IndiceDato, string Texto);

        Task<Festivo> Agregar(Festivo Festivo);

        Task<Festivo> Modificar(Festivo Festivo);

        Task<bool> Eliminar(int Id);
    }
}
