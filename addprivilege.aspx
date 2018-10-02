<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addprivilege.aspx.cs" Inherits="addprivilege" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Insert Privileges(4th transaction)</h2>
            <br />
            <table>
                <tr>
                    <td class="td">PrivilegeID</td>
                    <td>
                        <asp:TextBox ID="PrivilegeID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="td">Privilege Name:</td>
                    <td>
                        <asp:TextBox ID="PrivilegeName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="td">Privilege Type:</td>
                    <td>

                        <asp:DropDownList ID="PrivilegeType" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Enabled="true" Text="Select Privilege Type" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="AP" Value="AP"></asp:ListItem>
                            <asp:ListItem Text="RP" Value="RP"></asp:ListItem>
                        </asp:DropDownList>
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
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        console.log("ready!");

        $.ajax({
            url: " https://newsapi.org/v1/articles?source=bbc-news&sortBy=top&apiKey=7e883238a8ef4d8983aa9d2c707e32cc",
            type: 'GET',
            dataType: 'json', // added data type
            success: function (item) {
                console.log(item);

            }
        });
    });
</script>
</html>