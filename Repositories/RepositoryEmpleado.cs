using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Repositories
{
    public class RepositoryEmpleado
    {
        EmpleadoContext context;
        public RepositoryEmpleado(EmpleadoContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        public List<String> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            List<String> oficios = new List<String>();
            foreach (String dato in consulta)
            {
                oficios.Add(dato);
            }
            return oficios;
        }

        public List<Empleado> GetEmpleadosOficio(String oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }
        
        public void ModificarSalario(int incremento, String oficio)
        {
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);

            foreach(Empleado e in empleados)
            {
                e.Salario += incremento;
            }
            this.context.SaveChanges();
          
        }

        public ResumenDepartamento GetEmpleadosDepartamento(int deptno)
        {
            List<Empleado> empleados = this.GetEmpleados();
            List<Empleado> filtro = empleados.Where(x => x.Departamento == deptno).ToList();
            if(filtro.Count() == 0)
            {
                return null;
            }
            int personas = filtro.Count();
            int maximo = filtro.Max(x=>x.Salario);
            int minimo = filtro.Min(x=>x.Salario);
            ResumenDepartamento resumen = new ResumenDepartamento();
            resumen.Empleados = filtro;
            resumen.Personas = personas;
            resumen.MaximoSalario = maximo;
            resumen.MinimoSalario = minimo;
            return resumen;
        
        }


    }
}
