<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
    table {
        font-family: arial, sans-serif;
        border-collapse: collapse;
        width: 50%;
    }

    td, th {
        border: 1px solid #dddddd;
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: #dddddd;
    }
</style>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="main" style="width: 20%;">
                <h1 style="margin: 0; display: inline-block;">Tables</h1>
                <asp:Button Style="float: right;" ID="Button1" runat="server" Text="Return" OnClick="back_Click" />
            </div>
            <h2>Privileges</h2>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <h2>User Roles</h2>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            <h2>User Account</h2>
            <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
            <h2>Tables</h2>
            <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
            <h2>Account Privilege</h2>
            <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
            <h2>Relation Privilege</h2>
            <asp:PlaceHolder ID="PlaceHolder6" runat="server"></asp:PlaceHolder>
            <h2>Providedwith</h2>
            <asp:PlaceHolder ID="PlaceHolder7" runat="server"></asp:PlaceHolder>
            <h2>Permissions</h2>
            <asp:PlaceHolder ID="PlaceHolder8" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>