using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Mock.Candidato;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;
using System.Collections.Generic;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class CandidatoServicoTest
    {

        [TestMethod]
        public void TestaBuscarTodosOsCandidatosComFiltro()
        {
            CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorioMock(), new ServicoConfiguracao());
            IList<CandidatoEntidade> candidatos = candidatoServico.BuscarCandidatos(0, "Anna");
            Assert.AreEqual(candidatos[0].Nome, "Anna Luisa da Silva");
        }

        [TestMethod]
        public void TestaBuscarCandidatosSemFiltro()
        {
            CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorioMock(), new ServicoConfiguracao());
            IList<CandidatoEntidade> candidatos = candidatoServico.BuscarCandidatos(0, "");
            Assert.AreEqual(3, candidatos.Count);
        }

        [TestMethod]
        public void TestaSalvarUmCandidato()
        {
            CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorioMock(), new ServicoConfiguracao());
            CandidatoEntidade candidato = new CandidatoEntidade()
            {
                Id = 0,
                Nome = "Ben-hur dos Santos",
                Email = "ben-hur@outlook.com",
                Instituicao = "FEVALE",
                Curso = "Alguma coisa Web",
                Conclusao = new DateTime(2017, 12, 12)
            };
            candidatoServico.Salvar(candidato);
            CandidatoEntidade canditadoEsperado = candidatoServico.BuscarCandidatoPorID(4);
            Assert.AreEqual("Ben-hur dos Santos", canditadoEsperado.Nome);
        }               
    }
}
