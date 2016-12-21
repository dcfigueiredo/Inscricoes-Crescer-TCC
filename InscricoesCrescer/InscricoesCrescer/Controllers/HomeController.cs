using InscricoesCrescer.Models;
using System.Web.Mvc;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;
using InscricoesCrescer.Infraestrutura;
using System.Collections.Generic;
using InscricoesCrescer.Infraestrutura.Service;
using System;

namespace InscricoesCrescer.Controllers
{
    public class HomeController : Controller
    {

        CandidatoServico candidatoServico = ServicoDeDependencia.MontarCandidatoServico();
        ServicoConfiguracao servicoConfiguracao = new ServicoConfiguracao();

        public ActionResult Index()
        {
            TempData["captcha"] = servicoConfiguracao.Captcha;
            return View();
        }

        //------------------------------- Acessado pelo Administrativo --------------------------
        public PartialViewResult EditarCandidato(string id)
        {
            CandidatoEntidade candidato = candidatoServico.BuscarCandidatoPorID(Convert.ToInt64(id));
            CandidatoParaReCadastroModel model = ConverteCandidatoParaModel(candidato);
            return PartialView("SegundaEtapaCadastroCandidato", model);
        }

        public ActionResult SalvarCandidatoEditado(CandidatoParaReCadastroModel model)
        {
            ServicoEmail servico = new ServicoEmail();
            if (servico.ValidaEmail(model.Email))
            {
                CandidatoEntidade candidato = candidatoServico.BuscarPorEmail(model.Email);
                candidato = converterCandidatoSegundaEtapa(model);
                candidatoServico.Salvar(candidato);

                TempData["cadastradoComSucesso"] = "* Cadastrado com sucesso!";
                return RedirectToAction("Index", "Administrativo");
            }
            else
            {
                @TempData["cadastradoInvalido"] = "E-mail invalido!";
                return View("SegundaEtapaCadastroCandidato", model);
            }
        }

        //------------------------------------Segunda Etapa cadastro --------------------------------------

        public ActionResult SegundaEtapaCadastroCandidato(string id)
        {
            List<CandidatoEntidade> candidatos = candidatoServico.BuscarTodos();
            ServicoCriptografia servicoCriptografia = new ServicoCriptografia();
            //TO-DO: Refatorar essa parte, é responsabilidade do serviço fazer essa buscar e comparação.
            foreach (CandidatoEntidade item in candidatos)
            {
                string emailCriptografado = servicoCriptografia.Criptografar(item.Email);
                if (emailCriptografado.Equals(id))
                {
                    CandidatoParaReCadastroModel model = ConverteCandidatoParaModel(item);
                    return View("SegundaEtapaCadastroCandidato", model);
                }
            }
            TempData["cadastradoInvalido"] = "Não foi possivel confirmar seu e-mail, " + "\n" +
                                             "Certifique-se que seu email esta Cadastrado ou entre em contato conosco.";
            return View("ConfirmaCadastro");
        }

        public ActionResult SalvarSegundoCadastro(CandidatoParaReCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                if (Session == null)
                {
                    if (model.Senha.Equals(model.ConfirmaSenha))
                    {
                        ServicoEmail servico = new ServicoEmail();
                        if (servico.ValidaEmail(model.Email))
                        {
                            CandidatoEntidade candidato = candidatoServico.BuscarPorEmail(model.Email);
                            if (!candidato.Status.Equals("Aguardando Contato"))
                            {
                                candidato = converterCandidatoSegundaEtapa(model);
                                candidatoServico.Salvar(candidato);
                                TempData["cadastradoComSucesso"] = "* Parabéns, você foi cadastrado com sucesso, aguarde próximo contato.";
                                return View("ConfirmaCadastro");
                            }
                            @TempData["cadastradoInvalido"] = "Você já possui Cadastro!";
                            return View("SegundaEtapaCadastroCandidato");
                        }
                    }
                }
                else
                {
                    return RedirectToAction("SalvarCandidatoEditado", model);
                }

            }
            ModelState.AddModelError("", "Não foi possivel completar cadastro! " + "\n" +
                                    "verifique se todos os dados foram digitados corretamente.");
            return View("SegundaEtapaCadastroCandidato", model);
        }

        // ----------------------------------Primeiro Cadastro---------------------------------------------

        public ActionResult ConfirmaCadastro(string id)
        {
            List<CandidatoEntidade> candidatos = candidatoServico.BuscarTodos();
            ServicoCriptografia servicoCriptografia = new ServicoCriptografia();
            //TO-DO: Refatorar essa parte, é responsabilidade do serviço fazer essa buscar e comparação.
            foreach (var item in candidatos)
            {
                string emailCriptografado = servicoCriptografia.Criptografar(item.Email);
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
                    CandidatoEntidade candidato = candidatoServico.BuscarPorEmail(model.Email);
                    if (candidato != null)
                    {
                        TempData["cadastradoJaExiste"] = "* Você já possui cadastro, Aguarde contato.";
                        return View("Index");
                    }
                    candidato = converterCandidato(model);
                    candidatoServico.Salvar(candidato);
                    if (servico.enviarEmailConfirmacao(model.Email))
                    {
                        TempData["cadastradoComSucesso"] = "* Cadastrado com sucesso, E-mail de confirmação Enviado!";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ocorreu algum erro. Por favor tente novamente mais tarde.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "E-mail inválido! verifique se foi digitado corretamente.");
            }
            return View("Index");
        }

        
        // -------------------------------- métodos Privados -----------------------------------
        private CandidatoEntidade converterCandidatoSegundaEtapa(CandidatoParaReCadastroModel model)
        {
            CandidatoEntidade candidato = new CandidatoEntidade();
            ServicoCriptografia servicoCriptografia = new ServicoCriptografia();
            candidato.Id = model.Id;
            candidato.Nome = model.Nome;
            candidato.Email = model.Email;
            candidato.Telefone = model.Telefone;
            candidato.DataNascimento = model.DataNascimento;
            candidato.Cidade = model.Cidade;
            candidato.Curso = model.Curso;
            candidato.Instituicao = model.Instituicao;
            candidato.Conclusao = model.Conclusao;
            candidato.Linkedin = model.Linkedin;
            candidato.Senha = servicoCriptografia.Criptografar(model.Senha);
            if(model.ConfirmaSenha == null)
            {
                candidato.Status = model.Status;
            }
            else
            {
                candidato.Status = "Aguardando Contato";
            }
            return candidato;
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

        private CandidatoParaReCadastroModel ConverteCandidatoParaModel(CandidatoEntidade candidato)
        {
            CandidatoParaReCadastroModel model = new CandidatoParaReCadastroModel();
            model.Id = candidato.Id;
            model.Nome = candidato.Nome;
            model.Email = candidato.Email;
            model.Telefone = candidato.Telefone;
            model.Cidade = candidato.Cidade;
            model.DataNascimento = Convert.ToDateTime(candidato.DataNascimento);
            model.Instituicao = candidato.Instituicao;
            model.Curso = candidato.Curso;
            model.Conclusao = candidato.Conclusao;
            model.Linkedin = candidato.Linkedin;
            model.Senha = candidato.Senha;
            model.Status = candidato.Status;
            return model;
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