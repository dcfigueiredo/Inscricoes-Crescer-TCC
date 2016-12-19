using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InscricoesCrescer.Models
{
    public class CadastroEntrevistaModel
    {
        public long Id { get; internal set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data da Entrevista: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataEntrevista { get; set; }

        [Required]
        [DisplayName("Parecer do RH: ")]
        public string ParecerRH { get; set; }

        [Required]
        [DisplayName("Parecerr Técnico: ")]
        public string ParecerTecnico { get; set; }

        
        [DisplayName("Nota prova g36: ")]
        public double ProvaG36 { get; set; }

        
        [DisplayName("Nota prova AC: ")]
        public double ProvaAC { get; set; }

        
        [DisplayName("Nota prova Técnica: ")]
        public double ProvaTecnica { get; set; }
    }
}