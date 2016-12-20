using System;
using System.Collections.Generic;


namespace InscricoesCrescer.Dominio.ProcessoSeletivo
{
    public class ProcessoSeletivoServico
    {
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
            List<ProcessoSeletivoEntidade> processos = processoRepositorio.BuscarTodos();
            foreach (var item in processos)
            {
                if (item.AnoEdicao.Equals(processoSeletivo.AnoEdicao))
                {
                    if (item.SemestreEdicao.Equals(processoSeletivo.SemestreEdicao))
                    {
                        return true;
                    }
                }
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
