using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Dominio.Entrevista;
using InscricoesCrescer.Mock.Entrevista;
using System.Collections.Generic;
using InscricoesCrescer.Dominio.Candidato;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class EntrevistaServicoTest
    {
        [TestMethod]
        public void TestaBuscarEntrevistaComIdExistente()
        {
            EntrevistaRepositorioMock erm = new EntrevistaRepositorioMock();
            EntrevistaServico servico = new EntrevistaServico(erm);

            EntrevistaEntidade entrevistaEsperada = servico.BuscarPorId(1);

            Assert.AreEqual(erm.entrevistas[0], entrevistaEsperada);
        }

        [TestMethod]
        public void TestaBuscarEntrevistaComIdInexistente()
        {
            EntrevistaRepositorioMock erm = new EntrevistaRepositorioMock();
            EntrevistaServico servico = new EntrevistaServico(erm);

            EntrevistaEntidade entrevistaEsperada = servico.BuscarPorId(4);

            Assert.IsNull(entrevistaEsperada);
        }

        [TestMethod]
        public void TestaBuscarEntrevistasPeloIdDoCandidatoDeveRetornarDuas()
        {
            EntrevistaRepositorioMock erm = new EntrevistaRepositorioMock();
            EntrevistaServico servico = new EntrevistaServico(erm);

            IList<EntrevistaEntidade> entrevistasEsperadas = servico.BuscarPorIdDoCandidato(1);

            Assert.AreEqual(2, entrevistasEsperadas.Count);
        }

        [TestMethod]
        public void TestaBuscarEntrevistasPeloIdDoCandidatoQueNaoExisteDeveTerTamanhoZero()
        {
            EntrevistaRepositorioMock erm = new EntrevistaRepositorioMock();
            EntrevistaServico servico = new EntrevistaServico(erm);

            IList<EntrevistaEntidade> entrevistasEsperadas = servico.BuscarPorIdDoCandidato(3);

            Assert.AreEqual(0, entrevistasEsperadas.Count);
        }

        [TestMethod]
        public void TestaEditarUmaEntrevista()
        {
            EntrevistaRepositorioMock erm = new EntrevistaRepositorioMock();
            EntrevistaServico servico = new EntrevistaServico(erm);
            EntrevistaEntidade entrevistaEditada = erm.entrevistas[0];

            entrevistaEditada.EmailAdministrador = "batatinhaquandonasce@cwi.com.br";

            servico.Salvar(entrevistaEditada);

            Assert.AreEqual("batatinhaquandonasce@cwi.com.br", erm.entrevistas[0].EmailAdministrador);
        }

        [TestMethod]
        public void TestaCriarUmaEntrevista()
        {
            EntrevistaRepositorioMock erm = new EntrevistaRepositorioMock();
            EntrevistaServico servico = new EntrevistaServico(erm);
            EntrevistaEntidade entrevistaNova = new EntrevistaEntidade()
            {
                Id = 0,
                CandidatoEntidadeId = 2,
                Candidato = new CandidatoEntidade()
                {
                    Id = 2,
                    Nome = "Goku da Silva Sauro",
                },
                DataEntrevista = new DateTime(2017, 12, 1),
                EmailAdministrador = "carol.leite@cwi.com.br",
                ParecerRH = "Parecer do RH Com String louca caso de treta nos testes de novo pq o bernardo uma vez falou que a gente deveria escrever testes inusitados, já que uma vez uma criptografia foi quebrada pq a senha começava com 0",
                ParecerTecnico = "Parecer Tecnico",
                ProvaAC = 5,
                ProvaG36 = 10,
                ProvaTecnica = 6,
            };            

            servico.Salvar(entrevistaNova);

            Assert.AreEqual(3, erm.entrevistas.Count);
        }
    }
}
