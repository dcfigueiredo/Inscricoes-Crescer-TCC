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
        public CandidatoEntidade BuscarPorId(int id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Candidato.FirstOrDefault(_ => _.Id == id);
            }
        }

        public void Criar(CandidatoEntidade candidato)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<CandidatoEntidade>(candidato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Editar(CandidatoEntidade candidato)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<CandidatoEntidade>(candidato).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
