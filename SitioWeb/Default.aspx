<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <br />
        <br />
        <br />
        <asp:Label ID="LblTitulo" runat="server" Font-Names="Lucida Console" Font-Size="26pt"
            ForeColor="Black" Height="36px" Text="BIENVENIDOS A LA RADIO" Width="870px" Font-Bold="True"></asp:Label><br />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagen/Logo de la Radio.jpg" /><br />
        <br />
        <br />
                    <asp:LinkButton ID="LBDatosE" runat="server" Font-Size="16pt" PostBackUrl="~/ABMProgramas.aspx">Mantenimiento Programas</asp:LinkButton><br />
        <br />
                    <asp:LinkButton ID="LbAnunciantes" runat="server" Font-Size="16pt" PostBackUrl="~/ABMAnunciantes.aspx" >Mantenimiento Anunciantes</asp:LinkButton><br />
        <br />
                    <asp:LinkButton ID="LbCampaniaP" runat="server" Font-Size="16pt" PostBackUrl="~/ABMCampaniaPropia.aspx">Mantenimiento de Campañas Propias</asp:LinkButton><br />
        <br />
                    <asp:LinkButton ID="LbCampaniasE" runat="server" Font-Size="16pt" PostBackUrl="~/ABMCampaniaExterna.aspx">Mantenimiento de Campañas Externas</asp:LinkButton><br />
        <br />
                    <asp:LinkButton ID="LbListaA" runat="server" Font-Size="16pt" PostBackUrl="~/AgregarMencion.aspx">Agregar Mencion</asp:LinkButton><br />
        <br />
                    <asp:LinkButton ID="LbCxA" runat="server" Font-Size="16pt" PostBackUrl="~/ListadoProgramas.aspx">Listar Todos los  Programas</asp:LinkButton><br />
        <br />
                    <asp:LinkButton ID="LbListaCVxT" runat="server" Font-Size="16pt" PostBackUrl="~/CalcularPrecioCampania.aspx">Calculo de Precio Campañas</asp:LinkButton>&nbsp;</div>
    </form>
</body>
</html>
