using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Models;
using System.Web;

namespace InscricoesCrescer.Servico
{
    public class ServicoDeAutenticacao
    {
        private const string USUARIO_LOGADO_CHAVE = "USUARIO_LOGADO_CHAVE";

        public static void Autenticar(AdministradorModel model)
        {
            HttpContext.Current.Session[USUARIO_LOGADO_CHAVE] = model;
        }

        public static AdministradorModel AdministradorLogado
        {
            get
            {
                return (AdministradorModel)HttpContext.Current.Session[USUARIO_LOGADO_CHAVE];
            }
        }
    }
}


