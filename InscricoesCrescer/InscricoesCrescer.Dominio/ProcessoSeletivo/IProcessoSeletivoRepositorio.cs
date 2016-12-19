using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.ProcessoSeletivo
{
    public interface IProcessoSeletivoRepositorio
    {
        void AbrirProcessoSeletivo(ProcessoSeletivoEntidade processo);
        
        void EditarProcessoSeletivo(ProcessoSeletivoEntidade processo);

        List<ProcessoSeletivoEntidade> BuscarTodos();
        ProcessoSeletivoEntidade VerificarProcessoExiste(ProcessoSeletivoEntidade processoSeletivo);
    }
}
