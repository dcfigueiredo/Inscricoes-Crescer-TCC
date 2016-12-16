using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.Administrador
{
    public interface IAdministradorRepositorio
    {
        AdministradorEntidade BuscarPorEmail(string email);
    }
}
