using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Infraestrutura;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class ServicoEmailTest
    {
        [TestMethod]
        public void TestarValidacaoDeEmailComEmailNormal()
        {
            ServicoEmail servicoEmail = new ServicoEmail();
            string emailValido = "daniel.carvalho.figueiredo@gmail.com";
            bool ehValido = servicoEmail.ValidaEmail(emailValido);

            Assert.AreEqual(true, ehValido);
        }

        [TestMethod]
        public void TestarValidacaoDeEmailComEmailErrado()
        {
            ServicoEmail servicoEmail = new ServicoEmail();
            string emailValido = "daniel.carvalho.figueiredo";
            bool ehValido = servicoEmail.ValidaEmail(emailValido);

            Assert.AreEqual(false, ehValido);
        }
    }
}
