using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace EntidadesCompartidas
{
    public class Anunciante
    {
        //Atributos
        private long _Rut;
        private string _Nombre;
        private string _Direccion;
        private List<string> _Telefono;

        //Propiedades
        public long Rut
        {
            get { return _Rut; }
            set
            {
                if (value <= 0)
                    throw new Exception("No ingreso rut valido");
                else
                    _Rut = value;
            }
        }

        public string Nombre
        {
            set
            {
                if (value == "")
                    throw new Exception("No ingreso ningun nombre");
                else
                    _Nombre = value;
            }
            get { return _Nombre; }
        }

        public string Direccion
        {
            set
            {
                if (value == "")
                    throw new Exception("No ingreso ninguna direccion");
                else
                    _Direccion = value;
            }
            get { return _Direccion; }
        }

        
        public List<string> Telefono
        {
            set { _Telefono = value; }
            get { return _Telefono; }
        }
         

        //Constructores
        public Anunciante()
        {
            Rut = 0;
            Nombre = "";
            Direccion = "";
            Telefono = new List<string>(); ;
        }

        public Anunciante(long pRut, string pNombre, string pDireccion, List<string> pTelefono)
        {
            Rut = pRut;
            Nombre = pNombre;
            Direccion = pDireccion;
            Telefono = pTelefono;
        }

        //Operaciones
        public override string ToString()
        {
            return ("Rut: " + Rut + ", Nombre: " + Nombre + ", Direccion: " + Direccion + ", Telefono: " + Telefono);
        }
    }
}
