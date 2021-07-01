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
            if (userModel == null)
            {
                return RedirectToAction("Logar");
            }
            bool autenticado = IsUserAuthenticated(userModel);


            if (ModelState.IsValid != true)
            {
                return View();
            }

            if ((IsUserAuthenticated(userModel) != true) || String.IsNullOrEmpty(userModel.UserName) || String.IsNullOrEmpty(userModel.UserName))
            {
                ModelState.AddModelError(string.Empty, "Usuario invalido");
                return View();
            }

            ReadLoginDAL readLoginDAL = new ReadLoginDAL();

            UserModel userModelUserPermissao = readLoginDAL.GetUser(userModel.UserName);
            return await AdicionarCookie(userModelUserPermissao);

        }

        public bool IsUserAuthenticated(UserModel userModel)
        {
            ReadLoginDAL readLoginDAL = new ReadLoginDAL();
            return readLoginDAL.VerificarSeExisteUsuarioNoBanco(userModel);
        }

        public async Task<IActionResult> Deslogar()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }


        public async Task<ActionResult> AdicionarCookie(UserModel userModel)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userModel.UserName),
                new Claim(ClaimTypes.Role, userModel.Permissao),
                new Claim(ClaimTypes.Name, userModel.UserName)
            };
            var userIdentity = new ClaimsIdentity(claims, "DefaultSchemeCookieCRUD");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            return Redirect("/Home/Index");

        }
    }
}
