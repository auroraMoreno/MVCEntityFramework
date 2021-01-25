using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Models
{
    [Table("PLANTILLA")]
    public class Plantilla
    {
        [Key]
        [Column("EMPLEADO_NO")]
        public int EmpleadoNo { get; set; }
        [Column("APELLIDO")]
        public String Apellido { get; set; }
        [Column("FUNCION")]
        public String Funcion { get; set; }
        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
