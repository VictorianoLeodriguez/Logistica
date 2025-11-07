using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CaminhaoController : Controller
    {
        // GET: Caminhao
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Caminhao caminhao, int id = -1)
        {

            if (id < 0)
            {

                CaminhaoDB.Adicionar(caminhao);
            }
            else
            {

                CaminhaoDB.Editar(caminhao, id);
                return RedirectToAction("Lista");
            }

            return View(caminhao);
        }

        public ActionResult Excluir(int id)
        {
            CaminhaoDB.Excluir(id);
            return RedirectToAction("Lista");
        }

        public ActionResult Lista()
        {
            var caminhao = new Caminhao();

            var lista = CaminhaoDB.Lista(caminhao);

            return View(lista);
        }
    }
}
