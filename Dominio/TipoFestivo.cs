using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidiasfestivos.dominio
{
    [Table("TipoFestivo")]
    public class TipoFestivo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        public required string Tipo { get; set; }
    }
}
