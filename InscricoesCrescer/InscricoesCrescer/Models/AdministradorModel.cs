using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Models
{
    public class AdministradorModel
    {
        [Required]
        [DisplayName("E-mail:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Senha:")]
        public string Senha { get; set; }

    }
}