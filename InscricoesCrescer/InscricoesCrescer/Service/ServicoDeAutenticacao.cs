
using InscricoesCrescer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Service
{
    public class ServicoDeAutenticacao
    {
        private const string USUARIO_LOGADO_CHAVE = "USUARIO_LOGADO_CHAVE";
        public static void Autenticar(AdministradorModel model)
        {
            HttpContext.Current.Session[USUARIO_LOGADO_CHAVE] = model;
        }

        public static AdministradorModel UsuarioLogado
        {
            get
            {
                return (AdministradorModel)HttpContext.Current.Session[USUARIO_LOGADO_CHAVE];
            }
        }
    }
}