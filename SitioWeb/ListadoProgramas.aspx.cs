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
using Logica;
using EntidadesCompartidas;
using System.Collections.Generic;

public partial class ListadoProgramas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //cargo la lista en la session
                Session["_listaP"] = LogicaPrograma.ListarProgramas();
                //cargo la grilla
                GrdProgramas.DataSource = (List<Programa>)Session["_listaP"];
                GrdProgramas.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
