using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCampania
    {
        public static void AgregarC(Campania pCampania)
        {
            if (pCampania is CExterna)
            {
                PersistenciaCExterna.AgregarCExterna((CExterna)pCampania);
            }
            else
                PersistenciaCPropia.AgregarCPropia((CPropia)pCampania);
        }

        public static Campania BuscarC(int cIdCam)
        {
            Campania c = null;
            c = (Campania)PersistenciaCExterna.BuscarCampExterna(cIdCam);
            if (c == null)
            {
                c = (Campania)PersistenciaCPropia.BuscarCampPropia(cIdCam);
            }
            return c;
        }

        public static void ModificarC(Campania pCampania, int IdCamp)
        {
            if (pCampania is CExterna)
            {
                PersistenciaCExterna.Modificar((CExterna)pCampania, IdCamp);
            }
            else
            {
                PersistenciaCPropia.Modificar((CPropia)pCampania, IdCamp);
            }
        }

        public static void EliminarC(Campania pCampania)
        {
            PersistenciaCampania.EliminarCamp(pCampania);
        }

        public static List<Campania> ListarCampanias()
        {
            List<Campania> oAux = PersistenciaCPropia.ListarCampaniasPropias();
            oAux.AddRange(PersistenciaCExterna.ListarCampaniasExternas());

            return oAux;
        }

        public static double PrecioCampanias(Campania pCampania)
        {
            List<Emision> Emisiones = PersistenciaEmision.ListarEmisiones(pCampania);
            double precio = 0;
            foreach (Emision emision in Emisiones)
            {
                precio += emision.UnPrograma.PreXSegProg * emision.UnaCampania.Duracion;
            }
            if(pCampania is CPropia)
                precio += ((CPropia)pCampania).Costo;
            return precio;
        }
    }
}
