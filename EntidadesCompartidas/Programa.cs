using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Programa
    {
        //Atributos
        private string _NomProg;
        private string _ProdProg;
        private string _TipoProg;
        private int _PreXSegProg;

        //Propiedaes
        public string NomProg
        {
            set
            {
                if (value == "")
                    throw new Exception("No ingreso ningun Nombre");
                else
                    _NomProg = value;
            }
            get { return _NomProg; }
        }

        public string ProdProg
        {
            set
            {
                if (value == "")
                    throw new Exception("No ingreso ningun Productor");
                else
                    _ProdProg = value;
            }
            get { return _ProdProg; }
        }

        public string TipoProg
        {
            set
            {
                if ((value != "Musical") && (value != "Variedades") && (value != "Periodistico"))
                    throw new Exception("Tipo de programa incorrecto (debe ser Musical, Variedades o Periodistico)");
                else
                    _TipoProg = value;
            }
            get { return _TipoProg; }
        }

        public int PreXSegProg
        {
            set
            {
                if (value <= 0)
                    throw new Exception("El valor tiene que ser positivo");
                    
                else
                    _PreXSegProg = value;
            }
            get { return _PreXSegProg; }
        }


        //Constructores
        public Programa()
        {
            NomProg = "";
            ProdProg = "";
            TipoProg = "";
            PreXSegProg = 0;
        }

        public Programa(string pNomProg, string pProdProg, string pTipoProg, int pPreXSegProg)
        {
            NomProg = pNomProg;
            ProdProg = pProdProg;
            TipoProg = pTipoProg;
            PreXSegProg = pPreXSegProg;
        }

        public override string ToString()
        {
            return ("Nombre: " + NomProg + ", Produccion: " + ProdProg + ", Tipo: " + TipoProg + ", Precio por segundo: " + PreXSegProg);
        }
    }
}

