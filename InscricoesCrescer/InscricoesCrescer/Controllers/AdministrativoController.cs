﻿using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Dominio.Entrevista;
using InscricoesCrescer.Dominio.Configuracao;
using InscricoesCrescer.Filters;
using InscricoesCrescer.Models;
using InscricoesCrescer.Servico;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using InscricoesCrescer.Dominio.ProcessoSeletivo;
using InscricoesCrescer.Infraestrutura;

namespace InscricoesCrescer.Controllers
{
    public class AdministrativoController : Controller
    {

        private CandidatoServico candidatoServico = ServicoDeDependencia.MontarCandidatoServico();
        private IServicoConfiguracao servicoConfiguracao = ServicoDeDependencia.MontarServicoConfiguracao();
        private EntrevistaServico servicoEntrevista = ServicoDeDependencia.MontarEntrevistaServico();
        private ProcessoSeletivoServico servicoProcessoSeletivo = ServicoDeDependencia.MontarProcessoSeletivoServico();


        // GET: Administrativo
        [Autorizador]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProcessoSeletivo()
        {
            return PartialView("_ProcessoSeletivo");
        }

        public PartialViewResult CarregarEntrevistas(int id)
        {
            List<EntrevistaEntidade> entrevistas = servicoEntrevista.BuscarTodosComMesmoId(id);
            return PartialView("_Entrevista", entrevistas);
        }

        public ActionResult SalvarProcessoSeletivo(ProcessoSeletivoViewModel model)
        {

            if (ModelState.IsValid)
            {

                ProcessoSeletivoEntidade processo = montarProcessoSeletivo(model);
                if(servicoProcessoSeletivo.VerificarProcessoExiste(processo))
                {
                    TempData["Data invalida"] = "* Ano ou semestre inválido, ja existe edição cadastrada nesse semestre.";
                    return PartialView("_ProcessoSeletivo");
                }
                servicoProcessoSeletivo.Salvar(processo);
                ServicoEmail servicoEmail = new ServicoEmail();
                List<CandidatoEntidade> candidatosInteressados = candidatoServico.BuscarInteressados();

                if (servicoEmail.enviarEmailDeNotificacao(candidatosInteressados, model.DataInicioEntrevistas, model.DataSelecaoFinal))
                {
                    foreach (var item in candidatosInteressados)
                    {
                        item.Status = "Notificado";
                        candidatoServico.Salvar(item);
                    }
                }
                
                TempData["cadastradoComSucesso"] = "* cadastrado com sucesso!";
                return PartialView("_ProcessoSeletivo");
            }
            ModelState.AddModelError("", "Não foi possivel completar cadastro! " + "\n" +
                                    "verifique se todos os dados foram digitados corretamente.");

            return PartialView("_ProcessoSeletivo", model);
        }

        public ActionResult CadastroEntrevista(long id)
        {
            CadastroEntrevistaModel model = new CadastroEntrevistaModel();
            model.Id = id;
            return PartialView("_CadastroEntrevista", model);
        }

        public ActionResult SalvarEntrevista(CadastroEntrevistaModel model)
        {
            if (ModelState.IsValid)
            {
                EntrevistaEntidade entrevista = ConvertModelParaEntidade(model);
                servicoEntrevista.Salvar(entrevista);

                TempData["cadastradoComSucesso"] = "* cadastrado com sucesso!";
                return PartialView("_CadastroEntrevista");
            }
            ModelState.AddModelError("", "Não foi possivel completar cadastro! " + "\n" +
                                    "verifique se todos os dados foram digitados corretamente.");

            return PartialView("_CadastroEntrevista", model);
        }

        private ProcessoSeletivoEntidade montarProcessoSeletivo(ProcessoSeletivoViewModel model)
        {
            ProcessoSeletivoEntidade processoSeletivo = new ProcessoSeletivoEntidade();
            processoSeletivo.Id = model.Id;
            processoSeletivo.SemestreEdicao = model.SemestreEdicao;
            processoSeletivo.DataSelecaoFinal = model.DataSelecaoFinal;
            processoSeletivo.DataInicioEntrevistas = model.DataInicioEntrevistas;
            processoSeletivo.DataInicioAulas = model.DataInicioAulas;
            processoSeletivo.DataFinalAulas = model.DataFinalAulas;
            processoSeletivo.AnoEdicao = model.AnoEdicao;
            return processoSeletivo;
        }

        public ActionResult Editar(long id)
        {
            return View();
        }

        public ActionResult EditarEntrevista(long id)
        {
            EntrevistaEntidade entrevista = servicoEntrevista.BuscarPorId(id);
            CadastroEntrevistaModel model = ConvertEntidadaeParaModel(entrevista);
            return View("_CadastroEntrevista", model);
        }


        [Autorizador]
        public PartialViewResult CarregarListaDeCandidatos(int pagina, string filtro)
        {
            IList<CandidatoEntidade> candidatos = candidatoServico.BuscarCandidatos(pagina, filtro);
            ListaCandidatosViewModel model = CarregarCandidatosNaModelDeListagem(candidatos, pagina);
            return PartialView("_ListaCandidatos", model);
        }

        private CadastroEntrevistaModel ConvertEntidadaeParaModel(EntrevistaEntidade entrevista)
        {
            CadastroEntrevistaModel model = new CadastroEntrevistaModel();
            model.Id = entrevista.Id;
            model.DataEntrevista = entrevista.DataEntrevista;
            model.ParecerRH = entrevista.ParecerRH;
            model.ParecerTecnico = entrevista.ParecerTecnico;
            model.ProvaG36 = entrevista.ProvaG36;
            model.ProvaAC = entrevista.ProvaAC;
            model.ProvaTecnica = entrevista.ProvaTecnica;

            return model;
        }

        private EntrevistaEntidade ConvertModelParaEntidade(CadastroEntrevistaModel model)
        {
            EntrevistaEntidade entrevista = new EntrevistaEntidade();
            entrevista.Id = model.Id;
            entrevista.EmailAdministrador = ServicoDeAutenticacao.AdministradorLogado.Email;
            entrevista.DataEntrevista = model.DataEntrevista;
            entrevista.ParecerRH = model.ParecerRH;
            entrevista.ParecerTecnico = model.ParecerTecnico;
            entrevista.ProvaG36 = model.ProvaG36;
            entrevista.ProvaAC = model.ProvaAC;
            entrevista.ProvaTecnica = model.ProvaTecnica;

            return entrevista;
        }

        private ListaCandidatosViewModel CarregarCandidatosNaModelDeListagem(IList<CandidatoEntidade> candidatos, int? pagina = null)
        {
            var model = new ListaCandidatosViewModel(candidatos);
            if (pagina.HasValue)
            {
                model.PaginaAtual = pagina.Value;
            }
            model.QuantidadeDeItensPorPagina = servicoConfiguracao.QuantidadeDeCandidatosPorPagina;
            return model;
        }
    }
}