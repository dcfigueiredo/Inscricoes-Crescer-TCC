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
        [TestMethod]
        public void TestaAcharUmAdministradorComEmailESenhaCertos()
        {
            AdministradorServico administradorServico = new AdministradorServico(new AdministradorRepositorioMock(), new ServicoCriptografia());
            string email = "daniel.carvalho.figueiredo@gmail.com";
            string senha = "123";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.AreEqual(administradorEsperado.Id, 2);            
        }

        [TestMethod]
        public void TestaAcharUmAdministradorComEmailCertoESenhaErrados()
        {
            AdministradorServico administradorServico = new AdministradorServico(new AdministradorRepositorioMock(), new ServicoCriptografia());
            string email = "daniel.carvalho.figueiredo@gmail.com";
            string senha = "1234";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.IsNull(administradorEsperado);
        }

        [TestMethod]
        public void TestaAcharUmAdministradorComEmailErradoESenhaCerto()
        {
            AdministradorServico administradorServico = new AdministradorServico(new AdministradorRepositorioMock(), new ServicoCriptografia());
            string email = "daniel.carvalho@gmail.com";
            string senha = "123";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.IsNull(administradorEsperado);
        }

        [TestMethod]
        public void TestaAcharUmAdministradorComEmailErradoESenhaErrada()
        {
            AdministradorServico administradorServico = new AdministradorServico(new AdministradorRepositorioMock(), new ServicoCriptografia());
            string email = "daniel.carvalho@gmail.com";
            string senha = "1234";
            AdministradorEntidade administradorEsperado = administradorServico.BuscarPorAutenticacao(email, senha);
            Assert.IsNull(administradorEsperado);
        }
    }
}
