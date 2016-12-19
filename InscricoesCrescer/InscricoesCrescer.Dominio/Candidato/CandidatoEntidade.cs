using InscricoesCrescer.Dominio.Entrevista;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InscricoesCrescer.Dominio.Candidato
{
    [Table("Candidato")]
    public class CandidatoEntidade
    {
        public long? Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Instituicao { get; set; }

        public string Curso { get; set; }

        public DateTime Conclusao { get; set; }

        public string Status { get; set; }

        public int Telefone { get; set; }

        public string Linkedin { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string Cidade { get; set; }

        public string Senha { get; set; }

        public ICollection<EntrevistaEntidade> Entrevistas { get; set;}
}
}
