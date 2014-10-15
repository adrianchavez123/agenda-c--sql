<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Proveedores.aspx.cs" Inherits="Proveedores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 161px;
        }
    </style>
</head>
<body bgcolor="#c0c0c0">
    <form id="form1" runat="server">
    <div>
    
        

            <asp:LinkButton ID="LinkAgregar" runat="server" onclick="LinkAgregar_Click">Agregar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="LinkEliminar" runat="server" onclick="LinkEliminar_Click">Eliminar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="LinkModificar" runat="server" onclick="LinkModificar_Click">Modificar</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="LinkBuscar" runat="server" onclick="LinkBuscar_Click">Buscar</asp:LinkButton>

        <asp:Panel ID="Panel1" runat="server" Height="394px" Width="441px" 
            BackColor="#6699FF">
            
            <p></p>
            <p>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Agregar Proveedor"></asp:Label>
            </p>
            <table style="width: 54%; height: 284px;">
                <tr>
                    <td class="style1">
                        Nombre</td>
                    <td>
                        <asp:TextBox ID="textBoxNombre" runat="server" Width="242px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Domicilio</td>
                    <td>
                        <asp:TextBox ID="textBoxDomicilio" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Colonia</td>
                    <td>
                        <asp:TextBox ID="textBoxColonia" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="style1">
                        Telefono</td>
                    <td>
                        <asp:TextBox ID="textBoxTelefono" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Celular</td>
                    <td>
                        <asp:TextBox ID="textBoxCelular" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Codigo Postal</td>
                    <td>
                        <asp:TextBox ID="textBoxCp" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Email</td>
                    <td>
                        <asp:TextBox ID="textBoxEmail" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Municipio</td>
                    <td>
                        <asp:TextBox ID="textBoxMunicipio" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Estado</td>
                    <td>
                        <asp:TextBox ID="textBoxEstado" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        RFC</td>
                    <td>
                        <asp:TextBox ID="textBoxRFC" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td><asp:Button ID="ButtonRegistrar" runat="server" onclick="Button1_Click" 
                            Text="Registrar" />
                </td>
               </tr>
            </table>
        </asp:Panel>
    
    </div>
    <p>
        &nbsp;</p>
    <asp:Panel ID="panelEliminar" runat="server" BackColor="#3333FF" Height="167px" 
        Width="441px">
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" 
            Text="Eliminar  Proveedor"></asp:Label>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Conexion %>" 
            SelectCommand="SELECT [idProveedor], [nombre] FROM [proveedores] WHERE ([activo] = @activo)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="activo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="nombre" 
            DataValueField="idProveedor">
        </asp:DropDownList>
        <asp:Button ID="ButtonEliminar" runat="server" onclick="ButtonEliminar_Click" 
            Text="Eliminar" />
       
    </asp:Panel>
     <asp:Panel ID="panelMostrar" runat="server" BackColor="#009999" Height="734px" 
            Width="755px">
            <p>
            </p>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" 
                Text="Registros"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="nombre" 
                        SortExpression="nombre" />
                    <asp:BoundField DataField="domicilio" HeaderText="domicilio" 
                        SortExpression="domicilio" />
                    <asp:BoundField DataField="colonia" HeaderText="colonia" 
                        SortExpression="colonia" />
                    <asp:BoundField DataField="telefono" HeaderText="telefono" 
                        SortExpression="telefono" />
                    <asp:BoundField DataField="celular" HeaderText="celular" 
                        SortExpression="celular" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="cp" HeaderText="cp" SortExpression="cp" />
                    <asp:BoundField DataField="municipio" HeaderText="municipio" 
                        SortExpression="municipio" />
                    <asp:BoundField DataField="estado" HeaderText="estado" 
                        SortExpression="estado" />
                    <asp:BoundField DataField="rfc" HeaderText="rfc" SortExpression="rfc" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Conexion %>" 
                SelectCommand="SELECT [nombre], [domicilio], [colonia], [telefono], [celular], [email], [cp], [municipio], [estado], [rfc] FROM [proveedores] WHERE ([activo] = @activo)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="activo" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </asp:Panel>
    
    <asp:Panel ID="PanelModificar" runat="server" BackColor="#9999FF" 
        Height="385px" Width="674px">
        <p>&nbsp;</p>
        <p>
            
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" 
                Text="Actualiar Proveedor"></asp:Label>
            
        </p>

        <table style="width: 54%; height: 284px;">
                <tr>
                    <td class="style1">
                        Nombre</td>
                    <td>
                       
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                            DataSourceID="SqlDataSource1" DataTextField="nombre" 
                            DataValueField="idProveedor" 
                            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                       
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Domicilio</td>
                    <td>
                        <asp:TextBox ID="textBoxDomicilioM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Colonia</td>
                    <td>
                        <asp:TextBox ID="textBoxColoniaM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="style1">
                        Telefono</td>
                    <td>
                        <asp:TextBox ID="textBoxTelefonoM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Celular</td>
                    <td>
                        <asp:TextBox ID="textBoxCelularM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Codigo Postal</td>
                    <td>
                        <asp:TextBox ID="textBoxCpM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Email</td>
                    <td>
                        <asp:TextBox ID="textBoxEmailM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Municipio</td>
                    <td>
                        <asp:TextBox ID="textBoxMunicipioM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Estado</td>
                    <td>
                        <asp:TextBox ID="textBoxEstadoM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        RFC</td>
                    <td>
                        <asp:TextBox ID="textBoxRFCM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td><asp:Button ID="Modificar" runat="server" onclick="ButtonModificar_Click" 
                            Text="Modificar" />
                </td>
               </tr>
            </table>

    </asp:Panel>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>


