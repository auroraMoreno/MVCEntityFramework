using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Repositories
{
    public class RepositoryPlantilla
    {
        private HospitalContext context;

        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }

        public List<Plantilla> GetPlantilla()
        {
            var consulta = from datos in this.context.Plantillas
                           select datos;
            return consulta.ToList();

        }

        public ResumenPlantilla GetPlantillaSalario(int salario)
        {
            List<Plantilla> plantillas = this.GetPlantilla();
            List<Plantilla> filtro = plantillas.Where(x => x.Salario == salario).ToList();
            if (filtro.Count() == 0)
            {
                return null;
            }

            int personas = filtro.Count();
            int max = filtro.Max(x => x.Salario);
            int min = filtro.Min(x => x.Salario);
            ResumenPlantilla resumen = new ResumenPlantilla();
            resumen.Plantillas = filtro;
            resumen.Personas = personas;
            resumen.MaximoSalario = max;
            resumen.MinimoSalario = min;
            return resumen;
        }

    }
}
