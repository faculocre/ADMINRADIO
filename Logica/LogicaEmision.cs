using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaEmision
    {
        public static void AgregarE(Emision pEmision)
        {
            PersistenciaEmision.AgregarEmision(pEmision);
        }
    }
}
