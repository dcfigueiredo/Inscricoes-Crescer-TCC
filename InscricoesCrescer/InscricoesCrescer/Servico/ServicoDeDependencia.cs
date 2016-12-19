using System;
using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Dominio.Entrevista;
using InscricoesCrescer.Infraestrutura.Service;
using InscricoesCrescer.Repositorio.Administrador;
using InscricoesCrescer.Repositorio.Candidato;
using InscricoesCrescer.Repositorio.Entrevista;

namespace InscricoesCrescer.Servico
{
    public class ServicoDeDependencia
    {
        public static CandidatoServico MontarCandidatoServico()
        {
            CandidatoServico candidatoServico = new CandidatoServico(new CandidatoRepositorio(), new ServicoConfiguracao());
            return candidatoServico;
        }

        public static AdministradorServico MontarAdministradorServico()
        {
            AdministradorServico administradorServico = new AdministradorServico(new AdministradorRepositorio(), new ServicoCriptografia());
            return administradorServico;
        }

        internal static EntrevistaServico MontarEntrevistaServico()
        {
            EntrevistaServico entrevistaServico = new EntrevistaServico(new EntrevistaRepositorio());
            return entrevistaServico;
        }

        public static ServicoConfiguracao MontarServicoConfiguracao()
        {
            return new ServicoConfiguracao();
        }
    }
}