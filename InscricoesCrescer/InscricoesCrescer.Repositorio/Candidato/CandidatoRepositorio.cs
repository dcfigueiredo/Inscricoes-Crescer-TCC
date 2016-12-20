using InscricoesCrescer.Dominio.Candidato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InscricoesCrescer.Dominio.Configuracao;

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

        public void Criar(Dominio.Candidato.CandidatoEntidade candidato)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<CandidatoEntidade>(candidato).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Editar(Dominio.Candidato.CandidatoEntidade candidato)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<CandidatoEntidade>(candidato).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Dominio.Candidato.CandidatoEntidade> BuscarTodos()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Candidato.OrderBy(_ => _.Nome).ToList();
            }
        }

        public CandidatoEntidade BuscarPorEmail(string email)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Candidato.FirstOrDefault(_ => _.Email == email);
            }
        }

        public IList<Dominio.Candidato.CandidatoEntidade> BuscarCandidatos(Paginacao paginacao)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Candidato.OrderBy(_ => _.Id).Skip(paginacao.Pagina * paginacao.QuantidadeDeItensPorPagina)
                                        .Take(paginacao.QuantidadeDeItensPorPagina).Where(_ => _.Nome.Contains(paginacao.Filtro))
                                        .ToList();
            }
        }

        public List<CandidatoEntidade> buscarStatusInteresse()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Candidato.Where(_ => _.Status.Contains("Interesse")).ToList();
            }
        }
    }
}
