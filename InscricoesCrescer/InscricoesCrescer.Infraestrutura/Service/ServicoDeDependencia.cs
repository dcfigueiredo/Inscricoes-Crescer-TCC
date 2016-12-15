using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Repositorio.Candidato;

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