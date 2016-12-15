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
             
    }
}
