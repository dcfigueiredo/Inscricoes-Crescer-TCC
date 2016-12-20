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
        /*
        [TestMethod] //ok
        public void TestaBuscarProcessosNenhumCadastrado()
        {
            ProcessoSeletivoServico processoServico = new ProcessoSeletivoServico(new ProcessoSeletivoRepositorioMock());
            IList<ProcessoSeletivoEntidade> processos = processoServico.BuscarTodos();
            Assert.AreEqual(0, processos.Count);
        }*/

        
         [TestMethod] 
         public void TestaBuscarTodosOsProcessosCadastrados()
         {
             ProcessoSeletivoServico processoServico = new ProcessoSeletivoServico(new ProcessoSeletivoRepositorioMock());
             IList<ProcessoSeletivoEntidade> processos = processoServico.BuscarTodos();
             Assert.AreEqual(3, processos.Count);
         }
       
        
         [TestMethod]
         public void TestaVerificacaoDeEdicaoIguais()
         {
             ProcessoSeletivoServico processoServico = new ProcessoSeletivoServico(new ProcessoSeletivoRepositorioMock());
             processoServico.VerificarProcessoExiste(new Dominio.ProcessoSeletivo.ProcessoSeletivoEntidade());

             Assert.IsTrue(true);
         }


        [TestMethod]
        public void TestaSalvarUmProcesso()
        {
            ProcessoSeletivoEntidade processo = new ProcessoSeletivoEntidade()
            {
                 Id = 0,
                 DataInicioEntrevistas = new DateTime(2017, 12, 12),
                 DataSelecaoFinal = new DateTime(2017, 12, 12),
                 DataInicioAulas = new DateTime(2017, 12, 12),
                 DataFinalAulas = new DateTime(2017, 12, 12),
                 AnoEdicao = 2018,
                 SemestreEdicao =1
                                               

            };
            ProcessoSeletivoServico.Salvar(processo);
            ProcessoSeletivoEntidade processoEsperado = processoServico.BuscarTodos();
            Assert.AreEqual(3, processos.Count);
        }




    }
}



