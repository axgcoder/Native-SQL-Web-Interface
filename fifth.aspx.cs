using System;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class fifth : System.Web.UI.Page
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

            using (MySqlConnection con2 = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT uid FROM useraccount"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con2;
                    con2.Open();
                    uid.DataSource = cmd.ExecuteReader();
                    uid.DataTextField = "uid";
                    uid.DataValueField = "uid";
                    uid.DataBind();
                    con2.Close();
                }
            }
            uid.Items.Insert(0, new ListItem("--Select User ID--", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(" update  useraccount set rolename=@rolename where uid=@uid", conn);
            cmd.Parameters.AddWithValue("@uid", uid.SelectedValue);
            cmd.Parameters.AddWithValue("@rolename", rolename.SelectedValue);
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
        uid.SelectedIndex = 0;
        rolename.SelectedIndex = 0;
        uid.Focus();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}