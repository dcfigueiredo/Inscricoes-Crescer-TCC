using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Mock.Candidato;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class CandidatoServicoTest
    {
        
        CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorioMock(), new ServicoConfiguracao());
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
                Conclusao = new DateTime(2017,12,12)
            };
            candidatoServico.Salvar(candidato);
            CandidatoEntidade canditadoEsperado = candidatoServico.BuscarCandidatoPorID(4);
            Assert.AreEqual("Ben-hur dos Santos", canditadoEsperado.Nome);
        }
    }
}
