using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.Controllers
{
    [Authorize]
    public class PrincipalController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
