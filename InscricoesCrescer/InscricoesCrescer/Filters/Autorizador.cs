using InscricoesCrescer.Models;
using InscricoesCrescer.Servico;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InscricoesCrescer.Filters
{
    public class Autorizador : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            AdministradorModel administrador = ServicoDeAutenticacao.AdministradorLogado;

            if (administrador == null) return false;

            return true;
        }
    }
}