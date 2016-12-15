using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InscricoesCrescer.Models
{
    public class CandidatoModel
    {
        public long? Id { get; set; }

        [Required]
        [DisplayName("Nome completo:")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Nome completo:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Instituição de ensino:")]
        public string Instituicao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data de concluão do curso:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Conclusao { get; set; }
    }
}