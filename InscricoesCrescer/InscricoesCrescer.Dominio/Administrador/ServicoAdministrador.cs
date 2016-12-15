using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.Administrador
{
    public class ServicoAdministrador
    {
        public class ServicoDeUsuario
        {
            private static AdministradorEntidade[] _adms =
           {
            new AdministradorEntidade()
            {
                Email = "carolina.leite@cwi.com.br",
                Senha = "72246a48199d94eb680fd6e0d802312e"
            }
        };

            public static AdministradorEntidade BuscarUsuarioAutenticado(string email, string senha)
            {
                AdministradorEntidade admEncontrado = _adms.FirstOrDefault(
                    adm => adm.Email.Equals(email));

                string senhaDeComparacao = ServicoCriptografia.ConverterParaMD5($"{email}_$_{senha}");

                if (admEncontrado != null && admEncontrado.Senha.Equals(senhaDeComparacao))
                {
                    return admEncontrado;
                }

                return null;
            }
        }

    }
}
