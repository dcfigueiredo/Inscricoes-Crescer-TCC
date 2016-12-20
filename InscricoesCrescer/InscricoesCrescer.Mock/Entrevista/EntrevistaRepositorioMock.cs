using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Dominio.Entrevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Mock.Entrevista
{
    public class EntrevistaRepositorioMock : IEntrevistaRepositorio
    {

        public IList<EntrevistaEntidade> entrevistas = new List<EntrevistaEntidade>()
        {
            new EntrevistaEntidade ()
            {
                Id = 1,
                CandidatoEntidadeId = 1,
                Candidato = new CandidatoEntidade ()
                {
                    Id = 1,
                    Nome = "Daniel de Carvalho Figueiredo",
                },
                DataEntrevista = new DateTime(2018, 12, 1),
                EmailAdministrador = "carol.leite@cwi.com.br",
                ParecerRH = "Parecer do RH",
                ParecerTecnico = "Parecer Tecnico",
                ProvaAC = 5,
                ProvaG36 = 6,
                ProvaTecnica = 10,                
            },

            new EntrevistaEntidade ()
            {
                Id = 2,
                CandidatoEntidadeId = 1,
                Candidato = new CandidatoEntidade ()
                {
                    Id = 1,
                    Nome = "Daniel de Carvalho Figueiredo",
                },
                DataEntrevista = new DateTime(2017, 12, 1),
                EmailAdministrador = "carol.leite@cwi.com.br",
                ParecerRH = "Parecer do RH Com String louca caso de treta nos testes",
                ParecerTecnico = "Parecer Tecnico",
                ProvaAC = 5,
                ProvaG36 = 10,
                ProvaTecnica = 6,
            }
        };

        public EntrevistaEntidade BuscarPorId(long id)
        {
            return this.entrevistas.FirstOrDefault(_ => _.Id == id);
        }

        public IList<EntrevistaEntidade> BuscarPorIdDoCandidato(long id)
        {
            return this.entrevistas.Where(_ => _.CandidatoEntidadeId == id).ToList();
        }

        public List<EntrevistaEntidade> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Criar(EntrevistaEntidade entrevista)
        {
            this.entrevistas.Add(entrevista);
        }

        public void Editar(EntrevistaEntidade entrevista)
        {
            int posicao = entrevistas.IndexOf(entrevista);
            entrevistas.Insert(posicao, entrevista);
        }
    }
}
