using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EntregaUserController : Controller
    {
        
        public ActionResult AtualizarStatus(int id, string status)
        {
            var usuario = Session["BAALOG"] as WebApplication1.Models.Login;
            if (usuario == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var entrega = EntregaUserDB.Lista().FirstOrDefault(e => e.Codigo == id);
            if (entrega != null)
            {
                entrega.Status_ETG = status;

                var ok = EntregaUserDB.AtualizarStatus(entrega, id);

                TempData["Msg"] = ok ? "Status atualizado com sucesso!" : "Falha ao atualizar status.";
            }

            return RedirectToAction("MinhasEntregas");
        }

        public ActionResult MinhasEntregas()
        {
            var usuario = Session["BAALOG"] as WebApplication1.Models.Login;
            if (usuario == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var lista = EntregaUserDB.Lista() ?? new List<EntregaUser>();

            var entregasDoUsuario = lista.Where(e => e.USR_AIC == usuario.USR_AIC).ToList();

            ViewBag.Pendentes = entregasDoUsuario
                .Where(e => e.Status_ETG == "Pendente" || e.Status_ETG == "Em Rota" || e.Status_ETG == "Aguardando Retirada")
                .ToList();

            ViewBag.Concluidas = entregasDoUsuario
                .Where(e => e.Status_ETG == "Entregue" || e.Status_ETG == "Cancelado" || e.Status_ETG == "Devolvido" || e.Status_ETG == "Retirado")
                .ToList();

            return View();
        }
    }
}
