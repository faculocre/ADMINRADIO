using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EntidadesCompartidas;
using Logica;

public partial class CalcularPrecioCampania : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //Cargo el DropDownList
                DDLCampania.DataSource = LogicaCampania.ListarCampanias();
                DDLCampania.DataTextField = "Titulo";
                DDLCampania.DataValueField = "Id";
                DDLCampania.DataBind();
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
            }
        }
    }

    protected void BtnCalcular_Click(object sender, EventArgs e)
    {
        try
        {
            Campania Camp = LogicaCampania.BuscarC(Convert.ToInt32(DDLCampania.SelectedValue));
            TxtPrecio.Text = LogicaCampania.PrecioCampanias(Camp).ToString();
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }
}
