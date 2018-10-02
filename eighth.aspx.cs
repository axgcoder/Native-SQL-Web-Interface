using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class eighth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //Populating a DataTable from database.
            DataTable ua = this.GetData1("data1");
            DataTable ur = this.GetData2("data2");
            createTable(ua, "data1");
            createTable(ur, "data2");
        }
    }

    private void createTable(DataTable dt, string tablename)
    {
        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        //Table start.
        html.Append("<table border = '1'>");

        //Building the Header row.
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            html.Append("<th>");
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");

        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }

        //Table end.
        html.Append("</table>");

        //Append the HTML string to Placeholder.
        if (tablename == "data2")
            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "data1")
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }

    private DataTable GetData1(string UserAccount)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("select privileges.privilegename,userroles.rolename from privileges JOIN accountprivilege ON privileges.privilegeid=accountprivilege.apid JOIN providedwith ON accountprivilege.apid=providedwith.apid JOIN userroles ON providedwith.rolename=userroles.rolename;"))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    private DataTable GetData2(string UserRoles)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("select useraccount.lname,privileges.PrivilegeName FROM useraccount " +
                "join userroles on useraccount.rolename = userroles.rolename " +
                "join providedwith on providedwith.rolename = userroles.rolename " +
                "join accountprivilege on accountprivilege.apid = providedwith.apid " +
                "join privileges on privileges.privilegeid = accountprivilege.apid; "))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}