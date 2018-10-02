using System;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using MySql.Data.MySqlClient;

public partial class addprivilege : System.Web.UI.Page
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
            MySqlCommand cmd = new MySqlCommand("Insert into Privileges(PrivilegeID,PrivilegeName,PrivilegeType)  values(@PrivilegeID,@PrivilegeName,@PrivilegeType)", conn);
            cmd.Parameters.AddWithValue("@PrivilegeID", PrivilegeID.Text);
            cmd.Parameters.AddWithValue("@PrivilegeName", PrivilegeName.Text);
            cmd.Parameters.AddWithValue("@PrivilegeType", PrivilegeType.SelectedValue);
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
        PrivilegeID.Text = "";
        PrivilegeName.Text = "";
        PrivilegeType.SelectedIndex = 0;
        PrivilegeID.Focus();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}