using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Repositories
{
    public class RepositoryDoctores
    {
        HospitalContext context;
        public RepositoryDoctores(HospitalContext context)
        {
            this.context = context;
        }
        public void UpdateEspecialidad(int iddoctor, String espe)
        {
            this.context.ModificarEspecialidad(iddoctor, espe);
        }

        public List<Doctor> GetDoctores()
        {
            //en este caso no tiene parámetros pero la consulta es igual con param
            String sql = "mostrardoctores";
            //la consulta se ejecuta a partir de un dbset de coleccion
            //y auto mapeara los campos de lso datos
            //que devuelva el procedure
            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql).ToList();
            return doctores;
        }

        public List<Doctor> GetDoctoresEspecialidad(String especialidad)
        {
            String sql = "DOCTORESESPECIALIDAD @especialidad";
            SqlParameter pamespe = new SqlParameter("@especialidad", especialidad);
            List<Doctor> doctores = this.context.Doctores.FromSqlRaw(sql, especialidad).ToList();
            return doctores;
        }

        public void UpdateSalario(String especialidad, int incremento)
        {
            String sql = "UPDATESALARIODOCTOR @especialidad, @incremento";
            SqlParameter pamespe = new SqlParameter("@especialidad", especialidad);
            SqlParameter pamincre = new SqlParameter("@salario",incremento);
            this.context.Database.ExecuteSqlRaw(sql,pamespe,pamincre);
        }

        public List<String> GetEspecialidades()
        {
            var consulta = (from datos in context.Doctores
                            select datos.Especialidad).Distinct();
            return consulta.ToList();
        }

        public List<String> GetEspecilidadesProcedimiento()
        {
            using (DbCommand com = this.context.Database.GetDbConnection().CreateCommand())
            {
                String sql = "GETESPECIALIDADES";
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = sql;
                com.Connection.Open();
                DbDataReader reader = com.ExecuteReader();
                List<string> esps = new List<string>();
                while (reader.Read())
                {
                    esps.Add(reader["ESPECIALIDADES"].ToString());
                }
                reader.Close();
                com.Connection.Close();
                return esps;
            }
        }
    }
}
