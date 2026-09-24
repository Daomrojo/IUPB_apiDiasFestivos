using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apidiasfestivos.dominio;

namespace apidiasfestivos.core.repositorios
{
    public interface IPaisRepositorio
    {
        Task<IEnumerable<Pais>> ObtenerTodos();

        Task<Pais> Obtener(int Id);

        Task<IEnumerable<Pais>> Buscar(int IndiceDato, string Texto);

        Task<Pais> Agregar(Pais Pais);

        Task<Pais> Modificar(Pais Pais);

        Task<bool> Eliminar(int Id);
    }
}
