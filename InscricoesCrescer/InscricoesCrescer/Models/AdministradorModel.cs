using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InscricoesCrescer.Models
{
    public class AdministradorModel
    {
        public AdministradorModel(String email)
        {
            this.Email = email;
        }

        [Required]
        [DisplayName("Nome:")]
        public string Nome { get; set; }
        
        [Required]
        [DisplayName("E-mail:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [DisplayName("Senha:")]
        public string Senha { get; set; }

    }
}