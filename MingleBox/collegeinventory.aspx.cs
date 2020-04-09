using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class collegeinventory : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    static string global_filepath;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillStreamFeatureValues();
        }

        GridView1.DataBind();
    }

    // go button click
    protected void Button4_Click(object sender, EventArgs e)
    {
        getCollegeByID();
    }


    // update button click
    protected void Button3_Click1(object sender, EventArgs e)
    {
        updateCollegeByID();
    }
    // delete button click
    protected void Button2_Click1(object sender, EventArgs e)
    {
        deleteCollegeByID();
    }
    // add button click
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (checkIfCollegeExists())
        {
            Response.Write("<script>alert('College Already Exists, try some other College ID');</script>");
        }
        else
        {
            addNewCollege();
        }
    }



    // user defined functions

    void deleteCollegeByID()
    {
        if (checkIfCollegeExists())
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from college_master_tbl WHERE college_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('College Deleted Successfully');</script>");

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('Invalid College ID');</script>");
        }
    }

    void updateCollegeByID()
    {

        if (checkIfCollegeExists())
        {
            try
            {
        

                string filepath = "~/college_inventory/colleges1";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;

                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("college_inventory/" + filename));
                    filepath = "~/college_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE college_master_tbl set college_name=@college_name, college_stream=@college_stream, college_feature=@college_feature, college_state=@college_state, college_city=@college_city, college_url=@college_url, college_desc=@college_desc, college_img_link=@college_img_link where college_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@college_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@college_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@college_stream", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@college_feature", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@college_state", DropDownList4.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@college_city", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@college_url", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@college_desc", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@college_img_link", filepath);


                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('College Updated Successfully');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid College ID');</script>");
        }
    }


    void getCollegeByID()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * from college_master_tbl WHERE college_id='" + TextBox1.Text.Trim() + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                TextBox2.Text = dt.Rows[0]["college_name"].ToString();
                TextBox3.Text = dt.Rows[0]["college_url"].ToString();
                TextBox4.Text = dt.Rows[0]["college_city"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["college_desc"].ToString();

                DropDownList1.SelectedValue = dt.Rows[0]["college_stream"].ToString().Trim();
                DropDownList2.SelectedValue = dt.Rows[0]["college_feature"].ToString().Trim();
                DropDownList4.SelectedValue = dt.Rows[0]["college_state"].ToString().Trim();

                global_filepath = dt.Rows[0]["college_img_link"].ToString();

            }
            else
            {
                Response.Write("<script>alert('Invalid College ID');</script>");
            }

        }
        catch (Exception ex)
        {

        }
    }

    void fillStreamFeatureValues()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT stream_name from stream_master_tbl;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataValueField = "stream_name";
            DropDownList1.DataBind();

            cmd = new SqlCommand("SELECT feature_name from feature_master_tbl;", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataValueField = "feature_name";
            DropDownList2.DataBind();

        }
        catch (Exception ex)
        {

        }
    }

    bool checkIfCollegeExists()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from college_master_tbl where college_id='" + TextBox1.Text.Trim() + "' OR college_name='" + TextBox2.Text.Trim() + "';", con);
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

    void addNewCollege()
    {
        try
        {
           
            string filepath = "~/college_inventory/colleges1.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("college_inventory/" + filename));
            filepath = "~/college_inventory/" + filename;


            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO college_master_tbl(college_id,college_name,college_stream,college_feature,college_state,college_city,college_url,college_desc,college_img_link) values(@college_id,@college_name,@college_stream,@college_feature,@college_state,@college_city,@college_url,@college_desc,@college_img_link)", con);

            cmd.Parameters.AddWithValue("@college_id", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@college_name", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@college_stream", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@college_feature", DropDownList2.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@college_state", DropDownList4.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@college_city", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@college_url", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@college_desc", TextBox6.Text.Trim());
           
            cmd.Parameters.AddWithValue("@college_img_link", filepath);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('College added successfully.');</script>");
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

   
}