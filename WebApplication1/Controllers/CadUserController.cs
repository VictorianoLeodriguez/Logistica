using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Models;
using WebApplication1.Service; 

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
        public ActionResult Cadastro(Usuario usuario, int id = -1)
        {
            // Validações antes de salvar
            if (!ValidadorUsuario.ValidarNome(usuario.Nome))
            {
                ModelState.AddModelError("Nome", "Nome inválido (máx. 50 caracteres).");
            }

            if (!ValidadorUsuario.ValidarCPF(usuario.CPF))
            {
                ModelState.AddModelError("CPF", "CPF inválido.");
            }

            if (!ValidadorUsuario.ValidarSenha(usuario.senha))
            {
                ModelState.AddModelError("Senha", "Senha inválida (máx. 8 caracteres, número e especial).");
            }

            // Se houver erros, volta para a View com mensagens
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            // Se passou nas validações, salva
            if (id < 0)
            {
                UsuarioDB.Adicionar(usuario);
            }
            else
            {
                UsuarioDB.Editar(usuario, id);
                return RedirectToAction("Lista");
            }

            return RedirectToAction("Lista");
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
