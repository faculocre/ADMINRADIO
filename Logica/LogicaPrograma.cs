using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPrograma
    {
        public static void AgregarP(Programa pPrograma)
        {
            PersistenciaPrograma.AgregarProg(pPrograma);
        }

        public static void EliminarP(Programa pPrograma)
        {
            PersistenciaPrograma.EliminarProg(pPrograma);
        }

        public static Programa BuscarP(string pNomProg)
        {
            return PersistenciaPrograma.BuscarProg(pNomProg);
        }

        public static void ModificarP(Programa pPrograma)
        {
            PersistenciaPrograma.ModificarProg(pPrograma);
        }

        public static List<Programa> ListarProgramas()
        {
            return PersistenciaPrograma.ListarProgramas();
        }
    }
}
