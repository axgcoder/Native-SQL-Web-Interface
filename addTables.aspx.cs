using System;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class addTables : System.Web.UI.Page
{
    private MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //using (MySqlConnection con2 = new MySqlConnection(constr))
            //{
            //    using (MySqlCommand cmd = new MySqlCommand("SELECT RoleName FROM UserRoles"))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = con2;
            //        con2.Open();
            //        RoleName.DataSource = cmd.ExecuteReader();
            //        RoleName.DataTextField = "RoleName";
            //        RoleName.DataValueField = "RoleName";
            //        RoleName.DataBind();
            //        con2.Close();
            //    }
            //}
            //RoleName.Items.Insert(0, new ListItem("--Select Role--", "0"));

            using (MySqlConnection con2 = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT uid FROM useraccount order by uid ;"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con2;
                    con2.Open();
                    Owner.DataSource = cmd.ExecuteReader();
                    Owner.DataTextField = "uid";
                    Owner.DataValueField = "uid";
                    Owner.DataBind();
                    con2.Close();
                }
            }
            Owner.Items.Insert(0, new ListItem("--Select Owner ID--", "0"));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            conn.Open();

            //MySqlCommand cmd = new MySqlCommand("Insert into useraccount (uid,Username,fName,Lname,Phone,RoleName)  values(@uid,@Username,@fName,@LName,@Phone,@RoleName)", conn);
            MySqlCommand cm2 = new MySqlCommand("Insert into tables values(@TableName,@UID)", conn);
            //cmd.Parameters.AddWithValue("@uid", UID.Text);
            //cmd.Parameters.AddWithValue("@Username", Username.Text);
            //cmd.Parameters.AddWithValue("@fName", fName.Text);
            //cmd.Parameters.AddWithValue("@LName", LName.Text);
            //cmd.Parameters.AddWithValue("@Phone", Phone.Text);
            //cmd.Parameters.AddWithValue("@RoleName", RoleName.SelectedValue);
            //cmd.ExecuteNonQuery();
            //cmd.Dispose();

            cm2.Parameters.AddWithValue("@TableName", TableName.Text);
            cm2.Parameters.AddWithValue("@UID", Owner.SelectedValue);
            cm2.ExecuteNonQuery();
            cm2.Dispose();

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
        //UID.Text = "";
        //Username.Text = "";
        //fName.Text = "";
        //LName.Text = "";
        //Phone.Text = "";
        //RoleName.SelectedIndex = 0;
        Owner.SelectedIndex = 0;
        TableName.Text = "";
        Owner.Focus();
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Main.aspx");
    }
}