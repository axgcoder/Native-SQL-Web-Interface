<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eighth.aspx.cs" Inherits="eighth" %>

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
                <h2 style="margin: 0; display: inline-block;">Eighth transaction</h2>
                <asp:Button Style="float: right;" ID="Button1" runat="server" Text="Return" OnClick="back_Click" />
            </div>
            <h3>To retrieve all privileges associate with a particular ROLE, and all privileges associated with a particular user account</h3>
            <p><strong>Query:</strong>select privileges.privilegename,userroles.rolename from privileges JOIN accountprivilege ON privileges.privilegeid=accountprivilege.apid JOIN providedwith ON accountprivilege.apid=providedwith.apid JOIN userroles ON providedwith.rolename=userroles.rolename;</p>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <h3>To that check whether a particular privilege is currently available (granted) to a particular user account.</h3>
            <p>
                <strong>Query:</strong>select useraccount.lname,privileges.PrivilegeName FROM
useraccount join userroles on useraccount.rolename=userroles.rolename
join providedwith on providedwith.rolename=userroles.rolename
join accountprivilege on accountprivilege.apid=providedwith.apid
join privileges on privileges.privilegeid=accountprivilege.apid;
            </p>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>