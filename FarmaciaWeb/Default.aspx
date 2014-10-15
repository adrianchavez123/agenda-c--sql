<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 171px;
        }
        .style2
        {
            width: 312px;
        }
        #Password1
        {
            width: 233px;
        }
        #password
        {
            width: 234px;
        }
    </style>
</head>
<body bgcolor="#c0c0c0">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
            Font-Size="XX-Large" Text="Farmacia"></asp:Label>
        <br />
        <br />
        <table style="width:50%;">
            <tr>
                <td class="style1">
                    UserName</td>
                <td class="style2">
                    <asp:TextBox ID="TextBox1" runat="server" Width="236px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="style1">
                    Password</td>
                <td class="style2">
                    <input id="Password1" type="password"  name="password" runat="server"/></td>
                
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="iniciar" runat="server" onclick="iniciar_Click" 
                        Text="Iniciar Sesion" Width="99px" />
                </td>
                
                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
