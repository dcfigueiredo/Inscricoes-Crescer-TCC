using InscricoesCrescer.Dominio;
using InscricoesCrescer.Models;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;
using InscricoesCrescer.Infraestrutura;

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
                ServicoEmail servico = new ServicoEmail();
                if (servico.ValidaEmail(model.Email))
                {
                    CandidatoEntidade candidato = converterCandidato(model);
                    candidatoServico.Salvar(candidato);
                    servico.enviarEmailConfirmacao(model.Email);
                    TempData["cadastradoComSucesso"] = "* Cadastrado com sucesso!";
                }
            }
            ModelState.AddModelError("", "Ocorreu algum erro.");
            return View("Index");
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