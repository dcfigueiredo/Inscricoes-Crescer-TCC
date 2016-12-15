using InscricoesCrescer.Dominio;
using InscricoesCrescer.Models;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;

namespace InscricoesCrescer.Controllers
{
    public class HomeController : Controller
    {

        CandidatoServico candidatoServico = ServicoDeDependencia.MontarCandidatoServico();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmaCadastro(string token)
        {
            // alterar aki status do candidato
            return View();
        }

        
        public ActionResult Salvar(CandidatoModel model)
        {
            if (ModelState.IsValid)
            {
                CandidatoEntidade candidato = converterCandidato(model);
                candidatoServico.Salvar(candidato);
            }
            return View("Index");
        }

        public static bool ValidaEnderecoEmail(string enderecoEmail)
        {
            Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

            if (expressaoRegex.IsMatch(enderecoEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private CandidatoEntidade converterCandidato(CandidatoModel model)
        {
            CandidatoEntidade candidato = new CandidatoEntidade();
            candidato.Nome = model.Nome;
            candidato.Email = model.Email;
            candidato.Curso = model.Curso;
            candidato.Instituicao = model.Instituicao;
            candidato.Conclusao = model.Conclusao;
            return candidato;
        }

    }
}