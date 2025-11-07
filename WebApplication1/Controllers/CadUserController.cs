using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CadUserController : Controller
    {
        // GET: CadUser
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioDB.Adicionar(usuario);
                return RedirectToAction("Lista");
            }
            return View(usuario);
        }

        public ActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioDB.Editar(usuario);
                return RedirectToAction("Lista");
            }
            return View(usuario);
        }

        public ActionResult Excluir(int id)
        {
            UsuarioDB.Excluir(id);
            return RedirectToAction("Lista");
        }

        public ActionResult Lista()
        {
            var user = new Usuario();

            var lista = UsuarioDB.Lista(user);
            
            return View(lista);
        }
    }
}