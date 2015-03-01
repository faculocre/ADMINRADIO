using System;
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

public partial class ABMAnunciantes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        long Rut = 0;
        try
        {
            Rut = Convert.ToInt64(TxtRut.Text);
        }
        catch
        {
            LblError.Text = "Rut incorrecto";
            return;
        }
        try
        {
            LblError.Text = "";
            Anunciante anun = LogicaAnunciante.BuscarA(Rut);
            if (anun != null)
            {
                TxtRut.Text = Convert.ToString(anun.Rut);
                TxtNombre.Text = anun.Nombre;
                TxtDireccion.Text = anun.Direccion;
                foreach (string Tel in anun.Telefono)
                {
                    LstTelefonos.Items.Add(Tel);
                }
                Session["UnAnunciante"] = anun;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
                BtnBuscar.Enabled = false;
                BtnNuevoTelefono.Enabled = true;
                BtnBorrarTelefono.Enabled = true;
                BtnAgregar.Enabled = false;
                TxtRut.Enabled = false;
            }
            else
            {
                LblError.Text = "El anunciante no existe";
                BtnAgregar.Enabled = true;
                BtnEliminar.Enabled = false;
                BtnModificar.Enabled = false;
                BtnNuevoTelefono.Enabled = true;
                BtnBorrarTelefono.Enabled = true;
                //BtnBuscar.Enabled = false;
                //TxtRut.Enabled = false;
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
        long Rut = 0;
        string Nombre = TxtNombre.Text;
        string Direccion = TxtDireccion.Text;

         List<string> ListaTelAn = new List<string>();
 
        foreach(ListItem l in LstTelefonos.Items)
        {
            ListaTelAn.Add(l.Text);
        }

        try
        {
            Rut = Convert.ToInt64(TxtRut.Text);
        }
        catch
        {
            oMensaje = "Rut incorrecto";
        }

        if (oMensaje != "")
            LblError.Text = oMensaje;
        else
        {
            try
            {
                Anunciante a = new Anunciante(Rut, Nombre, Direccion, ListaTelAn);
                LogicaAnunciante.AgregarA(a);
                LblError.Text = "Alta con Exito";
                TxtRut.Text = "";
                TxtNombre.Text = "";
                TxtDireccion.Text = "";
                LstTelefonos.Items.Clear();
                BtnAgregar.Enabled = false;
                BtnBuscar.Enabled = true;
                TxtRut.Enabled = true;
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
            Anunciante a = (Anunciante)Session["UnAnunciante"];
            LogicaAnunciante.EliminarA(a);
            LstTelefonos.Items.Clear();
            LblError.Text = "Eliminacion Exitosa";

            TxtRut.Text = "";
            TxtNombre.Text = "";
            TxtDireccion.Text = "";

            BtnBuscar.Enabled = true;
            BtnAgregar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            TxtRut.Enabled = true;
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        string Nombre = TxtNombre.Text;
        string Direccion = TxtDireccion.Text;
        List<string> ListaTelAn = new List<string>();
        long Rut = 0;

        try
        {
            Rut = Convert.ToInt64(TxtRut.Text);
        }
        catch
        {
            oMensaje = "El Rut debe ser con numeros";
        }

        foreach (ListItem l in LstTelefonos.Items)
        {
            ListaTelAn.Add(l.Text);
        }
        if (oMensaje != "")
            LblError.Text = oMensaje;
        else
        {
            try
            {
                Anunciante a = (Anunciante)Session["UnAnunciante"];
                a.Rut = Rut;
                a.Nombre = Nombre;
                a.Direccion = Direccion;
                a.Telefono = ListaTelAn;

                LogicaAnunciante.ModificarA(a);
                LblError.Text = "Modificacion Exitosa";
                TxtRut.Text = "";
                TxtNombre.Text = "";
                TxtDireccion.Text = "";
                LstTelefonos.Items.Clear();
                BtnBuscar.Enabled = true;
                BtnAgregar.Enabled = false;
                BtnEliminar.Enabled = false;
                BtnModificar.Enabled = false;
                TxtRut.Enabled = true;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }

    protected void BtnDeshacer_Click(object sender, EventArgs e)
    {
        TxtRut.Text = "";
        TxtNombre.Text = "";
        TxtDireccion.Text = "";
        TxtTelefono.Text = "";
        LstTelefonos.Items.Clear();
        BtnBuscar.Enabled = true;
        BtnAgregar.Enabled = false;
        BtnEliminar.Enabled = false;
        BtnModificar.Enabled = false;
        BtnNuevoTelefono.Enabled = false;
        BtnBorrarTelefono.Enabled = false;
        TxtRut.Enabled = true;
        LblError.Text = "";
    }

    protected void BtnNuevoTelefono_Click(object sender, EventArgs e)
    {
        try
        {
            int Telefono = Convert.ToInt32(TxtTelefono.Text);
            string TelAn = TxtTelefono.Text;
            LstTelefonos.Items.Add(TelAn);
            TxtTelefono.Text = "";
            LblError.Text = "";
        }
        catch
        {
            LblError.Text = "Telefono invalido";
        }

    }
    protected void BtnBorrarTelefono_Click(object sender, EventArgs e)
    {
        try
        {
            if (LstTelefonos.SelectedItem != null)
            {               
                LstTelefonos.Items.RemoveAt(LstTelefonos.SelectedIndex);
                LblError.Text = "";
            }
            else
                LblError.Text = "No hay telefono seleccionado";

        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}
