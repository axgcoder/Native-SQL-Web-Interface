<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addTables.aspx.cs" Inherits="addTables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Insert Table(3rd transaction)</h2>
            <br />
            <table>
                <tr>
                    <td class="td">Owner ID:</td>
                    <td>
                        <asp:DropDownList ID="Owner" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <%--   <tr>
                 <td class="td">User ID:</td>
            <td>
                <asp:TextBox ID="UID" runat="server"></asp:TextBox>
            </td>
           </tr>
            <tr>
                 <td class="td">Username:</td>
            <td>
                <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            </td>
           </tr>
           <tr>
                 <td class="td">Initial Name:</td>
            <td>
                <asp:TextBox ID="fName" runat="server"></asp:TextBox>
           </td>
           </tr>
             <tr>
                 <td class="td">LName:</td>
            <td>
                <asp:TextBox ID="LName" runat="server"></asp:TextBox>
            </td>
           </tr>

            <tr>
                 <td class="td">Phone:</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
           </tr>
            <tr>
                 <td class="td">Role name:</td>
            <td>

                <asp:DropDownList ID="RoleName" runat="server"></asp:DropDownList>
            </td>
           </tr>  --%>
                <tr>
                    <td class="td">TableName:</td>
                    <td>
                        <asp:TextBox ID="TableName" runat="server"></asp:TextBox>
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