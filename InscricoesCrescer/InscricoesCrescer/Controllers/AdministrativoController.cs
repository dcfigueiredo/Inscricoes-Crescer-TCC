using InscricoesCrescer.Dominio.Candidato;
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
        private ServicoConfiguracao servicoConfiguracao = ServicoDeDependencia.MontarServicoConfiguracao();
        private EntrevistaServico servicoEntrevista = ServicoDeDependencia.MontarEntrevistaServico();
        private ProcessoSeletivoServico servicoProcessoSeletivo = ServicoDeDependencia.MontarProcessoSeletivoServico();
        

        // GET: Administrativo
        [Autorizador]
        public ActionResult Index()
        {
            return View();
        }

        [Autorizador]
        public PartialViewResult CarregarProcessoSeletivo()
        {
            ProcessoSeletivoViewModel model = new ProcessoSeletivoViewModel();
            return PartialView("_ProcessoSeletivo", model);
        }

        [Autorizador]
        public PartialViewResult CarregarEntrevistas(long id)
        {            
            CandidatoEntidade candidato = candidatoServico.BuscarCandidatoPorID(id);
            IList<EntrevistaEntidade> entrevistas = servicoEntrevista.BuscarPorIdDoCandidato(id);
            candidato.Entrevistas = entrevistas;

            CandidatoParaViewModel model = new CandidatoParaViewModel(candidato);
            return PartialView("_Entrevistas", model);
        }

        [Autorizador]
        public PartialViewResult CarregarCadastroEntrevista(long idEntrevista, long idEntrevistado)
        {
            CadastroEntrevistaModel model;
            if (idEntrevista == 0)
            {
                model = new CadastroEntrevistaModel();
                model.CandidatoEntidadeId = idEntrevistado;            
                return PartialView("_CadastroEntrevista", model);
            }
            else
            {
                EntrevistaEntidade entrevista = servicoEntrevista.BuscarPorId(idEntrevista);
                model = new CadastroEntrevistaModel(entrevista);
                model.CandidatoEntidadeId = idEntrevistado;
                return PartialView("_CadastroEntrevista", model);
            }
        }

        [Autorizador]
        public ActionResult SalvarProcessoSeletivo(ProcessoSeletivoViewModel model) {

            if (ModelState.IsValid)
            {
                ProcessoSeletivoEntidade processo = MontarProcessoSeletivo(model);
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

        [Autorizador]
        [HttpPost]
        public JsonResult SalvarEntrevista(CadastroEntrevistaModel model)
        {
            if (ModelState.IsValid)
            {
                EntrevistaEntidade entrevista = ConverterModelParaEntidade(model);                
                servicoEntrevista.Salvar(entrevista);
                TempData["cadastradoComSucesso"] = "* cadastrado com sucesso!";
                return Json(JsonRequestBehavior.AllowGet);
            }
            ModelState.AddModelError("", "Não foi possivel completar cadastro! " + "\n" +
                                    "verifique se todos os dados foram digitados corretamente.");

            return Json(JsonRequestBehavior.AllowGet);
        }

        [Autorizador]
        public ActionResult Editar(long id)
        {
            return View();
        }

        [Autorizador]
        public PartialViewResult CarregarListaDeCandidatos(int pagina, string filtro)
        {
            IList<CandidatoEntidade> candidatos = candidatoServico.BuscarCandidatos(pagina, filtro);
            ListaCandidatosViewModel model = CarregarCandidatosNaModelDeListagem(candidatos, pagina);
            return PartialView("_ListaCandidatos", model);
        }

        private ProcessoSeletivoEntidade MontarProcessoSeletivo(ProcessoSeletivoViewModel model)
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

        private EntrevistaEntidade ConverterModelParaEntidade(CadastroEntrevistaModel model)
        {
            EntrevistaEntidade entrevista = new EntrevistaEntidade();
            CandidatoEntidade candidato = candidatoServico.BuscarCandidatoPorID(model.CandidatoEntidadeId);
            entrevista.EmailAdministrador = ServicoDeAutenticacao.AdministradorLogado.Email;
            entrevista.DataEntrevista = model.DataEntrevista;
            entrevista.ParecerRH = model.ParecerRH;
            entrevista.ParecerTecnico = model.ParecerTecnico;
            entrevista.ProvaG36 = model.ProvaG36;
            entrevista.ProvaAC = model.ProvaAC;
            entrevista.ProvaTecnica = model.ProvaTecnica;
            entrevista.CandidatoEntidadeId = model.CandidatoEntidadeId;
            entrevista.Candidato = candidato;
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