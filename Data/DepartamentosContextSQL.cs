using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MVCEntityFramework.Data
{
    public class DepartamentosContextSQL : IDepartamentosContext
    {
        private SqlDataAdapter adapter;
        private DataTable tabladept;

        public DepartamentosContextSQL(String cadena)
        {
            //String cadena = @"Data Source=LAPTOP-KR2NL673\SQLAURORAMASTER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2020";
            this.adapter = new SqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.tabladept = new DataTable();
            this.adapter.Fill(this.tabladept);
        }
        public List<Departamento> GetDepartamentos()
        {
            //select con linq 
            var consulta = from datos in this.tabladept.AsEnumerable()
                            select datos;
            List<Departamento> departamentos = new List<Departamento>();
            //recorremos todos los datos de la consulta y extraemos cada dept.
            foreach(var dato in consulta)
            {
                //creamos un obj dept por cada vuelta
                Departamento departamento = new Departamento();
                departamento.Numero = dato.Field<int>("DEPT_NO");
                departamento.Nombre = dato.Field<String>("DNOMBRE");
                departamento.Localidad = dato.Field<String>("LOC");
                departamentos.Add(departamento);
            }
            return departamentos;
        }
    }
}
