using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Database
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

            if (usuario != null)
            {
                Session["BAALOG"] = usuario;
                return RedirectToAction("Index", "DashBoard");
            }

                return View("Login", usuario);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Home");
        }
    }
}