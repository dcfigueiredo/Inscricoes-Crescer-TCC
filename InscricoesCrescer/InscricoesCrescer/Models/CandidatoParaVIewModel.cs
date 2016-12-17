using InscricoesCrescer.Dominio.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Models
{
    public class CandidatoParaViewModel
    {

        public CandidatoParaViewModel(CandidatoEntidade candidato)
        {
            this.Id = candidato.Id;
            this.Email = candidato.Email;
            this.Idade = calcularIdade(candidato.DataNascimento);
            this.Linkedin = candidato.Linkedin;
            this.Nome = candidato.Nome;
            this.Situacao = candidato.Status;
            this.Telefone = candidato.Telefone;
        }

        public long? Id { get; set; }

        public string Nome { get; set; }

        public int Telefone { get; set; }

        public int Idade { get; set; }

        public string Email { get; set; }

        public string Situacao { get; set; }
        
        public string Linkedin { get; set; }

        private int calcularIdade(DateTime? dataNascimento)
        {
            return DateTime.Now.Year - dataNascimento.Value.Year;
        }

    }
}