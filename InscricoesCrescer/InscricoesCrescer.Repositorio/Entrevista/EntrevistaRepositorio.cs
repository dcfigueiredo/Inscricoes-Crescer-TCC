using InscricoesCrescer.Dominio.Entrevista;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;
using InscricoesCrescer.Dominio.Candidato;

namespace InscricoesCrescer.Repositorio.Entrevista
{
    public class EntrevistaRepositorio : IEntrevistaRepositorio
    {
        public void Criar(EntrevistaEntidade entrevista)
        {
            using (var context = new ContextoDeDados())
            {
                context.Candidato.Attach(entrevista.Candidato);
                context.Entry<EntrevistaEntidade>(entrevista).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Editar(EntrevistaEntidade entrevista)
        {
            using (var context = new ContextoDeDados())
            {
                context.Candidato.Attach(entrevista.Candidato);
                context.Entry<EntrevistaEntidade>(entrevista).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<EntrevistaEntidade> BuscarTodos()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Entrevista.OrderByDescending(_ => _.DataEntrevista).ToList();
            }
        }

        public EntrevistaEntidade BuscarPorId(long id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Entrevista.FirstOrDefault(_ => _.Id == id);
            }
        }
    }
}
