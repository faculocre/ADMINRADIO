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
using EntidadesCompartidas;
using Logica;
using System.Globalization;

public partial class AgregarMencion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {              
                //cargo los DropDownList
                DDLCampania.DataSource = LogicaCampania.ListarCampanias();
                DDLCampania.DataTextField = "Titulo";
                DDLCampania.DataValueField = "Id";
                DDLCampania.DataBind();

                DDLPrograma.DataSource = LogicaPrograma.ListarProgramas();
                DDLPrograma.DataTextField = "NomProg";
                DDLPrograma.DataValueField = "NomProg";
                DDLPrograma.DataBind();
                //Marco la fecha de hoy por defecto
                CalendarioF.SelectedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }

    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        int Hora, Minuto;
        int Seg = 0;
        DateTime Fecha;
        try
        {
            //Creo la fecha con los datos ingresados
            Hora = Convert.ToInt32(TxtFecha.Text.Trim().Substring(0, 2));
            Minuto = Convert.ToInt32(TxtFecha.Text.Trim().Substring(3, 2));
            Fecha = new DateTime(CalendarioF.SelectedDate.Year, CalendarioF.SelectedDate.Month, CalendarioF.SelectedDate.Day, Hora, Minuto, Seg);
            //Busco la Campania y el Programa seleccionados
            Campania Camp = LogicaCampania.BuscarC(Convert.ToInt32(DDLCampania.SelectedValue));
            Programa Prog = LogicaPrograma.BuscarP(DDLPrograma.SelectedValue);
            //Creo la Emision
            Emision emision = new Emision(Fecha, Camp, Prog);
            //Agrego la Emision
            LogicaEmision.AgregarE(emision);
            LblError.Text = "Alta con Exito";
            DDLCampania.SelectedIndex = 0;
            DDLPrograma.SelectedIndex = 0;
            CalendarioF.SelectedDate = DateTime.Now;
            TxtFecha.Text = "";
        }
        catch (FormatException)
        {
            LblError.Text = "Error: ingrese la hora con el formato correcto: hh:mm";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }   
    }
}
