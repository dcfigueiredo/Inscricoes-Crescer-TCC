using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.Login_Adm
{
    public class AdministradorEntidade
    {
        public long? Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
