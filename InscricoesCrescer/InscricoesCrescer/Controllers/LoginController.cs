using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InscricoesCrescer.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FazerLogin(string email, string senha)
        {
            Usuario usuarioAutenticado = ServicoDeUsuario.BuscarUsuarioAutenticado(email, senha);

            /*redirecionar para a página “Inicial – Administrativo”, definida no item 3.4. */
            return RedirectToAction("Index","Home");
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FazerLogin(string usuario, string senha)
        {
            Usuario usuarioAutenticado = ServicoDeUsuario.BuscarUsuarioAutenticado(
                    usuario, senha);

            if (usuarioAutenticado != null)
            {
                ServicoDeAutenticacao.Autenticar(new UsuarioLogadoModel(
                    usuarioAutenticado.Nome, usuarioAutenticado.Permissoes));
                return RedirectToAction("Secreta");
            }

            return RedirectToAction("Index");
        }
        
        */


    }
}