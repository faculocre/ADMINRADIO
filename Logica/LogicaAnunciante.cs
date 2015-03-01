using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaAnunciante
    {
        public static void AgregarA(Anunciante pAnunciante)
        {
            PersistenciaAnunciante.AgregarAnun(pAnunciante);
        }

        public static void EliminarA(Anunciante pAnunciante)
        {
            PersistenciaAnunciante.EliminarAnun(pAnunciante);
        }

        public static Anunciante BuscarA(long pRutAn)
        {
            return PersistenciaAnunciante.BuscarAnun(pRutAn);
        }

        public static void ModificarA(Anunciante pAnunciante)
        {
            PersistenciaAnunciante.ModificarAnun(pAnunciante);
        }

        public static List<Anunciante> ListarAnunciantes()
        {
            return PersistenciaAnunciante.ListarAnunciantes();
        }
        
    }
}
