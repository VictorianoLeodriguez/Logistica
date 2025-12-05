using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Models;
using WebApplication1.Utils;


namespace WebApplication1.Controllers
{
    public class EntregaController : Controller
    {
       
        public ActionResult Cadastro()
        {
            var helper = new StatusHelper();
            var statusList = helper.ListarStatusEntrega();

            ViewBag.StatusEntrega = new SelectList(statusList, "Nome", "Nome");

            var entrega = new Entregas
            {
                Status_ETG = "Pendente" 

            return View(entrega);
        }

        [HttpPost]
        public ActionResult Cadastro(Entregas entrega, int id = -1)
        {
            entrega.Data_RG = DateTime.Now.Date;
            entrega.Hora_RG = DateTime.Now.TimeOfDay;

            if (string.IsNullOrEmpty(entrega.Status_ETG))
            {
                entrega.Status_ETG = "Pendente"; 
            }

            if (!ModelState.IsValid)
            {
                var helper = new StatusHelper();
                var statusList = helper.ListarStatusEntrega();
                ViewBag.StatusEntrega = new SelectList(statusList, "Nome", "Nome", entrega.Status_ETG);

                return View(entrega);
            }

            if (id < 0)
            {
                EntregaDB.Adicionar(entrega);
            }
            else
            {
                EntregaDB.Editar(entrega, id);
            }

            return RedirectToAction("Lista");
        }

        public ActionResult Excluir(int id)
        {
            EntregaDB.Excluir(id);
            return RedirectToAction("Lista");
        }

        public ActionResult Lista()
        {
            var lista = EntregaDB.Lista();

            var helper = new StatusHelper();
            var statusList = helper.ListarStatusEntrega();

            foreach (var entrega in lista)
            {
                ViewBag.StatusEntrega = new SelectList(helper.ListarStatusEntrega());
            }

            return View(lista);
        }
    }
}