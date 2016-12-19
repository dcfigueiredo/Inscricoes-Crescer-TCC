using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Dominio.Configuracao;
using InscricoesCrescer.Filters;
using InscricoesCrescer.Models;
using InscricoesCrescer.Servico;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InscricoesCrescer.Controllers
{
    public class AdministrativoController : Controller
    {

        private CandidatoServico candidatoServico = ServicoDeDependencia.MontarCandidatoServico();
        private IServicoConfiguracao servicoConfiguracao = ServicoDeDependencia.MontarServicoConfiguracao();

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

        public ActionResult Entrevistar(long id)
        {
            return View();
        }

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