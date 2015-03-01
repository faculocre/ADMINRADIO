<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMProgramas.aspx.cs" Inherits="ABMProgramas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong style="font-size: 24pt; color: #000099; font-family: 'Lucida Sans Unicode'">
            &nbsp;PROGRAMAS</strong><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        <table style="width: 547px; height: 123px">
            <tr>
                <td style="font-size: 16pt; width: 659px; height: 17px">
                    Nombre:</td>
                <td style="width: 507px; height: 17px">
                    <asp:TextBox ID="TxtNomPgm" runat="server"></asp:TextBox></td>
                <td style="width: 121px; height: 17px">
                    <asp:Button ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" Text="Buscar" /></td>
            </tr>
            <tr>
                <td style="font-size: 16pt; width: 659px">
                    Productor:</td>
                <td style="width: 507px">
                    <asp:TextBox ID="TxtProductor" runat="server"></asp:TextBox></td>
                <td style="width: 121px">
                </td>
            </tr>
            <tr>
                <td style="font-size: 16pt; width: 659px">
                    Tipo:</td>
                <td style="width: 507px">
                    <asp:TextBox ID="TxtTipo" runat="server"></asp:TextBox></td>
                <td style="width: 121px">
                </td>
            </tr>
            <tr>
                <td style="font-size: 16pt; width: 659px; height: 2px">
                    Precio Por Segundo:</td>
                <td style="width: 507px; height: 2px">
                    <asp:TextBox ID="TxtPrecioXSeg" runat="server"></asp:TextBox></td>
                <td style="width: 121px; height: 2px">
                </td>
            </tr>
            <tr>
                <td style="width: 659px; height: 29px">
                </td>
                <td style="width: 507px; height: 29px">
                    <asp:Button ID="BtnAgregar" runat="server" Enabled="False" Text="Agregar" OnClick="BtnAgregar_Click" />
                    <asp:Button ID="BtnEliminar" runat="server" Enabled="False" Text="Eliminar" OnClick="BtnEliminar_Click" />
                    <asp:Button ID="BtnModificar" runat="server" Enabled="False" Text="Modificar" OnClick="BtnModificar_Click" /></td>
                <td style="width: 121px; height: 29px">
                    <asp:Button ID="BtnDeshacer" runat="server" Text="Deshacer" OnClick="BtnDeshacer_Click" /></td>
            </tr>
            <tr>
                <td style="width: 659px; height: 28px">
                </td>
                <td style="width: 507px; height: 28px">
                    <asp:Label ID="LblError" runat="server"></asp:Label></td>
                <td style="width: 121px; height: 28px">
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton></div>
    </form>
</body>
</html>
