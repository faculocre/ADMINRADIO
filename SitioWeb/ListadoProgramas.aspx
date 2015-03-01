<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoProgramas.aspx.cs" Inherits="ListadoProgramas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-size: 32pt; color: #000099; font-family: Lucida Sans Unicode">
            Listado de Programas</span></strong><br />
        <br />
        <asp:GridView ID="GrdProgramas" runat="server" Height="209px" Width="431px">
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
