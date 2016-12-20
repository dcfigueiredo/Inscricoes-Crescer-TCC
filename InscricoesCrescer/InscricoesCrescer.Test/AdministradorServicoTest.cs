using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Infraestrutura.Service;
using InscricoesCrescer.Mock.Administrador;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class AdministradorServicoTest
    {
        AdministradorServico administradorServico = new AdministradorServico(new AdministradorRepositorioMock(), new ServicoCriptografia());

        [TestMethod]
        public void TestaAcharUmAdministradorComEmailESenhaCertos()
        {
            string email = "daniel.carvalho.figueiredo@gmail.com";
            string senha = "123";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.AreEqual(administradorEsperado.Id, 2);
        }

        [TestMethod]
        public void TestaAcharUmAdministradorComEmailCertoESenhaErrados()
        {
            string email = "daniel.carvalho.figueiredo@gmail.com";
            string senha = "1234";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.IsNull(administradorEsperado);
        }

        [TestMethod]
        public void TestaAcharUmAdministradorComEmailErradoESenhaCerto()
        {
            string email = "daniel.carvalho@gmail.com";
            string senha = "123";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.IsNull(administradorEsperado);
        }

        [TestMethod]
        public void TestaAcharUmAdministradorComEmailErradoESenhaErrada()
        {
            string email = "daniel.carvalho@gmail.com";
            string senha = "1234";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.IsNull(administradorEsperado);
        }

    }
}
