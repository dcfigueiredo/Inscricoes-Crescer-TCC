using InscricoesCrescer.Dominio.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Mock.Administrador
{
    public class AdministradorRepositorioMock : IAdministradorRepositorio
    {
        private static IList<Dominio.Administrador.AdministradorEntidade> candidatos = new List<Dominio.Administrador.AdministradorEntidade>()
        {
            new Dominio.Administrador.AdministradorEntidade()
            {
                Id = 1,
                Email = "annaluisa1703@gmail.com",
                Senha = "202cb962ac59075b964b07152d234b70"
            },
            new Dominio.Administrador.AdministradorEntidade()
            {
                Id = 2,
                Email = "daniel.carvalho.figueiredo@gmail.com",
                Senha = "202cb962ac59075b964b07152d234b70"
            },
            new Dominio.Administrador.AdministradorEntidade()
            {
                Id = 3,
                Email = "rodrigo.scheuer@hotmail.com",
                Senha = "202cb962ac59075b964b07152d234b70"
            }
        };

        public AdministradorEntidade BuscarPorEmail(string email)
        {
            return candidatos.FirstOrDefault(_ => _.Email.Equals(email));
        }
    }
}
