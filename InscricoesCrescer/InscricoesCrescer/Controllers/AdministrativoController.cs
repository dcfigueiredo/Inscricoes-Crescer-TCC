using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Dominio.Configuracao;
using InscricoesCrescer.Filters;
using InscricoesCrescer.Models;
using InscricoesCrescer.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
<<<<<<<

        public PartialViewResult CarregarListaDeCandidatos(int pagina)
        {
            IList<CandidatoEntidade> candidatos = candidatoServico.BuscarCandidatos(pagina);
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
=======


        private List<CandidatoModel2> convertListaParaCandidatoModel2(List<CandidatoEntidade> lista)
        {
            foreach (CandidatoEntidade item in lista)
            {
                CandidatoModel2 candidato = new CandidatoModel2();
                candidato.Id = item.Id;
                candidato.Nome = item.Nome;
                DateTime dataNascimento = Convert.ToDateTime(item.DataNascimento);
                candidato.Idade = CalculaIdade(dataNascimento);
                candidato.Email = item.Email;
                candidato.Telefone = item.Telefone;
                candidato.Cidade = item.Cidade;
                candidato.Instituicao = item.Instituicao;
                candidato.Curso = item.Curso;
                candidato.Conclusao = item.Conclusao;
                candidato.Linkedin = item.Linkedin;
                candidato.Status = item.Status;
                candidato.Senha = item.Senha;
            }
            return null;
        }

        private static int CalculaIdade(DateTime dataNascimento)
        {
            if (dataNascimento != null)
            {
                // Retorna o número de anos
                int idade = (DateTime.Now.Year - dataNascimento.Year);

                // Se a data de aniversário não ocorreu ainda este ano, subtrair um ano a partir da idade
                if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day))
                {
                    idade --;
                }
                return idade;
            }
            else
            {
                return 0;
            }
        }

>>>>>>>
    }
}