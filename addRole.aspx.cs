using System;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using MySql.Data.MySqlClient;

public partial class addRole : System.Web.UI.Page
{
    private MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Insert into UserRoles values(@RoleName, @Description)", conn);
            cmd.Parameters.AddWithValue("@RoleName", RoleName.Text);
            cmd.Parameters.AddWithValue("@Description", TextArea1.InnerText);
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
        RoleName.Text = "";
        TextArea1.InnerText = "";
        RoleName.Focus();
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}