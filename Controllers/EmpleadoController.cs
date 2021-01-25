using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Models;
using MVCEntityFramework.Repositories;

namespace MVCEntityFramework.Controllers
{
    public class EmpleadoController : Controller
    {
        private RepositoryEmpleado repo;

        public EmpleadoController(RepositoryEmpleado repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return View(empleados);
        }

        public IActionResult IncrementarSalario()
        {
            List<String> oficios = this.repo.GetOficios();
            ViewBag.Oficios = oficios;
            return View();
        }

        [HttpPost]
        public IActionResult IncrementarSalario(int incremento, Empleado empleado)
        {
            this.repo.ModificarSalario(incremento, empleado.Oficio);
            List<Empleado> empleados = this.repo.GetEmpleadosOficio(empleado.Oficio);
            return RedirectToAction("Index");
        }

        public IActionResult GetEmpleadosModificados(String oficio)
        {
            List<Empleado> empleados = this.repo.GetEmpleadosOficio(oficio);
            return View(empleados);
        }

        public IActionResult EmpleadosDepartamentoLambda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmpleadosDepartamentoLambda(int departamento)
        {
            ResumenDepartamento model = this.repo.GetEmpleadosDepartamento(departamento);
            return View(model);
        }
    }
}
