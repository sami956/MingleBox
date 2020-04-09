using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
public partial class streammanagement : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    // add button click
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (checkIfStreamExists())
        {
            Response.Write("<script>alert('Stream with this ID already Exist. You cannot add another Stream with the same Stream ID');</script>");
        }
        else
        {
            addNewStream();
        }
    }
    // update button click
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (checkIfStreamExists())
        {
            updateStream();

        }
        else
        {
            Response.Write("<script>alert('Stream does not exist');</script>");
        }
    }
    // delete button click
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (checkIfStreamExists())
        {
            deleteStream();

        }
        else
        {
            Response.Write("<script>alert('Stream does not exist');</script>");
        }
    }


    // GO button click
    protected void Button1_Click(object sender, EventArgs e)
    {
        getStreamByID();
    }


    // user defined function
    void getStreamByID()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from stream_master_tbl where stream_id='" + TextBox1.Text.Trim() + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                TextBox2.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid Stream ID');</script>");
            }


        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");

        }
    }


    void deleteStream()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("DELETE from stream_master_tbl WHERE stream_id='" + TextBox1.Text.Trim() + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Stream Deleted Successfully');</script>");
            clearForm();
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void updateStream()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("UPDATE stream_master_tbl SET stream_name=@stream_name WHERE stream_id='" + TextBox1.Text.Trim() + "'", con);

            cmd.Parameters.AddWithValue("@stream_name", TextBox2.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Stream Updated Successfully');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }


    void addNewStream()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO stream_master_tbl(stream_id,stream_name) values(@stream_id,@stream_name)", con);

            cmd.Parameters.AddWithValue("@stream_id", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@stream_name", TextBox2.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Stream added Successfully');</script>");
            clearForm();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }



    bool checkIfStreamExists()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from stream_master_tbl where stream_id='" + TextBox1.Text.Trim() + "';", con);
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


    
}