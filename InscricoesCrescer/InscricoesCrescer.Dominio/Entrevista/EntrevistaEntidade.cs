using System;

namespace InscricoesCrescer.Dominio.Entrevista
{
    public class EntrevistaEntidade
    {
        public long? Id { get; set; }

        public string EmailAdministrador { get; set; }

        public DateTime DataEntrevista { get; set; }

        public string ParecerRH { get; set; }

        public string ParecerTecnico { get; set; }

        public double ProvaG36 { get; set; }

        public double ProvaAC { get; set; }

        public double ProvaTecnica { get; set; }
    }
}
