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

public partial class examinventory : System.Web.UI.Page
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
        getExamByID();
    }


    // update button click
    protected void Button3_Click(object sender, EventArgs e)
    {
        updateExamByID();
    }
    // delete button click
    protected void Button2_Click(object sender, EventArgs e)
    {
        deleteExamByID();
    }
    // add button click
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (checkIfExamExists())
        {
            Response.Write("<script>alert('Exam Already Exists, try some other Exam ID');</script>");
        }
        else
        {
            addNewExam();
        }
    }



    // user defined functions

    void deleteExamByID()
    {
        if (checkIfExamExists())
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from exam_master_tbl WHERE exam_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Exam Deleted Successfully');</script>");

                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('Invalid Exam ID');</script>");
        }
    }

    void updateExamByID()
    {

        if (checkIfExamExists())
        {
            try
            {


                string filepath = "~/exam_inventory/exams1";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename == null)
                {
                    filepath = global_filepath;

                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("exam_inventory/" + filename));
                    filepath = "~/exam_inventory/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE exam_master_tbl set exam_name=@exam_name, exam_stream=@exam_stream, exam_feature=@exam_feature, exam_date=@exam_date, exam_lastdate=@exam_lastdate, exam_url=@exam_url, exam_desc=@exam_desc, exam_img_link=@exam_img_link where exam_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@exam_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@exam_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@exam_stream", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@exam_feature", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@exam_date", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@exam_lastdate", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@exam_url", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@exam_desc", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@exam_img_link", filepath);


                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Exam Updated Successfully');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid Exam ID');</script>");
        }
    }


    void getExamByID()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * from exam_master_tbl WHERE exam_id='" + TextBox1.Text.Trim() + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                TextBox2.Text = dt.Rows[0]["exam_name"].ToString();
                TextBox3.Text = dt.Rows[0]["exam_url"].ToString();
                TextBox4.Text = dt.Rows[0]["exam_lastdate"].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["exam_desc"].ToString();
                TextBox7.Text = dt.Rows[0]["exam_date"].ToString();


                DropDownList1.SelectedValue = dt.Rows[0]["exam_stream"].ToString().Trim();
                DropDownList2.SelectedValue = dt.Rows[0]["exam_feature"].ToString().Trim();

                global_filepath = dt.Rows[0]["exam_img_link"].ToString();

            }
            else
            {
                Response.Write("<script>alert('Invalid Exam ID');</script>");
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

    bool checkIfExamExists()
    {
        try
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * from exam_master_tbl where exam_id='" + TextBox1.Text.Trim() + "' OR exam_name='" + TextBox2.Text.Trim() + "';", con);
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

    void addNewExam()
    {
        try
        {

            string filepath = "~/exam_inventory/exams1.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("exam_inventory/" + filename));
            filepath = "~/exam_inventory/" + filename;


            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO exam_master_tbl(exam_id,exam_name,exam_stream,exam_feature,exam_date,exam_lastdate,exam_url,exam_desc,exam_img_link) values(@exam_id,@exam_name,@exam_stream,@exam_feature,@exam_date,@exam_lastdate,@exam_url,@exam_desc,@exam_img_link)", con);

            cmd.Parameters.AddWithValue("@exam_id", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@exam_name", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@exam_stream", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@exam_feature", DropDownList2.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@exam_date", TextBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@exam_lastdate", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@exam_url", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@exam_desc", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@exam_img_link", filepath);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Exam added successfully.');</script>");
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
   
}