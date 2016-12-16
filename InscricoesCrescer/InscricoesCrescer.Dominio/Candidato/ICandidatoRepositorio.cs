using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.Candidato
{
    public interface ICandidatoRepositorio
    {
        void Criar(CandidatoEntidade candidato);

        void Editar(CandidatoEntidade candidato);

        CandidatoEntidade BuscarPorId(int id);

        List<CandidatoEntidade> BuscarTodos();

        CandidatoEntidade BuscarPorEmail(string email);
    }
}
