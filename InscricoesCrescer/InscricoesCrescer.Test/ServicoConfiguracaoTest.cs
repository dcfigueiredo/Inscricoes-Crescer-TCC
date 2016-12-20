using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using InscricoesCrescer.Servico;
using InscricoesCrescer.Dominio.Configuracao;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class ServicoConfiguracaoTest
    {
        IServicoConfiguracao servicoConfiguracao = new ServicoConfiguracao();

        [TestMethod]
        public void TestarQuantidadeDeCandidatosPorPagina()
        {
            int quantidadeDeCandidatos = Convert.ToInt32(ConfigurationManager.AppSettings["QuantidadeDeCandidatosPorPagina"]);
            Assert.AreEqual(quantidadeDeCandidatos, servicoConfiguracao.QuantidadeDeCandidatosPorPagina);
        }
    }
}
