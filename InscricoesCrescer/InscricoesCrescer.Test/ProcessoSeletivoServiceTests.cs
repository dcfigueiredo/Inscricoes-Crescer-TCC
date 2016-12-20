using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InscricoesCrescer.Dominio.ProcessoSeletivo;
using InscricoesCrescer.Mock.ProcessoSeletivo;

namespace InscricoesCrescer.Test
{
    [TestClass]
        public class ProcessoSeletivoServicoTest
        {
            [TestMethod]
            public void TestaBuscarTodosOsProcessosCadastrados()
            {
                ProcessoSeletivoServico processoServico = new ProcessoSeletivoServico(new ProcessoSeletivoRepositorioMock());
                IList<ProcessoSeletivoEntidade> processos = processoServico.BuscarTodos();
                Assert.AreEqual(2, processos.Count);
            }

            
        }
    }


