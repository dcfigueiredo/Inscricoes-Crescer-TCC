using InscricoesCrescer.Dominio.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Models
{
    public class ListaCandidatosViewModel
    {
        public ListaCandidatosViewModel(IList<CandidatoEntidade> candidatos)
        {
            this.Candidatos = this.ConverterParaListaDeCandidatos(candidatos);
        }

        public int PaginaAtual { get; set; }
        public int QuantidadeDeItensPorPagina { get; set; }
        public IList<CandidatoParaViewModel> Candidatos { get; set; }
        public bool UltimaPagina
        {
            get
            {
                return Candidatos.Count < this.QuantidadeDeItensPorPagina;
            }
        }

        private IList<CandidatoParaViewModel> ConverterParaListaDeCandidatos(IList<CandidatoEntidade> candidatos)
        {
            IList<CandidatoParaViewModel> model = new List<CandidatoParaViewModel>();
            foreach (var candidato in candidatos)
            {
                model.Add(new CandidatoParaViewModel(candidato));
            }
            return model;
        }
    }
}