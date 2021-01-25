using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Repositories
{
    public class RepositoryHospital
    {
        //clase encargada de realizar las consulta a bbdd mediante linq to ef 
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        //metodo para devolver los hospitales
        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }


    }
}
