using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Models;

namespace MVCEntityFramework.Controllers
{
    public class CocheController : Controller
    {
        private ICoche car;

        public CocheController(ICoche car)
        {
            this.car = car;
        }

        public IActionResult Index()
        {
            return View(this.car);
        }

        [HttpPost]
        public IActionResult Index(String accion)
        {
            if(accion.ToLower() == "acelerar")
            {
                this.car.Acelerar();
            }
            else
            {
                this.car.Frenar();
            }
            return View(this.car);
        }
    }
}
