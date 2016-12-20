using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Models
{
    public class ProcessoSeletivoViewModel
    {
        public long? Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data Início das Entrevistas:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicioEntrevistas { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data Final da Seleção:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataSelecaoFinal { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data Início das Aulas:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicioAulas { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data Final das aulas:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFinalAulas { get; set; }

        [Required]
        [DisplayName("Ano desta Edição:")]
        public int AnoEdicao { get; set; }

        [Required]
        [DisplayName("Semestre desta Edição:")]
        public int SemestreEdicao { get; set; }

        
    }
}