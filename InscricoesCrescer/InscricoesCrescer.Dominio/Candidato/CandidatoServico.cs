
using System;
using System.Collections.Generic;


namespace InscricoesCrescer.Dominio.Candidato
{
    public class CandidatoServico
    {
        private ICandidatoRepositorio candidatoRepositorio;

        public CandidatoServico(ICandidatoRepositorio candidatoRepositorio)
        {
            this.candidatoRepositorio = candidatoRepositorio;
        }

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

        public CandidatoEntidade BuscarCandidatoPorID(int id)
        {
            return this.candidatoRepositorio.BuscarPorId(id);
        }

        public List<CandidatoEntidade> BuscarTodos()
        {
            return candidatoRepositorio.BuscarTodos();
        }

        public CandidatoEntidade BuscarPorEmail(string email)
        {
            return candidatoRepositorio.BuscarPorEmail(email);
        }
    }
}
