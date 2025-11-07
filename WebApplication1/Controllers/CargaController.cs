using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class CargaController : Controller
    {
        // GET: Carga
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Carga carga, int id = -1)
        {
            if (id < 0)
            {

                CargaDB.Adicionar(carga);
            }
            else
            {

                CargaDB.Editar(carga, id);
                return RedirectToAction("Lista");
            }
            return View(carga);
        }

        public ActionResult Excluir(int id)
        {
            CargaDB.Excluir(id);
            return RedirectToAction("Lista");
        }

        public ActionResult Lista()
        {
            var carga = new Carga();

            var lista = CargaDB.Lista(carga);

            return View(lista);
        }
    }
}