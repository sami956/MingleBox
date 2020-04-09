using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class featuremanagement : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    

    // user defined function
    void getFeatureByID()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from feature_master_tbl where feature_id='" + TextBox1.Text.Trim() + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                TextBox2.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid Feature ID');</script>");
            }


        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");

        }
    }


    void deleteFeature()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("DELETE from feature_master_tbl WHERE feature_id='" + TextBox1.Text.Trim() + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Feature Deleted Successfully');</script>");
            clearForm();
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void updateFeature()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("UPDATE feature_master_tbl SET feature_name=@feature_name WHERE feature_id='" + TextBox1.Text.Trim() + "'", con);

            cmd.Parameters.AddWithValue("@feature_name", TextBox2.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Feature Updated Successfully');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }


    void addNewFeature()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO feature_master_tbl(feature_id,feature_name) values(@feature_id,@feature_name)", con);

            cmd.Parameters.AddWithValue("@feature_id", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@feature_name", TextBox2.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Feature added Successfully');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }



    bool checkIfFeatureExists()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from feature_master_tbl where feature_id='" + TextBox1.Text.Trim() + "';", con);
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

    void clearForm()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        getFeatureByID();

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        if (checkIfFeatureExists())
        {
            Response.Write("<script>alert('Feature with this ID already Exist. You cannot add another Feature with the same Feature ID');</script>");
        }
        else
        {
            addNewFeature();
        }
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        if (checkIfFeatureExists())
        {
            updateFeature();

        }
        else
        {
            Response.Write("<script>alert('Feature does not exist');</script>");
        }
    }
    protected void Button4_Click1(object sender, EventArgs e)
    {
        if (checkIfFeatureExists())
        {
            deleteFeature();

        }
        else
        {
            Response.Write("<script>alert('Feature does not exist');</script>");
        }
    }
}