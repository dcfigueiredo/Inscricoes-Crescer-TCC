using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Infraestrutura.Service;

namespace InscricoesCrescer.Test
{
    [TestClass]
    public class ServicoCriptografiaTest
    {
        ServicoCriptografia servicoCriptografia = new ServicoCriptografia();
        [TestMethod]
        public void TestMethod1()
        {
            string codigo = servicoCriptografia.Criptografar("Rodrigo");
            Assert.AreEqual(codigo, "4855891d400b3d78fcad5a540a5076c0");
        }
    }
}
