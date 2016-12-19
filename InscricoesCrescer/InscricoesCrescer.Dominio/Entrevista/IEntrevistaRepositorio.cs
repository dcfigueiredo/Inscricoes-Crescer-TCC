using System.Collections.Generic;

namespace InscricoesCrescer.Dominio.Entrevista
{
    public interface IEntrevistaRepositorio
    {
        void Criar(EntrevistaEntidade candidato);

        List<EntrevistaEntidade> BuscarTodos();
        List<EntrevistaEntidade> BuscarTodosComMesmoId(long id);
    }
}
