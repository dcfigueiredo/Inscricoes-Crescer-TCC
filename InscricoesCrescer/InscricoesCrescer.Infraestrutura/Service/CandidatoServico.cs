using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
             
    }
}
