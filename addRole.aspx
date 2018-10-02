<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addRole.aspx.cs" Inherits="addRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Insert Roles (second transaction)</h2>
            <br />
            <table>
                <tr>
                    <td class="td">Name:</td>
                    <td>
                        <asp:TextBox ID="RoleName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td">Description :</td>
                    <td>
                        <textarea id="TextArea1" textmode="multiline" cols="20" rows="4" runat="server"></textarea>
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