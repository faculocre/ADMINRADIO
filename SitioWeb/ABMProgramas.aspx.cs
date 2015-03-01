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

public partial class ABMProgramas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {  
        string NomProg = TxtNomPgm.Text;
        try
        {
            LblError.Text = "";
            Programa pgm = LogicaPrograma.BuscarP(NomProg);
            if (pgm != null)
            {
                TxtNomPgm.Text = pgm.NomProg;
                TxtProductor.Text = pgm.ProdProg;
                TxtTipo.Text = pgm.TipoProg;
                TxtPrecioXSeg.Text = Convert.ToString(pgm.PreXSegProg);

                Session["UnPrograma"] = pgm;
                BtnEliminar.Enabled = true;
                BtnModificar.Enabled = true;
                BtnBuscar.Enabled = false;
                TxtNomPgm.Enabled = false;
            }
            else if (NomProg == "")
            {
                LblError.Text = "Debe ingresar un Nombre para el Programa";
            }
            else
            {
                LblError.Text = "El Programa no existe";
                BtnAgregar.Enabled = true;
                BtnEliminar.Enabled = false;
                BtnModificar.Enabled = false;
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
        string NomProg = TxtNomPgm.Text;
        string TipoProg = TxtTipo.Text;
        string ProdProg = TxtProductor.Text;
        int PreXSegProg = 0;

        try
        {
            PreXSegProg = Convert.ToInt32(TxtPrecioXSeg.Text);
        }
        catch
        {
            oMensaje = "Error al ingresar el Precio Por Segundo";
        }
        if (oMensaje != "")
            LblError.Text = oMensaje;
        else
        {
            try
            {
                Programa p = new Programa(NomProg, ProdProg, TipoProg, PreXSegProg);
                LogicaPrograma.AgregarP(p);
                LblError.Text = "Alta con Exito";
                TxtNomPgm.Text = "";
                TxtProductor.Text = "";
                TxtTipo.Text = "";
                TxtPrecioXSeg.Text = "";
                BtnAgregar.Enabled = false;
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
            Programa p = (Programa)Session["UnPrograma"];
            LogicaPrograma.EliminarP(p);
            LblError.Text = "Eliminacion Exitosa";
            TxtNomPgm.Text = "";
            TxtProductor.Text = "";
            TxtTipo.Text = "";
            TxtPrecioXSeg.Text = "";

            BtnBuscar.Enabled = true;
            BtnAgregar.Enabled = false;
            BtnEliminar.Enabled = false;
            BtnModificar.Enabled = false;
            TxtNomPgm.Enabled = true;
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        string oMensaje = "";
        string NomProg = TxtNomPgm.Text;
        string ProdProg = TxtProductor.Text;
        string TipoProg = TxtTipo.Text;
        int PreXSegProg = 0;
    
        try
        {
            PreXSegProg = Convert.ToInt32(TxtPrecioXSeg.Text);
        }
        catch
        {
            oMensaje = "Error al ingresar el Precio Por Segundo";
        }

        if (oMensaje != "")
            LblError.Text = oMensaje;
        else
        {
            try
            {
                Programa p = (Programa)Session["Unprograma"];
                p.NomProg = NomProg;
                p.ProdProg = ProdProg;
                p.TipoProg = TipoProg;
                p.PreXSegProg = PreXSegProg;

                LogicaPrograma.ModificarP(p);
                LblError.Text = "Modificacion Exitosa";
                TxtNomPgm.Text = "";
                TxtProductor.Text = "";
                TxtTipo.Text = "";
                TxtPrecioXSeg.Text = "";
                BtnBuscar.Enabled = true;
                BtnAgregar.Enabled = false;
                BtnEliminar.Enabled = false;
                BtnModificar.Enabled = false;
                TxtNomPgm.Enabled = true;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }

    protected void BtnDeshacer_Click(object sender, EventArgs e)
    {
        TxtNomPgm.Text = "";
        TxtProductor.Text = "";
        TxtTipo.Text = "";
        TxtPrecioXSeg.Text = "";
        BtnAgregar.Enabled = false;
        BtnEliminar.Enabled = false;
        BtnModificar.Enabled = false;
        LblError.Text = "";
        TxtNomPgm.Enabled = true;
        BtnBuscar.Enabled = true;
    }
}

