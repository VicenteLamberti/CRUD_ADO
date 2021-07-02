using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.Controllers
{
    public class DocumentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
