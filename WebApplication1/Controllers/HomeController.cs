using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Database;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidaLogin(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var usuario = LoginDB.ValidarLogin(login.Usuario, login.Senha);

            var usuarioDoBanco = LoginDB.ValidarLogin(login.Usuario, login.Senha);

            if (usuarioDoBanco != null)
            {
                var usuarioSessao = new Login
                {
                    Usuario = usuarioDoBanco.USR_EML,
                    Role = usuarioDoBanco.Role,
                    Nome = usuarioDoBanco.Nome,
                    USR_AIC = usuarioDoBanco.USR_AIC 
                };

                Session["BAALOG"] = usuarioSessao;
                
                if (usuarioSessao.Role == "Admin")
                {
                    return RedirectToAction("Index", "DashBoard");
                }
                else
                {
                    return RedirectToAction("Index2", "UserDashBoard");
                }
            }
            ModelState.AddModelError("", "Usuário ou senha inválidos.");
            return View("Login", usuario);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
    }
}