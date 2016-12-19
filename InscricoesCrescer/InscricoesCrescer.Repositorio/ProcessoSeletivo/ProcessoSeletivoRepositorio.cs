using InscricoesCrescer.Dominio.ProcessoSeletivo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Repositorio.ProcessoSeletivo
{
    public class ProcessoSeletivoRepositorio : IProcessoSeletivoRepositorio
    {
        public void AbrirProcessoSeletivo(ProcessoSeletivoEntidade processo)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<ProcessoSeletivoEntidade>(processo).State = EntityState.Added;
                context.SaveChanges();
            }
        }


        public void EditarProcessoSeletivo(ProcessoSeletivoEntidade processo)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<ProcessoSeletivoEntidade>(processo).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Dominio.ProcessoSeletivo.ProcessoSeletivoEntidade> BuscarTodos()
        {
            using (var context = new ContextoDeDados())
            {
                return context.ProcessoSeletivo.OrderBy(_ => _.AnoEdicao).ToList();
            }
        }

        public ProcessoSeletivoEntidade VerificarProcessoExiste(ProcessoSeletivoEntidade processoSeletivo)
        {
            using (var context = new ContextoDeDados())
            {
                return context.ProcessoSeletivo.FirstOrDefault(_ => _.AnoEdicao == processoSeletivo.AnoEdicao
                                                      && _.SemestreEdicao == processoSeletivo.SemestreEdicao);
            }
        }
    }
}
