using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.ProcessoSeletivo
{
    public class ProcessoSeletivoServico
    {
        private IProcessoSeletivoRepositorio processoRepositorio;

        public ProcessoSeletivoServico(IProcessoSeletivoRepositorio processoRepositorio)
        {
            this.processoRepositorio = processoRepositorio;
        }




        public void Salvar(ProcessoSeletivoEntidade processo)
        {
            this.processoRepositorio.AbrirProcessoSeletivo(processo);
        }


        /*
        

        public void Salvar(CandidatoEntidade candidato)
        {
            if (candidato.Id == 0 || candidato.Id == null)
            {
                this.candidatoRepositorio.Criar(candidato);
            }
            else
            {
                this.candidatoRepositorio.Editar(candidato);
            }
        }
         */







        //private int verificarDataEdicao()
        //{
        //    //TO DO:
        //    //fazer um servico que busque estes dados para mim do banco!

        //    if (semestreDoRegistroAnterior == 1)
        //    {
        //        anoDoNovoRegistro = anodoRegistroAnterior;
        //        semestreDoNovoRegistro = semestreDoRegistroAnterior + 1;
        //    }
        //    else
        //    {
        //        anoDoNovoRegistro = anoDoRegistroAnterior + 1;
        //        semestreDoNovoRegistro = 1;
        //    }
        //}



    }
}
