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
        [HttpGet]
        public ActionResult Cadastro()
        {
            if (Session["BAALOG"] == null) 
                return RedirectToAction("Login", "Home");

            return View();
        }

        
        [HttpPost]
        public ActionResult Cadastro(Caminhao caminhao)
        {
            var usuario = Session["BAALOG"] as Login;
            if (usuario == null)
                return RedirectToAction("Login", "Home");

            bool sucesso = CaminhaoDB.Adicionar(caminhao);

            ViewBag.Message = sucesso ? "Caminhão cadastrado com sucesso!" : "Erro ao cadastrar caminhão.";
            return View();
        }

       
        public ActionResult Lista()
        {
            if (Session["BAALOG"] == null)
                return RedirectToAction("Login", "Home");

            var lista = CaminhaoDB.Listar();
            return View(lista);
        }

     
        public ActionResult Excluir(int id)
        {
            if (Session["BAALOG"] == null)
                return RedirectToAction("Login", "Home");

            CaminhaoDB.Excluir(id);
            return RedirectToAction("Lista");
        }
    }
}
