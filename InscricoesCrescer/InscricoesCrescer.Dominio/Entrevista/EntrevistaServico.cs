using System;
using System.Collections.Generic;

namespace InscricoesCrescer.Dominio.Entrevista
{
    public class EntrevistaServico
    {
        private IEntrevistaRepositorio entrevistaRepositorio;

        public EntrevistaServico(IEntrevistaRepositorio entrevistaRepositorio)
        {
            this.entrevistaRepositorio = entrevistaRepositorio;
        }

        public bool Salvar(EntrevistaEntidade entrevista)
        {
            if (entrevista.Id != 0 || entrevista.Id != null)
            {
                this.entrevistaRepositorio.Criar(entrevista);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<EntrevistaEntidade> BuscarTodos()
        {
            return entrevistaRepositorio.BuscarTodos();
        }

        public List<EntrevistaEntidade> BuscarPorId(int id)
        {
            return entrevistaRepositorio.BuscarPorId(id);
        }
    }
}
