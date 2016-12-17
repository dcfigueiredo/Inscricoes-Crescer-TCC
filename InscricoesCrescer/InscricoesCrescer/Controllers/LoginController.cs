using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InscricoesCrescer.Controllers
{
    public class LoginController : Controller
    {

        AdministradorServico administradorServico = ServicoDeDependencia.MontarAdministradorServico();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FazerLogin(string email, string senha)
        {
            AdministradorEntidade administradorAutenticado = administradorServico.BuscarPorAutenticacao(email, senha);

            if(administradorAutenticado != null)
            {
                ServicoDeAutenticacao.Autenticar(new Models.AdministradorModel(administradorAutenticado.Email));
                return RedirectToAction("Index", "Administrativo");
            }
            TempData["mensagemLogin"] = "Email ou senha inválidos!";
            return RedirectToAction("Login","Login");
        }
    }
}