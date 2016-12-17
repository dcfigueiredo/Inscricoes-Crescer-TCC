using InscricoesCrescer.Dominio.Configuracao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Servico
{
    public class ServicoConfiguracao : IServicoConfiguracao
    {
        public int QuantidadeDeCandidatosPorPagina
        {
            get
            {
                int qtd = Convert.ToInt32(
                        ConfigurationManager.AppSettings["QuantidadeDeCandidatosPorPagina"]
                    );
                return qtd;
            }
        }
    }
}