using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DashBoardController : Controller

    {
        public ActionResult Index()
        {
            var usuario = (Login)Session["UsuarioLogado"];

            var model = new DashboardViewModel
            {
                Pendentes = CargaDB.ContarPendentes(),
                Entregues = CargaDB.ContarEntregues(),
                Nome = usuario != null ? usuario.Nome : "Visitante"
            };

            return View(model);
        }
    }

}
