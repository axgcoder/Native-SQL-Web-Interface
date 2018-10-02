<%@ Page Language="C#" AutoEventWireup="true" CodeFile="seventh.aspx.cs" Inherits="seventh" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div id="main">
                <h2>Seventh Transaction </h2>
            </div>
            <table>
                <tr>
                    <td class="td">Role Name:</td>
                    <td>
                        <asp:DropDownList ID="rolename" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="td">Table Name:</td>
                    <td>
                        <asp:TextBox ID="TableName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="td">RP Id:</td>
                    <td>
                        <asp:TextBox ID="rpid" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="back" runat="server" Text="Back" OnClick="back_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>