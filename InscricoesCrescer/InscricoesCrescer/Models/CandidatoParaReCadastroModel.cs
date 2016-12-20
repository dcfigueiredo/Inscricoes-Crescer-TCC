using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InscricoesCrescer.Models
{
    public class CandidatoParaReCadastroModel
    {
        public long? Id { get; set; }

        [Required]
        [DisplayName("Nome completo:")]
        public string Nome { get; set; }

        [Required]
        [DisplayName("E-mail:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Instituição de ensino:")]
        public string Instituicao { get; set; }

        [Required]
        [DisplayName("Curso:")]
        public string Curso { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data de conclusão do curso:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Conclusao { get; set; }

        [DisplayName("Status:")]
        public string Status { get; set; }

        [Required]
        [DisplayName("Telefone:")]
        public int Telefone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }

        [Required]
        [DisplayName("Cidade:")]
        public string Cidade { get; set; }

        [Required]
        [DisplayName("Linkedin:")]
        public string Linkedin { get; set; }

        [Required]
        [DisplayName("Senha:")]
        public string Senha { get; set; }

        [DisplayName("ConfirmaSenha:")]
        public string ConfirmaSenha { get; set; }
    }
}