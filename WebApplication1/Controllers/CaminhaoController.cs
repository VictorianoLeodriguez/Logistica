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
        // GET: Caminhao/Cadastro
        [HttpGet]
        public ActionResult Cadastro()
        {
            if (Session["BAALOG"] == null) // Garante que só usuário logado veja
                return RedirectToAction("Login", "Home");

            return View();
        }

        // POST: Caminhao/Cadastro
        [HttpPost]
        public ActionResult Cadastro(Caminhao caminhao)
        {
            if (Session["BAALOG"] == null)
                return RedirectToAction("Login", "Home");

            var usuario = Session["BAALOG"] as WebApplication1.Models.Login;
            caminhao.USR_AIC = usuario.USR_AIC;

            bool sucesso = CaminhaoDB.Adicionar(caminhao); // Usa MySQL

            if (sucesso)
                ViewBag.Message = "Caminhão cadastrado com sucesso!";
            else
                ViewBag.Message = "Erro ao cadastrar caminhão.";

            return View();
        }

        // GET: Caminhao/Lista
        public ActionResult Lista()
        {
            if (Session["BAALOG"] == null)
                return RedirectToAction("Login", "Home");

            var lista = CaminhaoDB.Listar(); // Pega todos os caminhões
            return View(lista);
        }

        // GET: Caminhao/Excluir/5
        public ActionResult Excluir(int id)
        {
            if (Session["BAALOG"] == null)
                return RedirectToAction("Login", "Home");

            CaminhaoDB.Excluir(id);
            return RedirectToAction("Lista");
        }
    }
}
