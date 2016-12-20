using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Infraestrutura;
using System.Collections.Generic;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Servico;
using InscricoesCrescer.Mock.Candidato;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class ServicoEmailTest
    {
        ServicoEmail servicoEmail = new ServicoEmail();

        [TestMethod]
        public void TestarValidacaoDeEmailComEmailNormal()
        {
            string emailValido = "daniel.carvalho.figueiredo@gmail.com";
            bool ehValido = servicoEmail.ValidaEmail(emailValido);

            Assert.AreEqual(true, ehValido);
        }

        [TestMethod]
        public void TestarValidacaoDeEmailComEmailErrado()
        {
            string emailValido = "daniel.carvalho.figueiredo";
            bool ehValido = servicoEmail.ValidaEmail(emailValido);

            Assert.AreEqual(false, ehValido);
        }

        [TestMethod]
        public void TestarEnvioDeEmailDeConfirmacao()
        {
            bool confirmacao = servicoEmail.enviarEmailConfirmacao("rodrigo.scheuer@hotmail.com");
            Assert.AreEqual(true, confirmacao);

        }

        [TestMethod]
        public void TestarEnvioDeEmailDeNotificacao()
        {
            CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorioMock(), new ServicoConfiguracao());
            List<CandidatoEntidade> lista = new List<CandidatoEntidade>();
            lista = candidatoServico.BuscarInteressados();
            DateTime dataInicio = Convert.ToDateTime("12/12/1992");
            DateTime dataFim = Convert.ToDateTime("13/12/1992");
            bool confirmacao = servicoEmail.enviarEmailDeNotificacao(lista, dataInicio, dataFim);
            Assert.AreEqual(true, confirmacao);
        }

        [TestMethod]
        public void TestarBuscaConfig()
        {
            string config = ServicoEmail.buscarConfiguracao("configuracao");
            Assert.AreEqual("campo vazio.", config);
        }
    }
}
