using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Models;
using MVCEntityFramework.Repositories;

namespace MVCEntityFramework.Controllers
{
    public class EmpleadosHospitalController : Controller
    {
        RepositoryEmpleadosHospital repo;

        public EmpleadosHospitalController(RepositoryEmpleadosHospital repo)
        {
            this.repo = repo; 
        }

        public IActionResult Index()
        {
            List<EmpleadoHospital> empleados = this.repo.GetEmpleadoHospital();
            return View(empleados);
        }

        public IActionResult ProcedimientoEmpleadosHospital()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcedimientoEmpleadosHospital(int hospitalcod)
        {
            ProcedimientoEmpleadoHospital datos = 
                this.repo.GetEmpleadosHospital(hospitalcod);
            return View(datos);
        }
    }
}
