using Microsoft.EntityFrameworkCore;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

#region
//CREATE PROCEDURE MOSTRARDOCTORES
//AS
//SELECT* FROM DOCTOR
//GO

//CREATE PROCEDURE CAMBIARESPECIALIDAD
//(@IDDOCTOR INT, @ESPECIALIDAD NVARCHAR(30))
//AS
//UPDATE DOCTOR SET ESPECIALIDAD = @ESPECIALIDAD
//WHERE DOCTOR_NO = @IDDOCTOR
//GO

#endregion

namespace MVCEntityFramework.Data
{
    public class HospitalContext : DbContext
    {
        //tendrá un ctor obligatorio con options para el context 
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {

        }

        //tendremos que mapear con DbSet cada entidad para que sea accesible 
        //deben de ser propiedades obligatoriamente no pueden ser campos 
        public DbSet<Hospital> Hospitales { get; set; }

        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Doctor> Doctores { get; set; }

        public DbSet<EmpleadoHospital> EmpleadosHospital { get; set; }
        public void ModificarEspecialidad(int iddoctor, String espe)
        {
            String sql = "cambiarespecialidad @iddoctor, @especialidad";
            //necesitamos parametros para enviar los datos al procedimiento
            SqlParameter pamid = new SqlParameter("@iddoctor", iddoctor);
            SqlParameter pamespe = new SqlParameter("@especialidad", espe);
            this.Database.ExecuteSqlRaw(sql, pamid, pamespe);
        }

        //public List<Doctor> DoctoresEspecialidad(String especialidad)
        //{
        //    String sql = "DOCTORESESPECIALIDAD";
        //    SqlParameter pamesp = new SqlParameter("@ESPECIALIDAD", especialidad);
        //    this.Database.ExecuteSqlRaw(sql, pamesp);

        //}
    }
}
