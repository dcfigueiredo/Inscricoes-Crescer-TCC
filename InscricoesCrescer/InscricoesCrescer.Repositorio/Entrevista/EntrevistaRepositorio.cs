using InscricoesCrescer.Dominio.Entrevista;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InscricoesCrescer.Repositorio.Entrevista
{
    public class EntrevistaRepositorio : IEntrevistaRepositorio
    {
        public void Criar(EntrevistaEntidade entrevista)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<EntrevistaEntidade>(entrevista).State = EntityState.Added;
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

        public List<EntrevistaEntidade> BuscarPorId(int id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Entrevista.Where(_ => _.Id == id).ToList(); ;
            }
        }
    }
}
