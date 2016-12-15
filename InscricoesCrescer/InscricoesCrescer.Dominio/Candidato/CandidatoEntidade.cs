using System;
namespace InscricoesCrescer.Dominio.Candidato
{
    public class CandidatoEntidade
    {
        public long? Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Instituicao { get; set; }

        public string Curso { get; set; }

        public DateTime Conclusao { get; set; }
    }
}
