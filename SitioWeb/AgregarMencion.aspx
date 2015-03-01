<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgregarMencion.aspx.cs" Inherits="AgregarMencion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body style="color: #000000; font-family: Times New Roman">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <span style="font-size: 24pt; color: #000099; font-family: Lucida Sans Unicode">AGREGAR
            MENCION</span><br />
        <br />
        <table style="width: 482px; height: 331px">
            <tr>
                <td style="text-align: center">
                    <span style="font-size: 16pt">Seleccionar Campania:</span></td>
                <td>
                    <asp:DropDownList ID="DDLCampania" runat="server" Width="158px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <span style="font-size: 16pt">Seleccionar Programa:</span></td>
                <td>
                    <asp:DropDownList ID="DDLPrograma" runat="server" Width="165px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <span style="font-size: 16pt">Seleccionar fecha:</span></td>
                <td>
                    <asp:Calendar ID="CalendarioF" runat="server" BackColor="White" BorderColor="#3366CC"
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
                <td>
                    <span style="font-size: 16pt">Ingresar hora:<br />
                        <span style="font-size: 12pt">(Formato hh:mm)</span></span></td>
                <td style="font-size: 12pt">
                    <asp:TextBox ID="TxtFecha" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Agregar" /><br />
        <br />
        <asp:Label ID="LblError" runat="server" EnableTheming="True"></asp:Label><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton><br />
    
    </div>
    </form>
</body>
</html>
