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
        CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorioMock(), new ServicoConfiguracao());

        [TestMethod]
        public void TestaBuscarTodosOsCandidatosComFiltro()
        {
            IList<CandidatoEntidade> candidatos = candidatoServico.BuscarCandidatos(0, "Anna");
            Assert.AreEqual(candidatos[0].Nome, "Anna Luisa da Silva");
        }

        [TestMethod]
        public void TestaBuscarCandidatosSemFiltro()
        {
            IList<CandidatoEntidade> candidatos = candidatoServico.BuscarCandidatos(0, "");
            Assert.AreEqual(3, candidatos.Count);
        }

        [TestMethod]
        public void TestaBuscarInteressados()
        {
            List<CandidatoEntidade> canditados = candidatoServico.BuscarInteressados();
            Assert.AreEqual(2, canditados.Count);
        }

        [TestMethod]
        public void TestaBuscarTodos()
        {
            List<CandidatoEntidade> canditados = candidatoServico.BuscarTodos();
            int qtd = canditados.Count;
            Assert.AreEqual(3, qtd);
        }

        [TestMethod]
        public void TestaSalvarUmCandidato()
        {
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

        [TestMethod]
        public void TestaBuscarPorEmail()
        {
            CandidatoEntidade canditadoEsperado = candidatoServico.BuscarPorEmail("rodrigo.scheuer@hotmail.com");
            Assert.AreEqual("Rodrigo Scheuer", canditadoEsperado.Nome);
        }


    }
}
