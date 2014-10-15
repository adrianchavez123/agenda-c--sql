<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Articulos.aspx.cs" Inherits="Articulos" %>

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
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Agregar Articulo"></asp:Label>
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
                        Descripcion</td>
                    <td>
                        <asp:TextBox ID="textBoxDescripcion" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Existencia</td>
                    <td>
                        <asp:TextBox ID="textBoxExistencia" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="style1">
                        PrecioVenta</td>
                    <td>
                        <asp:TextBox ID="textBoxPrecioVenta" runat="server" Width="240px"></asp:TextBox>
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
            
            SelectCommand="SELECT [idArticulo], [nombre] FROM [articulos] WHERE ([activo] = @activo)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="activo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="nombre" 
            DataValueField="idArticulo">
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
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" 
                        SortExpression="descripcion" />
                    <asp:BoundField DataField="existencia" HeaderText="existencia" 
                        SortExpression="existencia" />
                    <asp:BoundField DataField="precioVenta" HeaderText="precioVenta" 
                        SortExpression="precioVenta" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Conexion %>" 
                
                SelectCommand="SELECT [nombre], [descripcion], [existencia], [precioVenta] FROM [articulos] WHERE ([activo] = @activo)">
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
                            DataValueField="idArticulo" 
                            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                       
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Descripcion</td>
                    <td>
                        <asp:TextBox ID="textBoxDescripcionM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Existencia</td>
                    <td>
                        <asp:TextBox ID="textBoxExistenciaM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="style1">
                        Precio venta</td>
                    <td>
                        <asp:TextBox ID="textBoxPrecioVentaM" runat="server" Width="240px"></asp:TextBox>
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


