using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.Email
{
    public interface IServicoEmail
    {
        bool enviarEmailConfirmacao(string para);
    }
}
