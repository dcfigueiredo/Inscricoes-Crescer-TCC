using InscricoesCrescer.Dominio.Entrevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Models
{
    public class EntrevistaParaViewModel
    {

        public EntrevistaParaViewModel(EntrevistaEntidade entrevista)
        {
            this.Id = entrevista.Id;
            this.EmailAdministrador = entrevista.EmailAdministrador;
            this.DataEntrevista = entrevista.DataEntrevista;
        }

        public long? Id { get; set; }

        public string EmailAdministrador { get; set; }

        public DateTime DataEntrevista { get; set; }
    }
}