﻿using InscricoesCrescer.Models;
using System.Web.Mvc;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;
using InscricoesCrescer.Infraestrutura;
using System.Collections.Generic;
using InscricoesCrescer.Infraestrutura.Service;
using System;
using Newtonsoft.Json.Linq;
using System.Net;

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
            return PartialView("_EditarCandidato", model);
        }

        public JsonResult SalvarCandidatoEditado(CandidatoParaReCadastroModel model)
        {
            ServicoEmail servico = new ServicoEmail();
            if (servico.ValidaEmail(model.Email))
            {
                CandidatoEntidade candidato = candidatoServico.BuscarPorEmail(model.Email);
                candidato = ConverterCandidatoSegundaEtapa(model, Convert.ToInt64(model.Id));
                candidatoServico.Salvar(candidato);
                //TempData["cadastradoComSucesso"] = "* Cadastrado com sucesso! *";
                return Json(new { Mensagem = "Edição realizada com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //@TempData["cadastradoInvalido"] = "E-mail invalido!";
                return Json(new { Mensagem = "E-mail invalido."}, JsonRequestBehavior.AllowGet);
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
            TempData["cadastradoInvalido"] = "Não foi possivel confirmar seu e-mail";
            TempData["subMensagem"] = "Certifique-se que seu email esta Cadastrado ou entre em contato conosco.";
            return View("ConfirmaCadastro");
        }

        public ActionResult SalvarSegundoCadastro(CandidatoParaReCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                if (Session["USUARIO_LOGADO_CHAVE"] == null)
                {
                    if (model.Senha.Equals(model.ConfirmaSenha))
                    {
                        ServicoEmail servico = new ServicoEmail();
                        if (servico.ValidaEmail(model.Email))
                        {
                            CandidatoEntidade candidato = candidatoServico.BuscarPorEmail(model.Email);
                            if (!candidato.Status.Equals("Aguardando Contato"))
                            {
                                candidato = ConverterCandidatoSegundaEtapa(model, Convert.ToInt64(candidato.Id));
                                candidatoServico.Salvar(candidato);
                                TempData["cadastradoComSucesso"] = "* Parabéns, você foi cadastrado com sucesso";
                                TempData["subMensagem"] = "aguarde próximo contato.";
                                return View("ConfirmaCadastro");
                            }
                            TempData["cadastradoInvalido"] = "Você já possui Cadastro!";
                            TempData["subMensagem"] = "aguarde o próximo contato.";
                            return View("ConfirmaCadastro");
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
            TempData["cadastradoInvalido"] = "Não foi possivel confirmar seu e-mail.";
            return View();

        }

        public ActionResult Salvar(CandidatoModel model)
        {
            var response = Request["g-recaptcha-response"];
            string secretKey = servicoConfiguracao.Captcha;

            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Message = status ? " Sucesso validar reCaptcha" : "Falha ao validar reCaptcha";


            if (ModelState.IsValid && !status)
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
                    candidato = ConverterCandidato(model);
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
        private CandidatoEntidade ConverterCandidatoSegundaEtapa(CandidatoParaReCadastroModel model, long id)
        {
            CandidatoEntidade candidato = new CandidatoEntidade();
            ServicoCriptografia servicoCriptografia = new ServicoCriptografia();
            candidato.Id = id;
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

        private CandidatoEntidade ConverterCandidato(CandidatoModel model)
        {
            CandidatoEntidade candidato = new CandidatoEntidade();
            candidato.Nome = model.Nome;
            candidato.Email = model.Email;
            candidato.Curso = model.Curso;
            candidato.Instituicao = model.Instituicao;
            candidato.Conclusao = model.Conclusao;
            candidato.Status = "Inicial";
            candidato.Senha = "12345";
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
    }
}