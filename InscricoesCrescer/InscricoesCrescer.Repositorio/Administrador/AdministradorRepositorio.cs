using InscricoesCrescer.Dominio.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Repositorio.Administrador
{
    public class AdministradorRepositorio : IAdministradorRepositorio
    {
        public AdministradorEntidade BuscarPorEmail(string email)
        {
            using (var contexto = new ContextoDeDados())
            {
                return contexto.Administrador.FirstOrDefault(_ => _.Email.Equals(email));
            }
        }
    }
}
