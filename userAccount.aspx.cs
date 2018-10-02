using System;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class userAccount : System.Web.UI.Page
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
                    RoleName.DataSource = cmd.ExecuteReader();
                    RoleName.DataTextField = "RoleName";
                    RoleName.DataValueField = "RoleName";
                    RoleName.DataBind();
                    con2.Close();
                }
            }
            RoleName.Items.Insert(0, new ListItem("--Select Customer--", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Insert into useraccount (Username,fName,Lname,Phone,RoleName)  values(@Username,@fName,@LName,@Phone,@RoleName)", conn);
            cmd.Parameters.AddWithValue("@Username", Username.Text);
            cmd.Parameters.AddWithValue("@fName", fName.Text);
            cmd.Parameters.AddWithValue("@LName", LName.Text);
            cmd.Parameters.AddWithValue("@Phone", Phone.Text);
            cmd.Parameters.AddWithValue("@RoleName", RoleName.SelectedValue);
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

    /// <summary>
    /// This function is used for show message.
    /// </summary>
    /// <param name="msg"></param>
    private void ShowMessage(string msg)
    {
        var message = new JavaScriptSerializer().Serialize(msg.ToString());//if the message contains some escape characters like ' or " this will definitely break your javascript:
        var script = string.Format("alert({0});", message);
        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "done", script, true);
    }

    /// <summary>
    /// This Function is used TextBox Empty.
    /// </summary>
    private void clear()
    {
        Username.Text = "";
        fName.Text = "";
        LName.Text = "";
        Phone.Text = "";
        RoleName.SelectedIndex = 0;

        Username.Focus();
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}