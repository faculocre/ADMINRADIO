<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMAnunciantes.aspx.cs" Inherits="ABMAnunciantes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <strong><span style="font-size: 24pt; color: #000099; font-family: Lucida Sans Unicode">
            ANUNCIANTES</span></strong><br />
        <br />
        <br />
            <table >
                <tr>
                    <td>
                        <span style="font-size: 16pt">RUT</span></td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtRut" runat="server"></asp:TextBox></td>
                    <td style="width: 1px; text-align: left">
                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 16pt">Nombre:</span></td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>&nbsp;
                        </td>
                    <td style="width: 1px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td>
                        <span style="font-size: 16pt">Direccion:</span></td>
                    <td style="font-size: 12pt; text-align: left">
                        <asp:TextBox ID="TxtDireccion" runat="server" Width="225px"></asp:TextBox></td>
                    <td style="font-size: 12pt; width: 1px; text-align: left">
                    </td>
                </tr>
                <tr style="font-size: 12pt">
                    <td>
                        <span style="font-size: 16pt">Telefonos:</span></td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                        <asp:Button ID="BtnNuevoTelefono" runat="server" Enabled="False" 
                            Text="Nuevo Tel" OnClick="BtnNuevoTelefono_Click"/><br />
                        <br />
                        <asp:ListBox ID="LstTelefonos" runat="server" Height="114px" Width="151px"></asp:ListBox>
                        <asp:Button ID="BtnBorrarTelefono" runat="server" Enabled="False" 
                            Text="Borrar Tel" OnClick="BtnBorrarTelefono_Click" /></td>
                    <td style="width: 1px; text-align: left">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="text-align: left">
                        <asp:Button ID="BtnAgregar" runat="server" Enabled="False" 
                            Text="Agregar" OnClick="BtnAgregar_Click" />&nbsp;
                            <asp:Button ID="BtnEliminar" runat="server" Enabled="False"
                                 Text="Eliminar" OnClick="BtnEliminar_Click" />&nbsp;
                             <asp:Button ID="BtnModificar"
                                    runat="server" Enabled="False" Text="Modificar" OnClick="BtnModificar_Click" />&nbsp;</td>
                    <td style="width: 1px; text-align: left">
                        <asp:Button
                                        ID="BtnDeshacer" runat="server" Text="Deshacer" OnClick="BtnDeshacer_Click" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="LblError" runat="server"></asp:Label></td>
                    <td style="width: 1px; text-align: center">
                    </td>
                </tr>
            </table>
        <br />
            <br />
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </div>
    

    </form>
</body>
</html>
