using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidiasfestivos.dominio
{
    [Table("Pais")]
    public class Pais
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre")]
        public required string Nombre { get; set; }
    }
}
