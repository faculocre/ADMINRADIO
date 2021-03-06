﻿using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Logica;
using EntidadesCompartidas;

public partial class ABMCampaniaPropia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //cargo la lista en la session
                Session["_listaAnun"] = LogicaAnunciante.ListarAnunciantes();

                //verifico si hay Anunciantes, si no hay me voy
                if (((List<Anunciante>)Session["_listaAnun"]).Count == 0)
                    Response.Redirect("~/Default.aspx");

                //cargo el DropDownList
                DDLAnunciante.DataSource = (List<Anunciante>)Session["_listaAnun"];
                DDLAnunciante.DataTextField = "Nombre";
                DDLAnunciante.DataValueField = "Nombre";
                DDLAnunciante.DataBind();
                //Cargo el id con 0 para facilitar el Agregar
                TxtId.Text = "0";
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }

    public void LimpioForm()
    {
        TxtId.Text = "0";
        TxtNombre.Text = "";
        TxtMenciones.Text = "";
        TxtCosto.Text = "";
        TxtDuracion.Text = "";
        TxtId.Enabled = true;
        DDLAnunciante.SelectedIndex = 0;
        CalendarioFI.SelectedDate = DateTime.Now;
        CalendarioFI.VisibleDate = DateTime.Now;
        CalendarioFF.SelectedDate = DateTime.Now;
        CalendarioFF.VisibleDate = DateTime.Now;
    }

    public void DesactivoBotones()
    {
        BtnBuscar.Enabled = true;
        BtnAgregar.Enabled = false;
        BtnEliminar.Enabled = false;
        BtnModificar.Enabled = false;
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        int Id = 0;
        try
        {
            Id = Convert.ToInt32(TxtId.Text);
        }
        catch
        {
            LblError.Text = "ID incorrecto";
            return;
        }
        try
        {
            LblError.Text = "";
            Campania camp = LogicaCampania.BuscarC(Id);
            if (camp != null)
            {
                if (camp is CPropia)//chequeo si la Campania es propia, sino salgo.
                {
                    TxtId.Text = Convert.ToString(camp.Id);
                    TxtNombre.Text = camp.Titulo;
                    DDLAnunciante.SelectedValue = camp.unAnunciante.Nombre;
                    CalendarioFI.SelectedDate = camp.FechaI;
                    CalendarioFI.VisibleDate = camp.FechaI;
                    CalendarioFF.SelectedDate = camp.FechaF;
                    CalendarioFF.VisibleDate = camp.FechaF;
                    TxtMenciones.Text = camp.Menciones.ToString();
                    TxtCosto.Text = ((CPropia)camp).Costo.ToString();
                    TxtDuracion.Text = camp.Duracion.ToString();
                    
                    Session["UnaCampPropia"] = camp;
                    BtnEliminar.Enabled = true;
                    BtnModificar.Enabled = true;
                    BtnBuscar.Enabled = false;
                    TxtId.Enabled = false;
                }
                else
                {
                    LblError.Text = "La Campania es Externa";
                }
            }
            else
            {
                LblError.Text = "La Campania no existe";
                BtnAgregar.Enabled = true;
                BtnEliminar.Enabled = false;
                BtnModificar.Enabled = false;
                BtnBuscar.Enabled = false;
                TxtId.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        int Id = 0;
        int Menciones = 0;
        double CostoProd = 0;
        int DurSpot = 0;
        //Capturo los Datos para construir la Campania
        try
        {
            Id = Convert.ToInt32(TxtId.Text);
        }
        catch
        {
            LblError.Text = "ID incorrecto";
        }
        string Nombre = TxtNombre.Text;
        Anunciante Anun = ((List<Anunciante>)Session["_listaAnun"])[DDLAnunciante.SelectedIndex];
        DateTime FInicio = CalendarioFI.SelectedDate;
        DateTime FFinal = CalendarioFF.SelectedDate;
        try
        {
            Menciones = Convert.ToInt32(TxtMenciones.Text);
        }
        catch
        {
            oMensaje = "Debe ingresar un numero de Menciones diarias";
        }
        try
        {
            CostoProd = Convert.ToDouble(TxtCosto.Text);
        }
        catch
        {
            oMensaje = "Debe ingresar un numero de Costo de Producción";
        }
        try
        {
            DurSpot = Convert.ToInt32(TxtDuracion.Text);
        }
        catch
        {
            oMensaje = "Debe ingresar un numero de Duración del Spot";
        }

        if (oMensaje != "")
            LblError.Text = oMensaje;
        //Intento Crear la Campania
        else
        {
            
            try
            {
                CPropia Cp = new CPropia(Id, Nombre, FInicio, FFinal, DurSpot, Menciones, Anun, CostoProd);
                LogicaCampania.AgregarC(Cp);
                LblError.Text = "Alta con Exito";
                this.LimpioForm();
                this.DesactivoBotones();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }

    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            CPropia Cp = (CPropia)Session["UnaCampPropia"];
            LogicaCampania.EliminarC(Cp);
            LblError.Text = "Eliminacion Exitosa";

            this.LimpioForm();
            this.DesactivoBotones();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        int Id = 0;
        int Menciones = 0;
        double CostoProd = 0;
        int DurSpot = 0;
        //Capturo los Datos para construir la Campania
        try
        {
            Id = Convert.ToInt32(TxtId.Text);
        }
        catch
        {
            LblError.Text = "ID incorrecto";
        }
        string Nombre = TxtNombre.Text;

        Anunciante Anun = ((List<Anunciante>)Session["_listaAnun"])[DDLAnunciante.SelectedIndex];
        DateTime FInicio = CalendarioFI.SelectedDate;
        DateTime FFinal = CalendarioFF.SelectedDate;
        try
        {
            Menciones = Convert.ToInt32(TxtMenciones.Text);
        }
        catch
        {
            oMensaje = "Debe ingresar un numero de Menciones diarias";
        }
        try
        {
            CostoProd = Convert.ToDouble(TxtCosto.Text);
        }
        catch
        {
            oMensaje = "Debe ingresar un numero de Costo de Producción";
        }
        try
        {
            DurSpot = Convert.ToInt32(TxtDuracion.Text);
        }
        catch
        {
            oMensaje = "Debe ingresar un numero de Duración del Spot";
        }

        if (oMensaje != "")
            LblError.Text = oMensaje;
        //Intento Crear la Campania
        else
        {
            try
            {
                CPropia Cp = (CPropia)Session["UnaCampPropia"];
                Cp.Id = Id;
                Cp.Titulo = Nombre;
                Cp.unAnunciante = Anun;
                Cp.FechaI = FInicio;
                Cp.FechaF = FFinal;
                Cp.Menciones = Menciones;
                Cp.Costo = CostoProd;
                Cp.Duracion = DurSpot;

                LogicaCampania.ModificarC(Cp, Id);
                LblError.Text = "Modificacion Exitosa";
                this.LimpioForm();
                this.DesactivoBotones();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }

    protected void BtnDeshacer_Click(object sender, EventArgs e)
    {
        this.LimpioForm();
        this.DesactivoBotones();
        LblError.Text = "";
    }
}
