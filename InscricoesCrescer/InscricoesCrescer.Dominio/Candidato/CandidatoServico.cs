
using InscricoesCrescer.Dominio.Configuracao;
using System;
using System.Collections.Generic;


namespace InscricoesCrescer.Dominio.Candidato
{
    public class CandidatoServico
    {
        private ICandidatoRepositorio candidatoRepositorio;
        private IServicoConfiguracao servicoConfiguracao;

        public CandidatoServico(ICandidatoRepositorio candidatoRepositorio, IServicoConfiguracao servicoConfiguracao)
        {
            this.candidatoRepositorio = candidatoRepositorio;
            this.servicoConfiguracao = servicoConfiguracao;
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

        public IList<CandidatoEntidade> BuscarCandidatos(int pagina, string filtro)
        {
            int quantidadeDeCandidatosPorPagina = this.servicoConfiguracao.QuantidadeDeCandidatosPorPagina;

            var paginacao = new Paginacao() {
                Pagina = pagina,
                QuantidadeDeItensPorPagina = quantidadeDeCandidatosPorPagina,
                Filtro = filtro == null ? "" : filtro
            };

            return this.candidatoRepositorio.BuscarCandidatos(paginacao);
        }

        public CandidatoEntidade BuscarPorEmail(string email)
        {
            return candidatoRepositorio.BuscarPorEmail(email);
        }

        public List<CandidatoEntidade> BuscarInteressados()
        {
            return candidatoRepositorio.buscarStatusInteresse();
        }
    }
}
