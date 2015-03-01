using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace EntidadesCompartidas
{
    public class CExterna : Campania
    {
        //Atributos
        private string _Productora;

        //Propiedades
        public string Productora
        {
            set
            {
                if (value == "")
                    throw new Exception("Error, ingrese la agencia correctamente");
                else
                    _Productora = value;
            }
            get { return _Productora; }
        }

        //Constructores
        public CExterna()
            : base()
        {
            Productora = "";
        }

        public CExterna(int pId, string pTitulo, DateTime pFechaI, DateTime pFechaF, int pDuracion, int pMenciones, Anunciante pAnunciante, string pProductora)
            : base(pId, pTitulo, pFechaI, pFechaF, pDuracion, pMenciones, pAnunciante)
        {
            Productora = pProductora;
        }

        //Operaciones
        public override string ToString()
        {
            return base.ToString() + ", Productora: " + Productora + ", Precio: " + PrecioCampania();
        }

        public override double PrecioCampania()
        {
            throw new Exception("Hay que programarlo");
        }
    }
}
