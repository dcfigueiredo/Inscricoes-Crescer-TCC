using InscricoesCrescer.Dominio;
using InscricoesCrescer.Models;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;
using InscricoesCrescer.Infraestrutura;
using System.Collections.Generic;
using InscricoesCrescer.Infraestrutura.Service;

namespace InscricoesCrescer.Controllers
{
    public class HomeController : Controller
    {

        CandidatoServico candidatoServico = ServicoDeDependencia.MontarCandidatoServico();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmaCadastro(string id)
        {
            List<CandidatoEntidade> candidatos = candidatoServico.BuscarTodos();
            ServicoCriptografia cripto = new ServicoCriptografia();
            foreach (var item in candidatos)
            {
                string emailCriptografado = cripto.Criptografar(item.Email);
                if (emailCriptografado.Equals(id))
                {
                    CandidatoEntidade candidato = candidatoServico.BuscarPorEmail(item.Email);
                    candidato.Status = "Interesse";
                    candidatoServico.Salvar(candidato);
                    TempData["cadastradoComSucesso"] = "Email Confirmado!";
                    return View();
                }
            }
            TempData["cadastradoInvalido"] = "Não foi possivel confirmar seu e-mail, " +
                                             "Certifique-se que seu email esta correto.";
            return View("Index");
            
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
                    if (servico.enviarEmailConfirmacao(model.Email))
                    {
                        TempData["cadastradoComSucesso"] = "* Cadastrado com sucesso!";

                        TempData["msg"] = "Confirme seu e-mail.";
                    } else
                    {
                        ModelState.AddModelError("", "Ocorreu algum erro.");
                    }
                }
            }else
            {
                ModelState.AddModelError("", "Ocorreu algum erro.");
            }
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
            candidato.Status = "Inicial";
            return candidato;
        }
        /*
         * //http://www.dotnetawesome.com/2015/12/google-new-recaptcha-using-aspnet-mvc.html
        [HttpPost]
        public ActionResult FormSubmit()
        {
            //Validate Google recaptcha here
            var response = Request["g-recaptcha-response"];
            string secretKey = "Your secret here";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";

            //When you will post form for save data, you should check both the model validation and google recaptcha validation
            //EX.
            /* if (ModelState.IsValid && status)
            {

            }

            //Here I am returning to Index page for demo perpose, you can use your view here
            return View("Index");
        }*/

    }
}