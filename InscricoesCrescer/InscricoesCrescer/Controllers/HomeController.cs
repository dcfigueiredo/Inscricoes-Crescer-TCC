﻿using InscricoesCrescer.Dominio;
using InscricoesCrescer.Models;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;
using InscricoesCrescer.Infraestrutura;
using System.Collections.Generic;
using InscricoesCrescer.Infraestrutura.Service;
using System.Net;

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
                    candidatoServico.Salvar(AlterarStatusParaInteresse(candidato));
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
            //validação captcha.
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
            else
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

        private CandidatoEntidade AlterarStatusParaInteresse(CandidatoEntidade candidato)
        {
            CandidatoEntidade novoCandidato = new CandidatoEntidade();
            novoCandidato.Id = candidato.Id;
            novoCandidato.Email = candidato.Email;
            novoCandidato.Nome = candidato.Nome;
            novoCandidato.Instituicao = candidato.Instituicao;
            novoCandidato.Curso = candidato.Curso;
            novoCandidato.Conclusao = candidato.Conclusao;
            novoCandidato.Status = "Interesse";
            return novoCandidato;
        }
    }
}