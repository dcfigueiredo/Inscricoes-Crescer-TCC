using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.ProcessoSeletivo
{
    public class ProcessoSeletivoEntidade
    {
        public long? Id { get; set; }
        public DateTime DataInicioEntrevistas { get; set; }
        public DateTime DataSelecaoFinal { get; set; }
        public DateTime DataInicioAulas { get; set; }
        public DateTime DataFinalAulas { get; set; }
        public int AnoEdicao { get; set; }
        public int SemestreEdicao { get; set; }
    
    }
}