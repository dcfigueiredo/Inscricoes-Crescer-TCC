using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Infraestrutura.Service;
using InscricoesCrescer.Repositorio.Administrador;
using System.Linq;

namespace InscricoesCrescer.Infraestrutura.Administrador
{
    public class ServicoAdministrador
    {
        private static AdministradorEntidade[] _adms = new AdministradorRepositorio().buscarAdministrador();

            public static AdministradorEntidade BuscarAdministradorAutenticado(string email, string senha)
            {
                AdministradorEntidade admEncontrado = _adms.FirstOrDefault(adm => adm.Email.Equals(email));

                string senhaDeComparacao = ServicoCriptografia.Criptografar(senha);

                if (admEncontrado != null && admEncontrado.Senha.Equals(senhaDeComparacao))
                {
                    return admEncontrado;
                }

                return null;
            }
        

    }
}
