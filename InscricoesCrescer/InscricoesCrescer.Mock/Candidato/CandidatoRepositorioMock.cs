using InscricoesCrescer.Dominio.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Mock.Candidato
{
    public class CandidatoRepositorioMock : ICandidatoRepositorio
    {
        private static IList<CandidatoEntidade> candidatos = new List<CandidatoEntidade>()
        {
            new CandidatoEntidade()
            {
                Id = 1,
                Nome = "Anna Luisa da Silva",
                Email = "annaluisa1703@gmail.com",
                Instituicao = "UNISINOS",
                Curso = "Sistemas de Informação",
                Conclusao = new DateTime (2020, 12, 12)
            },
            new CandidatoEntidade()
            {
                Id = 2,
                Nome = "Daniel de Carvalho Figueiredo",
                Email = "daniel.carvalho.figueiredo@gmail.com",
                Instituicao = "UNISINOS",
                Curso = "Ciências da Computação",
                Conclusao = new DateTime (2021, 6, 12)
            },
            new CandidatoEntidade()
            {
                Id = 3,
                Nome = "Rodrigo Scheuer",
                Email = "rodrigo.scheuer@hotmail.com",
                Instituicao = "UNISINOS",
                Curso = "Analise e Desenvolvimento de Sistemas",
                Conclusao = new DateTime (2025, 12, 12)
            }
        };

        public void Criar(CandidatoEntidade candidato)
        {
            candidatos.Add(candidato);            
        }
        public void Editar(CandidatoEntidade candidato)
        {
            CandidatoEntidade candidatoASerModificado = candidatos.FirstOrDefault(_ => _.Id == candidato.Id);
            candidatoASerModificado = candidato;
        }
    }
}
