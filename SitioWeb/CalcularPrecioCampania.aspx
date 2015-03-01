<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalcularPrecioCampania.aspx.cs" Inherits="CalcularPrecioCampania" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="color: #000099"><span style="font-size: 24pt; font-family: Lucida Sans Unicode">
            <strong>CALCULAR PRECIO CAMPAÑA</strong></span><br />
        </span>
        <br />
        <table style="width: 367px; height: 230px">
            <tr>
                <td style="width: 261px">
                    <span style="font-size: 16pt">Seleccione una Campaña</span>:</td>
                <td style="width: 177px">
                    <asp:DropDownList ID="DDLCampania" runat="server" Width="142px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 261px">
                </td>
                <td style="width: 177px">
                    <asp:TextBox ID="TxtPrecio" runat="server" Width="137px"></asp:TextBox><br />
                    <br />
                    <asp:Button ID="BtnCalcular" runat="server" OnClick="BtnCalcular_Click" Text="Calcular" /></td>
            </tr>
            <tr>
                <td style="width: 261px; height: 46px;">
                    <asp:Label ID="LblError" runat="server"></asp:Label></td>
                <td style="width: 177px; height: 46px">
                </td>
            </tr>
        </table>
        </div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
