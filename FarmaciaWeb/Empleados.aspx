<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Empleados.aspx.cs" Inherits="Empleados" %>

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

        <asp:Panel ID="Panel1" runat="server" Height="351px" Width="441px" 
            BackColor="#6699FF">
            
            <p></p>
            <p>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Agregar Empleado"></asp:Label>
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
                        Puesto</td>
                    <td>
                        <asp:TextBox ID="textBoxPuesto" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Sueldo</td>
                    <td>
                        <asp:TextBox ID="textBoxSueldo" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="style1">
                        Antiguedad</td>
                    <td>
                        <asp:TextBox ID="textBoxAntiguedad" runat="server" Width="240px"></asp:TextBox>
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
                        Telefono</td>
                    <td>
                        <asp:TextBox ID="textBoxTelefono" runat="server" Width="240px"></asp:TextBox>
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
                        Domicilio</td>
                    <td>
                        <asp:TextBox ID="textBoxDomicilio" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        No Seguro Social</td>
                    <td>
                        <asp:TextBox ID="textBoxNoSS" runat="server" Width="240px"></asp:TextBox>
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
            Text="Eliminar Empleado"></asp:Label>
        <br />
        <asp:DataList ID="DataList1" runat="server" DataKeyField="idEmpleado" 
            DataSourceID="SqlDataSource1" Height="16px" Visible="False" Width="73px">
            <ItemTemplate>
                idEmpleado:
                <asp:Label ID="idEmpleadoLabel" runat="server" 
                    Text='<%# Eval("idEmpleado") %>' />
                <br />
                nombre:
                <asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Conexion %>" 
            SelectCommand="SELECT [idEmpleado], [nombre] FROM [empleados] WHERE ([activo] = @activo)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="activo" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="nombre" 
            DataValueField="idEmpleado">
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
         <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2" 
                Visible="False">
             <ItemTemplate>
                 nombre:
                 <asp:Label ID="nombreLabel" runat="server" Text='<%# Eval("nombre") %>' />
                 <br />
                 puesto:
                 <asp:Label ID="puestoLabel" runat="server" Text='<%# Eval("puesto") %>' />
                 <br />
                 sueldo:
                 <asp:Label ID="sueldoLabel" runat="server" Text='<%# Eval("sueldo") %>' />
                 <br />
                 antiguedad:
                 <asp:Label ID="antiguedadLabel" runat="server" 
                     Text='<%# Eval("antiguedad") %>' />
                 <br />
                 celular:
                 <asp:Label ID="celularLabel" runat="server" Text='<%# Eval("celular") %>' />
                 <br />
                 telefono:
                 <asp:Label ID="telefonoLabel" runat="server" Text='<%# Eval("telefono") %>' />
                 <br />
                 email:
                 <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
                 <br />
                 domicilio:
                 <asp:Label ID="domicilioLabel" runat="server" Text='<%# Eval("domicilio") %>' />
                 <br />
                 noSeguroSocial:
                 <asp:Label ID="noSeguroSocialLabel" runat="server" 
                     Text='<%# Eval("noSeguroSocial") %>' />
                 <br />
                 <br />
             </ItemTemplate>
         </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:Conexion %>" 
                SelectCommand="SELECT [nombre], [puesto], [sueldo], [antiguedad], [celular], [telefono], [email], [domicilio], [noSeguroSocial] FROM [empleados] WHERE ([activo] = @activo)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="activo" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="nombre" HeaderText="nombre" 
                        SortExpression="nombre" />
                    <asp:BoundField DataField="puesto" HeaderText="puesto" 
                        SortExpression="puesto" />
                    <asp:BoundField DataField="sueldo" HeaderText="sueldo" 
                        SortExpression="sueldo" />
                    <asp:BoundField DataField="antiguedad" HeaderText="antiguedad" 
                        SortExpression="antiguedad" />
                    <asp:BoundField DataField="celular" HeaderText="celular" 
                        SortExpression="celular" />
                    <asp:BoundField DataField="telefono" HeaderText="telefono" 
                        SortExpression="telefono" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="domicilio" HeaderText="domicilio" 
                        SortExpression="domicilio" />
                    <asp:BoundField DataField="noSeguroSocial" HeaderText="noSeguroSocial" 
                        SortExpression="noSeguroSocial" />
                </Columns>
         </asp:GridView>
        </asp:Panel>
    
    <asp:Panel ID="PanelModificar" runat="server" BackColor="#9999FF" 
        Height="385px" Width="674px">
        <p></p>
        <p>
            
        </p>

        <table style="width: 54%; height: 284px;">
                <tr>
                    <td class="style1">
                        Nombre</td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                            DataSourceID="SqlDataSource1" DataTextField="nombre" 
                            DataValueField="idEmpleado" 
                            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Puesto</td>
                    <td>
                        <asp:TextBox ID="textBoxPuestoM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Sueldo</td>
                    <td>
                        <asp:TextBox ID="textBoxSueldoM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="style1">
                        Antiguedad</td>
                    <td>
                        <asp:TextBox ID="textBoxAntiguedadM" runat="server" Width="240px"></asp:TextBox>
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
                        Telefono</td>
                    <td>
                        <asp:TextBox ID="textBoxTelefonoM" runat="server" Width="240px"></asp:TextBox>
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
                        Domicilio</td>
                    <td>
                        <asp:TextBox ID="textBoxDomicilioM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        No Seguro Social</td>
                    <td>
                        <asp:TextBox ID="textBoxNoSSM" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td><asp:Button ID="ButtonModificar" runat="server" 
                            Text="Modificar" onclick="ButtonModificar_Click" />
                </td>
               </tr>
            </table>

    </asp:Panel>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>

