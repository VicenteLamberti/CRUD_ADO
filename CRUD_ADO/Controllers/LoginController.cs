using CRUD_ADO.DAL.LoginDAL;
using CRUD_ADO.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRUD_ADO.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Logar()
        {
            return View();
        }


        [HttpPost, ActionName("Logar")]
        [HttpPost]
        public async Task<IActionResult> LogarEfetivamente(UserModel userModel)
        {

            var a = IsUserAuthenticated(userModel);


            if (ModelState.IsValid != true)
            {
                return View();
            }

            if ((IsUserAuthenticated(userModel) != true) || String.IsNullOrEmpty(userModel.UserName) || String.IsNullOrEmpty(userModel.UserName))
            {
                ModelState.AddModelError(string.Empty, "Usuario invalido");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userModel.UserName)
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            return Redirect("/");
        }

        public bool IsUserAuthenticated(UserModel userModel)
        {
            ReadLoginDAL readLoginDAL = new ReadLoginDAL();

            return readLoginDAL.VerificarSeExisteUsuarioNoBanco(userModel);
        }
    }
}
