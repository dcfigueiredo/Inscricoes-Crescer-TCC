using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Repositorio.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Servico
{
    public class ServicoDeDependencia
    {
        public static CandidatoServico MontarCandidatoServico()
        {
            CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorio());
            return candidatoServico;
        }
    }
}