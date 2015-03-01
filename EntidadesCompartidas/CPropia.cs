using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace EntidadesCompartidas
{
    public class CPropia : Campania
    {
        //Atributos
        private double _Costo;

        //Propiedades
        public double Costo
        {
            set
            {
                if (value < 0)
                    throw new Exception("Error, el costo tiene que ser mayor a 0");
                else
                    _Costo = value;
            }
            get { return _Costo; }
        }

        //Constructores
        public CPropia()
            : base()
        {
            Costo = 0;
        }

        public CPropia(int pId, string pTitulo, DateTime pFechaI, DateTime pFechaF, int pDuracion, int pMenciones, Anunciante pAnunciante, double pCosto)
            : base(pId, pTitulo, pFechaI, pFechaF, pDuracion, pMenciones, pAnunciante)
        {
            Costo = pCosto;
        }

        //Operaciones
        public override string ToString()
        {
            return base.ToString() + ", Costo: " + Costo + ", Precio: " + PrecioCampania();
        }

        public override double PrecioCampania()
        {
            throw new Exception("Hay que programarlo");
        }
    }  
}
