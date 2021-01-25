using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Models;
using MVCEntityFramework.Repositories;

namespace MVCEntityFramework.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repo;

        public EnfermosController(RepositoryEnfermos repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Enfermo> enfermos = this.repo.GetEnfermos();
            return View(enfermos);
        }

        public IActionResult Details(int idinscripcion)
        {
            Enfermo enfermo = this.repo.BuscarEnfermo(idinscripcion);
            return View(enfermo);
        }

        public IActionResult EnfermosGenero(String genero)
        {
            //debemos enviar dos característica
            //enviamos los generos 
            //al recibir un genero enviamos los enfermos: 
            List<Genero> generos = this.repo.GetGeneros();
            ViewBag.Generos = generos;
            if (genero !=null)
            {
                List<Enfermo> enfermos = this.repo.GetEnfermosGenero(genero);
                return View(enfermos);
            }
            else
            {
                return View();
            }
         
        }

        public IActionResult EliminarEnfermo(int inscripcion)
        {
            this.repo.EliminarEnfermo(inscripcion);
            return RedirectToAction("Index");
        }


        public IActionResult InsertarEnfermo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertarEnfermo(int inscripcion, String apellido, String direccion,
            DateTime fechanac, String genero, String nss)
        {
            this.repo.InsertarEnfermo(inscripcion, apellido, direccion,
            fechanac, genero, nss);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEnfermo(int inscripcion)
        {
            Enfermo enfermo = this.repo.BuscarEnfermo(inscripcion);
            return View(enfermo);
        }

        [HttpPost]
        public IActionResult UpdateEnfermo(Enfermo enfermo)
        {
            this.repo.MoficiarEnfermo(enfermo.Inscripcion, enfermo.Apellido,
                enfermo.Direccion, enfermo.FechaNacimiento, enfermo.Sexo, enfermo.Seguridad);
            return RedirectToAction("Index");
        }
    }
}
