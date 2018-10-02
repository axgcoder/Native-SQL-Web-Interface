using System;

public partial class Main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/userAccount.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/addRole.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/addTables.aspx");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/addprivilege.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/fifth.aspx");
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/sixth.aspx");
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/seventh.aspx");
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/eighth.aspx");
    }
}