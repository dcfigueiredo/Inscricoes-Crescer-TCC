using InscricoesCrescer.Dominio.Candidato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Repositorio.Candidato
{
    public class CandidatoRepositorio : ICandidatoRepositorio
    {
        public void salvar(CandidatoEntidade candidato)
        {
            using (var context = new ContextoDeDados())
            {
                if (candidato.Id == 0)
                {
                    context.Entry<CandidatoEntidade>(candidato).State = EntityState.Added;
                    context.SaveChanges();
                }

                else
                {
                    context.Entry<CandidatoEntidade>(candidato).State = EntityState.Modified;
                }
            }
        }
    }
}
