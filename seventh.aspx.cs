using System;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class seventh : System.Web.UI.Page
{
    private MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (MySqlConnection con2 = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT RoleName FROM UserRoles"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con2;
                    con2.Open();
                    rolename.DataSource = cmd.ExecuteReader();
                    rolename.DataTextField = "RoleName";
                    rolename.DataValueField = "RoleName";
                    rolename.DataBind();
                    con2.Close();
                }
            }
            rolename.Items.Insert(0, new ListItem("--Select Rolename--", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(" insert into permissions values(@rolename,@TableName,@rpid)", conn);
            cmd.Parameters.AddWithValue("@rolename", rolename.SelectedValue);
            cmd.Parameters.AddWithValue("@TableName", TableName.Text);
            cmd.Parameters.AddWithValue("@rpid", rpid.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            ShowMessage("Registered successfully......!");
            clear();
        }
        catch (MySqlException ex)
        {
            ShowMessage(ex.Message);
            // ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "done", "alert('" + ex.Message.Replace("'", "") + "');", true);
        }
        finally
        {
            conn.Close();
        }
    }

    private void ShowMessage(string msg)
    {
        var message = new JavaScriptSerializer().Serialize(msg.ToString());//if the message contains some escape characters like ' or " this will definitely break your javascript:
        var script = string.Format("alert({0});", message);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "done", script, true);
    }

    private void clear()
    {
        rolename.SelectedIndex = 0;
        TableName.Text = "";
        rpid.Text = "";
        rolename.Focus();
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}