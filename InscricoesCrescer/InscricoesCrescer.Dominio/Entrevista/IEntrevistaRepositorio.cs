using InscricoesCrescer.Dominio.Candidato;
using System.Collections.Generic;

namespace InscricoesCrescer.Dominio.Entrevista
{
    public interface IEntrevistaRepositorio
    {

        List<EntrevistaEntidade> BuscarTodos();        

        EntrevistaEntidade BuscarPorId(long id);

        void Criar(EntrevistaEntidade entrevista);

        void Editar(EntrevistaEntidade entrevista);
    }
}
