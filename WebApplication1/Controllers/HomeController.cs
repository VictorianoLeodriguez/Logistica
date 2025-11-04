using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            //var usuario = UsuarioDB.ValidarLogin(model);

            //if (usuario != null)
            //{
            //    Session["UsuarioLogado"] = usuario;
            //    return RedirectToAction("Index", "Home");
            //}

            //ViewBag.Erro = "Login inválido";
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}