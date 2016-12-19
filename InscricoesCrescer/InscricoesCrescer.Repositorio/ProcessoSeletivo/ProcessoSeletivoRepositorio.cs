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
    }
}
