﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InscricoesCrescer.Dominio.Candidato
{
    public interface ICandidatoRepositorio
    {
        void salvar(CandidatoEntidade candidato);
    }
}
