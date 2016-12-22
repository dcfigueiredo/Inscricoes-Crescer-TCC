using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Servico;
using System.Web.Mvc;

namespace InscricoesCrescer.Controllers
{
    public class LoginController : Controller
    {

        AdministradorServico administradorServico = ServicoDeDependencia.MontarAdministradorServico();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return View("Login");
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