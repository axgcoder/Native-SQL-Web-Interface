using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //Populating a DataTable from database.
            DataTable p = this.GetPrivileges("Privileges");
            DataTable ur = this.GetUserRoles("UserRoles");
            DataTable ua = this.GetUserAccount("UserAccount");
            DataTable t = this.Tables("Tables");
            DataTable ap = this.AccountPrivilege("AccountPrivilege");
            DataTable rp = this.RelationPrivilege("RelationPrivilege");
            DataTable pw = this.Providedwith("Providedwith");
            DataTable tr = this.track("permissions");

            createTable(p, "Privileges");
            createTable(ur, "UserRoles");
            createTable(ua, "UserAccount");
            createTable(t, "Tables");
            createTable(ap, "AccountPrivilege");
            createTable(rp, "RelationPrivilege");
            createTable(pw, "Providedwith");
            createTable(tr, "track");
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
        if (tablename == "UserRoles")
            PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "Privileges")
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "UserAccount")
            PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "Tables")
            PlaceHolder4.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "AccountPrivilege")
            PlaceHolder5.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "RelationPrivilege")
            PlaceHolder6.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "Providedwith")
            PlaceHolder7.Controls.Add(new Literal { Text = html.ToString() });
        else if (tablename == "track")
            PlaceHolder8.Controls.Add(new Literal { Text = html.ToString() });
    }

    private DataTable GetPrivileges(string Privileges)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Privileges + ""))
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

    private DataTable GetUserRoles(string UserRoles)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + UserRoles + ""))
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

    private DataTable GetUserAccount(string UserAccount)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + UserAccount + ""))
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

    private DataTable Tables(string Tables)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Tables + ""))
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

    private DataTable AccountPrivilege(string AccountPrivilege)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + AccountPrivilege + ""))
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

    private DataTable RelationPrivilege(string RelationPrivilege)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + RelationPrivilege + ""))
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

    private DataTable Providedwith(string Providedwith)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Providedwith + ""))
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

    private DataTable track(string track)
    {
        //string constr = @"Data Source=localhost;Database=project2;User ID=root; Password='admin'";//successfully connected
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + track + ""))
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