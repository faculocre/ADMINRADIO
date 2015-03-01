using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Emision
    {
        //Atributos
        private DateTime _FEmision;
        private Campania _unaCampania;
        private Programa _unPrograma;

        //Propiedades
        public DateTime FEmision
        {
            set
            {
                if (value == null || value == new DateTime())
                    throw new Exception("Error, no selecciono ninguna fecha");
                else
                    _FEmision = value;
            }
            get { return _FEmision; }
        }

        public Campania UnaCampania
        {
            set { _unaCampania = value; }
            get { return _unaCampania; }
        }

        public Programa UnPrograma
        {
            set { _unPrograma = value; }
            get { return _unPrograma; }
        }

        //Constructores
        public Emision()
        {
            FEmision = new DateTime();
            UnaCampania = null;
            UnPrograma = null;
        }

        public Emision(DateTime pFEmision, Campania pUnaCampania, Programa pUnPrograma)
        {
            FEmision = pFEmision;
            UnaCampania = pUnaCampania;
            UnPrograma = pUnPrograma;
        }

        //Operaciones
        public override string ToString()
        {
            return ("Fecha emision: " + FEmision + ", Campania: " + this._unaCampania.Titulo + ", Programa: " + this._unPrograma.NomProg);
        }
    }
}
