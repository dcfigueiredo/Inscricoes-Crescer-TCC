using InscricoesCrescer.Dominio.Entrevista;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using InscricoesCrescer.Dominio.Candidato;

namespace InscricoesCrescer.Models
{
    public class CadastroEntrevistaModel
    {

        public CadastroEntrevistaModel() { }

        public CadastroEntrevistaModel(EntrevistaEntidade entrevista)
        {
            this.Id = entrevista.Id;
            this.DataEntrevista = entrevista.DataEntrevista;
            this.CandidatoEntidadeId = entrevista.CandidatoEntidadeId;
            this.ParecerRH = entrevista.ParecerRH;
            this.ParecerTecnico = entrevista.ParecerTecnico;
            this.ProvaAC = entrevista.ProvaAC;
            this.ProvaG36 = entrevista.ProvaG36;
            this.ProvaTecnica = entrevista.ProvaTecnica;
        }

        public long? Id { get; internal set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data da Entrevista: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataEntrevista { get; set; }

        [Required]
        [DisplayName("Parecer do RH: ")]
        public string ParecerRH { get; set; }

        [Required]
        [DisplayName("Parecer Técnico: ")]
        public string ParecerTecnico { get; set; }
        
        [DisplayName("Nota prova g36: ")]
        public double ProvaG36 { get; set; }
        
        [DisplayName("Nota prova AC: ")]
        public double ProvaAC { get; set; }
        
        [DisplayName("Nota prova Técnica: ")]
        public double ProvaTecnica { get; set; }

        public long CandidatoEntidadeId { get; set; }

    }
}