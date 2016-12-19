using System;
using System.Collections.Generic;


namespace InscricoesCrescer.Dominio.ProcessoSeletivo
{
    public class ProcessoSeletivoServico
    {
        private ProcessoSeletivoServico processoServico;

        private IProcessoSeletivoRepositorio processoRepositorio;
        
        public ProcessoSeletivoServico(IProcessoSeletivoRepositorio processoRepositorio)
        {
            this.processoRepositorio = processoRepositorio;
        }
        
        public List<ProcessoSeletivoEntidade> BuscarTodos()
        {
            return processoRepositorio.BuscarTodos();
        }

        public bool VerificarProcessoExiste(ProcessoSeletivoEntidade processoSeletivo)
        {
            ProcessoSeletivoEntidade processoProcurado = processoRepositorio.VerificarProcessoExiste(processoSeletivo);

            if (processoSeletivo != null)

            {
                return true;
            }

            return false;
        }

        public void Salvar(ProcessoSeletivoEntidade processo)
        {
            if (processo.Id == 0 || processo.Id == null)
            {
                this.processoRepositorio.AbrirProcessoSeletivo(processo);
            }
            else
            {
                this.processoRepositorio.EditarProcessoSeletivo(processo);
            }
        }



    }
}
