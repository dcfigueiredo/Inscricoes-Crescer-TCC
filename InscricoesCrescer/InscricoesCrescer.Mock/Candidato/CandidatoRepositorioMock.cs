using InscricoesCrescer.Dominio.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InscricoesCrescer.Dominio.Configuracao;

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
                Conclusao = new DateTime (2020, 12, 12),
                Status = "Interesse"
            },
            new CandidatoEntidade()
            {
                Id = 2,
                Nome = "Daniel de Carvalho Figueiredo",
                Email = "daniel.carvalho.figueiredo@gmail.com",
                Instituicao = "UNISINOS",
                Curso = "Ciências da Computação",
                Conclusao = new DateTime (2021, 6, 12),
                Status = "Interesse"
            },
            new CandidatoEntidade()
            {
                Id = 3,
                Nome = "Rodrigo Scheuer",
                Email = "rodrigo.scheuer@hotmail.com",
                Instituicao = "UNISINOS",
                Curso = "Analise e Desenvolvimento de Sistemas",
                Conclusao = new DateTime (2025, 12, 12),
                Status = "Inicial"
            }
        };

        public IList<CandidatoEntidade> BuscarCandidatos(Paginacao paginacao)
        {
            return candidatos.OrderBy(_ => _.Id).Skip(paginacao.Pagina * paginacao.QuantidadeDeItensPorPagina)
                             .Take(paginacao.QuantidadeDeItensPorPagina).Where(_ => _.Nome.Contains(paginacao.Filtro))
                             .ToList();
        }

        public CandidatoEntidade BuscarPorEmail(string email)
        {
            return candidatos.FirstOrDefault(_ => _.Email == email);
        }

        public CandidatoEntidade BuscarPorId(long id)
        {
            return candidatos.FirstOrDefault(_ => _.Id == id);
        }

        public List<CandidatoEntidade> buscarStatusInteresse()
        {
            return candidatos.Where(_ => _.Status.Contains("Interesse")).ToList();
        }

        public List<CandidatoEntidade> BuscarTodos()
        {
            return candidatos.ToList();
        }

        public void Criar(CandidatoEntidade candidato)
        {
            candidato.Id = 4;
            candidatos.Add(candidato);
        }

        public void Editar(CandidatoEntidade candidato)
        {
            throw new NotImplementedException();
        }
    }
}
