using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Models;
using MVCEntityFramework.Repositories;

namespace MVCEntityFramework.Controllers
{
    public class DoctorController : Controller
    {
        RepositoryDoctores repo;

        public DoctorController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateDoctoresEspecialidad()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult UpdateDoctoresEspecialidad(int iddoctor, String especialidad)
        {
            this.repo.UpdateEspecialidad(iddoctor,especialidad);
            List<Doctor> doctores = this.repo.GetDoctores();
            return View(doctores);
        }

        public IActionResult DoctoresEspecialidad()
        {
            //List<Doctor> especialidades = this.repo.GetEspecialidades();
            //ViewBag.Especialidades = especialidades;
            return View();
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(String especialidad)
        {
            List<Doctor> doctores = this.repo.GetDoctoresEspecialidad(especialidad);
            return View (doctores);
        }

    }
}
