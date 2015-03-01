<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMCampaniaPropia.aspx.cs" Inherits="ABMCampaniaPropia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            <span style="font-family: Lucida Sans Unicode"><span style="font-size: 32pt"><span
                style="color: #000099"><strong>CAMPAÑA PROPIA</strong> </span></span></span>
            <br />
            <br />
            <table style="width: 715px; height: 265px">
                <tr>
                    <td style="width: 281px; text-align: center">
                        <strong><span style="font-size: 16pt">ID (0 para Agregar):</span></strong></td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>&nbsp;
                        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 281px">
                        <strong><span style="font-size: 16pt">Nombre:</span></strong></td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 281px">
                        <strong><span style="font-size: 16pt">Anunciante:</span></strong></td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="DDLAnunciante" runat="server" Width="200px">
                        </asp:DropDownList>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 281px">
                        <span style="font-size: 16pt"><strong>Fecha Inicial:</strong></span></td>
                    <td style="text-align: left">
                        <asp:Calendar ID="CalendarioFI" runat="server" BackColor="White" BorderColor="#3366CC"
                            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                            Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                                Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        </asp:Calendar>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 281px">
                        <span style="font-size: 16pt"><strong>Fecha Final:</strong></span></td>
                    <td style="text-align: left">
                        <asp:Calendar ID="CalendarioFF" runat="server" BackColor="White" BorderColor="#3366CC"
                            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                            Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                                Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td style="width: 281px">
                        <span style="font-size: 16pt"><strong>Menciones:</strong></span></td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtMenciones" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 281px">
                        <strong><span style="font-size: 16pt">Costo Produccion: </span></strong>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TxtCosto" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 281px; height: 26px">
                        <strong><span style="font-size: 14pt">Duracion del spot en segundos:</span></strong></td>
                    <td style="height: 26px; text-align: left;">
                        <asp:TextBox ID="TxtDuracion" runat="server"></asp:TextBox>
                        &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 281px">
                    </td>
                    <td>
                        <asp:Button ID="BtnAgregar" runat="server" Enabled="False" 
                            Text="Agregar" OnClick="BtnAgregar_Click" />
                        <asp:Button ID="BtnEliminar" runat="server" Enabled="False"
                                 Text="Eliminar" OnClick="BtnEliminar_Click" />
                        <asp:Button ID="BtnModificar" runat="server" Enabled="False" 
                            Text="Modificar" OnClick="BtnModificar_Click" />
                        <asp:Button ID="BtnDeshacer" runat="server" Text="Deshacer" OnClick="BtnDeshacer_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 281px">
                    </td>
                    <td>
                        <asp:Label ID="LblError" runat="server"></asp:Label></td>
                </tr>
            </table>
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server" Height="20px" PostBackUrl="~/Default.aspx"
                Width="67px">Volver</asp:LinkButton><br />
        </div>
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
