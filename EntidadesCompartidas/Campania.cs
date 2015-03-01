using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace EntidadesCompartidas
{
    public abstract class Campania
    {

        //Atributos
        private int _Id;
        private string _Titulo;
        private DateTime _FechaI;
        private DateTime _FechaF;
        private int _Duracion;
        private int _Menciones;
        Anunciante _unAnunciante;

        //Propiedades
        public int Id
        {
            set
            {
                if (value < 0)
                    throw new Exception("El id no puede ser negativo");
                else
                    _Id = value;
            }
            get { return _Id; }
        }

        public string Titulo
        {
            set
            {
                if (value == "")
                    throw new Exception("Error, no existe ese titulo");
                else
                    _Titulo = value;
            }
            get { return _Titulo; }
        }

        public DateTime FechaI
        {
            set
            {
                if (value == null || value == new DateTime())
                    throw new Exception("Error, no selecciono la fecha inicial");
                else
                    _FechaI = value;
            }
            get { return _FechaI; }
        }

        public DateTime FechaF
        {
            set
            {
                if (value == null || value == new DateTime())
                    throw new Exception("Error, no selecciono la fecha final");
                else
                    _FechaF = value;
            }
            get { return _FechaF; }
        }

        public int Duracion
        {
            set
            {
                if (value < 0)
                    throw new Exception("Error, la duracion tiene que ser mayor a cero");
                else
                    _Duracion = value;
            }
            get { return _Duracion; }
        }

        public int Menciones
        {
            set
            {
                if (value < 0)
                    throw new Exception("Error, las menciones tiene que ser mayor a cero");
                else
                    _Menciones = value;
            }
            get { return _Menciones; }
        }

        public Anunciante unAnunciante
        {
            get { return _unAnunciante; }
            set { _unAnunciante = value; }
        }


        //Constructores
        public Campania()
        {
            Id = 0;
            Titulo = "";
            FechaI = new DateTime();
            FechaF = new DateTime();
            Duracion = 0;
            Menciones = 0;
            unAnunciante = null;
        }

        public Campania(int pId, string pTitulo, DateTime pFechaI, DateTime pFechaF, int pDuracion, int pMenciones, Anunciante pAnunciante)
        {
            Id = pId;
            Titulo = pTitulo;
            FechaI = pFechaI;
            FechaF = pFechaF;
            Duracion = pDuracion;
            Menciones = pMenciones;
            unAnunciante = pAnunciante;
        }

        //Operaciones

        public override string ToString()
        {
            return ("Id: " + Id + ", Titulo: " + Titulo + ", Fecha de inicio: " + FechaI + ", Fecha de finalizacion: " + FechaF + ", Duracion: " + Duracion + ", Menciones: " + Menciones + ", Nombre de Anunciante: " + this._unAnunciante.Nombre);
        }

        public int DiasDuracion()
        {
            TimeSpan cantidadD = FechaF.Subtract(FechaI);
            int diasD = cantidadD.Days;
            return diasD;
        }

        public abstract double PrecioCampania();
    }
}

