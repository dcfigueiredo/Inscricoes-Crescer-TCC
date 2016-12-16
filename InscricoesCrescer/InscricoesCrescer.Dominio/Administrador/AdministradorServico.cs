using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.Administrador
{
    public class AdministradorServico
    {
        private IAdministradorRepositorio administradorRepositorio;
        private IServicoCriptografia servicoCriptografia;

        public AdministradorServico(IAdministradorRepositorio administradorRepositorio, IServicoCriptografia servicoCriptografia)
        {
            this.administradorRepositorio = administradorRepositorio;
            this.servicoCriptografia = servicoCriptografia;
        }

        public AdministradorEntidade BuscarPorAutenticacao(string email, string senha)
        {
            AdministradorEntidade administradorEncontrado = this.administradorRepositorio.BuscarPorEmail(email);

            string senhaCriptografada = this.servicoCriptografia.Criptografar(senha);

            if (administradorEncontrado != null && administradorEncontrado.Senha.Equals(senhaCriptografada))
            {
                return administradorEncontrado;
            }
            return null;
        }
    }
}
