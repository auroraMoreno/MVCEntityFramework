using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEntityFramework.Data;
using MVCEntityFramework.Models;

namespace MVCEntityFramework.Controllers
{
    public class DepartamentosController : Controller
    {
        private IDepartamentosContext context;

        public DepartamentosController(IDepartamentosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Departamento> departamentos = this.context.GetDepartamentos();
            return View(departamentos);
        }
    }
}
