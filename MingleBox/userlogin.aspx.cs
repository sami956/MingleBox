using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userlogin : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try {
    SqlConnection con = new SqlConnection(strcon);
    if (con.State == ConnectionState.Closed) {
     con.Open();
 
    }
    SqlCommand cmd = new SqlCommand("select * from user_master_tbl where user_email='" + TextBox1.Text.Trim() + "' AND user_password='" + TextBox2.Text.Trim() + "'", con);
    SqlDataReader dr = cmd.ExecuteReader();
    if (dr.HasRows) {
     while (dr.Read()) {
      Response.Write("<script>alert('Login Successful');</script>");
      Session["username"] = dr.GetValue(1).ToString();
      Session["fullname"] = dr.GetValue(0).ToString();
      Session["role"] = "user";
      Session["status"] = dr.GetValue(7).ToString();
      Session["stream"] = dr.GetValue(6).ToString();
     }
     Response.Redirect("homepage.aspx");

    } else {
     Response.Write("<script>alert('Invalid credentials');</script>");
    }
 
   } catch (Exception ex) {
 
   }
  }
}
