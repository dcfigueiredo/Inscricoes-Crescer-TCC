using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscricoesCrescer.Models
{

    //criar e importar servico
    public class ProcessoSeletivoViewModel
    {
        public long? Id { get; set; }

        public DateTime DataInicioEntrevistas { get; set; }
        public DateTime DataSelecaoFinal { get; set; }
        public DateTime DataInicioAulas { get; set; }
        public DateTime DataFinalAulas { get; set; }
        public DateTime AnoEdicao { get; set; }
        public DateTime SemestreEdicao { get; set; }


        //private int verificarDataEdicao()
        //{
        //    //TO DO:
        //    //fazer um servico que busque estes dados para mim do banco!

        //    if (semestreDoRegistroAnterior == 1)
        //    {
        //        anoDoNovoRegistro = anodoRegistroAnterior;
        //        semestreDoNovoRegistro = semestreDoRegistroAnterior + 1;
        //    }
        //    else
        //    {
        //        anoDoNovoRegistro = anoDoRegistroAnterior + 1;
        //        semestreDoNovoRegistro = 1;
        //    }
        //}
    }
}