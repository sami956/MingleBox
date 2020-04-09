using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["role"].Equals(""))
            {
                LinkButton1.Visible = true; // user login link button
                LinkButton2.Visible = true; // sign up link button

                LinkButton3.Visible = false; // logout link button
                LinkButton7.Visible = false; // hello user link button


                LinkButton6.Visible = true; // admin login link button
                LinkButton11.Visible = false; // stream management link button
                LinkButton12.Visible = false; // topic management link button
                LinkButton8.Visible = false; // college inventory link button
                LinkButton5.Visible = false; // user management link button
                LinkButton10.Visible = false; // exam management link button

            }
            else if (Session["role"].Equals("user"))
            {
                LinkButton1.Visible = false; // user login link button
                LinkButton2.Visible = false; // sign up link button

                LinkButton3.Visible = true; // logout link button
                LinkButton7.Visible = true; // hello user link button
                LinkButton7.Text = "Hello " + Session["fullname"].ToString();


                LinkButton6.Visible = true; // admin login link button
                LinkButton11.Visible = false; // stream management link button
                LinkButton12.Visible = false; // topic management link button
                LinkButton8.Visible = false; // college inventory link button
                LinkButton5.Visible = false; // user management link button
                LinkButton10.Visible = false; // exam management link button

            }
            else if (Session["role"].Equals("admin"))
            {
                LinkButton1.Visible = false; // user login link button
                LinkButton2.Visible = false; // sign up link button

                LinkButton3.Visible = true; // logout link button
                LinkButton7.Visible = true; // hello user link button
                LinkButton7.Text = "Hello Admin";


                LinkButton6.Visible = false; // admin login link button
                LinkButton11.Visible = true; // stream management link button
                LinkButton12.Visible = true; // topic management link button
                LinkButton8.Visible = true; // college inventory link button
                LinkButton5.Visible = true; // user management link button
                LinkButton10.Visible = true; // exam management link button
            }
        }
        catch (Exception ex)
        {

        }




    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminlogin.aspx");
    }
    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        Response.Redirect("streammanagement.aspx");

    }
    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        Response.Redirect("featuremanagement.aspx");

    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("collegeinventory.aspx");

    }
    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Response.Redirect("examinventory.aspx");

    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("usermanagement.aspx");

    }
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("userlogin.aspx");

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Session["username"] = "";
        Session["fullname"] = "";
        Session["role"] = "";
        Session["status"] = "";

        LinkButton1.Visible = true; // user login link button
        LinkButton2.Visible = true; // sign up link button

        LinkButton3.Visible = false; // logout link button
        LinkButton7.Visible = false; // hello user link button


        LinkButton6.Visible = true; // admin login link button
        LinkButton11.Visible = false; // stream management link button
        LinkButton12.Visible = false; // topic management link button
        LinkButton8.Visible = false; // college inventory link button
        LinkButton5.Visible = false; // user management link button
        LinkButton10.Visible = false; // exam management link button

        Response.Redirect("homepage.aspx");
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("MBA.aspx");
    }
    protected void LinkButton13_Click(object sender, EventArgs e)
    {
        Response.Redirect("Engineering.aspx");
    }
    protected void LinkButton14_Click(object sender, EventArgs e)
    {
        Response.Redirect("Design.aspx");
    }
    protected void LinkButton15_Click(object sender, EventArgs e)
    {
        Response.Redirect("DistanceEducation.aspx");
    }
    protected void LinkButton16_Click(object sender, EventArgs e)
    {
        Response.Redirect("Exams.aspx");
    }
}
