using InscricoesCrescer.Dominio.Administrador;
using System.Web;

namespace InscricoesCrescer.Servico
{
    public class ServicoDeAutenticacao
    {
        private const string USUARIO_LOGADO_CHAVE = "USUARIO_LOGADO_CHAVE";

        public static void Autenticar(AdministradorEntidade model)
        {
            HttpContext.Current.Session[USUARIO_LOGADO_CHAVE] = model;
        }

        public static AdministradorEntidade AdministradorLogado
        {
            get
            {
                return (AdministradorEntidade)HttpContext.Current.Session[USUARIO_LOGADO_CHAVE];
            }
        }
    }
}


