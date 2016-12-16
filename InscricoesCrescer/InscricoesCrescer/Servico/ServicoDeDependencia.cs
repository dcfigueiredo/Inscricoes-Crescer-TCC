using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Infraestrutura.Service;
using InscricoesCrescer.Repositorio.Administrador;
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

        public static AdministradorServico MontarAdministradorServico()
        {
            AdministradorServico administradorServico = new AdministradorServico(new AdministradorRepositorio(), new ServicoCriptografia());
            return administradorServico;
        }
    }
}