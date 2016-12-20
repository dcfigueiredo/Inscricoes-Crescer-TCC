using InscricoesCrescer.Dominio.ProcessoSeletivo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Mock.ProcessoSeletivo
{
    public class ProcessoSeletivoRepositorioMock : IProcessoSeletivoRepositorio
    {
        private static IList<Dominio.ProcessoSeletivo.ProcessoSeletivoEntidade> processos = new List<Dominio.ProcessoSeletivo.ProcessoSeletivoEntidade>()
        {
            new Dominio.ProcessoSeletivo.ProcessoSeletivoEntidade()
            {
                Id = 1,
                DataInicioEntrevistas = new DateTime (2017,02,26),
                DataSelecaoFinal = new DateTime (2017,04,22),
                DataFinalAulas  =  new DateTime (2017,08,26),
                DataInicioAulas = new DateTime (2017,05,26),
                AnoEdicao = 2017,
                SemestreEdicao  = 1
            },

            new Dominio.ProcessoSeletivo.ProcessoSeletivoEntidade()
            {
                Id = 2,
                DataInicioEntrevistas = new DateTime (2017,06,10),
                DataSelecaoFinal = new DateTime (2017,08,28),
                DataFinalAulas  =  new DateTime (2017,12,26),
                DataInicioAulas = new DateTime (2017,09,26),
                AnoEdicao = 2017,
                SemestreEdicao  = 2
            },
        };

        public void AbrirProcessoSeletivo(Dominio.ProcessoSeletivo.ProcessoSeletivoEntidade processo)
        {
            processo.Id = 3;
            processos.Add(processo);

        }

        public List<ProcessoSeletivoEntidade> BuscarTodos()
        {
            return processos.OrderBy(_ => _.AnoEdicao).ToList();
        }
        

        public void EditarProcessoSeletivo(ProcessoSeletivoEntidade processo)
        {
            throw new NotImplementedException();
        }

        public ProcessoSeletivoEntidade VerificarProcessoExiste(ProcessoSeletivoEntidade processoSeletivo)
        {
            throw new NotImplementedException();
        }
    }
}

