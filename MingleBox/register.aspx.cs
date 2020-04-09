using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


    public partial class register : System.Web.UI.Page
    {



        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (checkMemberExists())
            {

                Response.Write("<script>alert('Email Already Registered');</script>");
            }
            else
            {
                signUpNewMember();
            }
        }

        // user defined method
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from user_master_tbl where user_email='" + TextBox4.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewMember()
        {
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO user_master_tbl(user_fullname,user_email,user_mobilenumber,user_state,user_city,user_interest,user_password,user_status) values(@user_fullname,@user_email,@user_mobilenumber,@user_state,@user_city,@user_interest,@user_password,@user_status)", con);
                cmd.Parameters.AddWithValue("@user_fullname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@user_email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@user_mobilenumber", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@user_state", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@user_city", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@user_interest", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@user_password", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@user_status", "pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Registration Successful. Please Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }




    }
