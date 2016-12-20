using InscricoesCrescer.Dominio.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InscricoesCrescer.Dominio.Entrevista;
using InscricoesCrescer.Models;

namespace InscricoesCrescer.Models
{
    public class CandidatoParaViewModel
    {

        public CandidatoParaViewModel(CandidatoEntidade candidato)
        {
            this.Id = candidato.Id;
            this.Email = candidato.Email;
            this.Idade = CalcularIdade(Convert.ToDateTime(candidato.DataNascimento));
            this.Linkedin = candidato.Linkedin;
            this.Nome = candidato.Nome;
            this.Situacao = candidato.Status;
            this.Telefone = candidato.Telefone;
            this.Curso = candidato.Curso;
            this.Instituicao = candidato.Instituicao;
            if (candidato.Entrevistas != null)
            {
                this.Entrevistas = EntrevistaEntidadeParaViewModel(candidato.Entrevistas);
            }
        }

        private IList<EntrevistaParaViewModel> EntrevistaEntidadeParaViewModel(ICollection<EntrevistaEntidade> entrevistas)
        {
            IList<EntrevistaParaViewModel> entrevistaModel = new List<EntrevistaParaViewModel>();
            foreach (var entrevista in entrevistas)
            {
                EntrevistaParaViewModel model = new EntrevistaParaViewModel(entrevista);
                entrevistaModel.Add(model);
            }
            return entrevistaModel;
        }

        public long? Id { get; set; }

        public string Curso { get; set; }

        public string Nome { get; set; }

        public string Instituicao { get; set; }

        public int Telefone { get; set; }

        public int Idade { get; set; }

        public string Email { get; set; }

        public string Situacao { get; set; }
        
        public string Linkedin { get; set; }

        public ICollection<EntrevistaParaViewModel> Entrevistas { get; set; }


        public static int CalcularIdade(DateTime dataNascimento)
        {
            // Retorna o número de anos
            int YearsAge = DateTime.Now.Year - dataNascimento.Year;

            // Se a data de aniversário não ocorreu ainda este ano, subtrair um ano a partir da idade
            if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day))
            {
                YearsAge--;
            }
            return YearsAge;
        }

    }
}