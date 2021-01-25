using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFramework.Repositories
{
    public class RepositoryEnfermos
    {
        private EnfermosContext context;
        public RepositoryEnfermos(EnfermosContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.context.Enfermos
                           select datos;
            return consulta.ToList();
        }

        public Enfermo BuscarEnfermo(int inscripcion)
        {
            var consulta = from datos in this.context.Enfermos
                           where datos.Inscripcion == inscripcion
                           select datos;
            //si no existen daots simepre se devolverá null durante los repositorios
            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.First();
            }
        }

        public List<Genero> GetGeneros()
        {
            //se ponen parentesis a la consulta bc se le va a aplicar un método: 
            var consulta = (from datos in this.context.Enfermos
                            select datos.Sexo).Distinct();
            List<Genero> generos = new List<Genero>();
            foreach(String dato in consulta)
            {
                Genero gen = new Genero();
                gen.Value = dato;
                if(dato.ToLower() == "f")
                {
                    gen.Text = "FEMENINO";
                }
                else
                {
                    gen.Text = "MASCULINO";
                }
                generos.Add(gen);
            }
            return generos.ToList();
        }

        public List<Enfermo> GetEnfermosGenero(String genero)
        {
            var consulta = from datos in this.context.Enfermos
                           where datos.Sexo == genero
                           select datos;
            return consulta.ToList();
        }

        public void EliminarEnfermo(int inscripcion)
        {
            //necesitamos buscar la entidad a eliminar: 
            Enfermo enfermo = this.BuscarEnfermo(inscripcion);
            //eliminar el obj del context y su dbset
            this.context.Enfermos.Remove(enfermo);
            this.context.SaveChanges();
        }

        public void InsertarEnfermo(int inscripcion, String apellido, String direccion, 
            DateTime fechanac, String genero, String nss)
        {
            Enfermo enfermo = new Enfermo();
            enfermo.Inscripcion = inscripcion;
            enfermo.Apellido = apellido;
            enfermo.Direccion = direccion;
            enfermo.FechaNacimiento = fechanac;
            enfermo.Sexo = genero;
            enfermo.Seguridad = nss;
            this.context.Enfermos.Add(enfermo);
            this.context.SaveChanges();
        }

        public void MoficiarEnfermo(int inscripcion, String apellido, String direccion, DateTime fechanac,
            String genero, String nss)
        {
            Enfermo enfermo = this.BuscarEnfermo(inscripcion);
            enfermo.Inscripcion = inscripcion;
            enfermo.Apellido = apellido;
            enfermo.Direccion = direccion;
            enfermo.FechaNacimiento = fechanac;
            enfermo.Sexo = genero;
            enfermo.Seguridad = nss;
            //this.context.Update(enfermo);
            this.context.SaveChanges();
        }
    }
}
