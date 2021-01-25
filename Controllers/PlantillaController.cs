using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Models;
using MVCEntityFramework.Repositories;

namespace MVCEntityFramework.Controllers
{
    public class PlantillaController : Controller
    {
        private RepositoryPlantilla repo;

        public PlantillaController(RepositoryPlantilla repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Plantilla> plantillas = this.repo.GetPlantilla();
            return View(plantillas);
        }

        public IActionResult GetResumenPlantilla()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetResumenPlantilla(int salario)
        {
            ResumenPlantilla model = this.repo.GetPlantillaSalario(salario);
            return View(model);
        }
    }
}
