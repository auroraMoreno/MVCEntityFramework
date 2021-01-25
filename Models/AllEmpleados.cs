using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Models
{
    [Table("ALLEMPLEADOS")]
    public class AllEmpleados
    {
        public int IdEmpleado { get; set; }
        public String Apellido { get; set; }
        public String Oficio { get; set; }
        public int Salario { get; set; }
        public int DeptNo { get; set; }

    }
}
