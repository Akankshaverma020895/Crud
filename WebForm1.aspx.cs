using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Crud
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "insert into crud values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
            SqlConnection cn = new SqlConnection(@"Data Source = Akku; Initial Catalog = Crud; Integrated Security = True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("Data inserted");
            }
            else
            {
                Response.Write("Data not inserted");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = "Update crud set Name='" + TextBox1.Text + "',City='" + TextBox2.Text + "',Address='" + TextBox3.Text + "'where id=" + TextBox4.Text;
            SqlConnection cn = new SqlConnection(@"Data Source = Akku; Initial Catalog = Crud; Integrated Security = True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("Data updated");
            }
            else
            {
                Response.Write("Data not updated");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string s = "Delete from crud where id=" + TextBox4.Text;
            SqlConnection cn = new SqlConnection(@"Data Source = Akku; Initial Catalog = Crud; Integrated Security = True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(s,cn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                Response.Write("Data deleted");
            }
            else
            {
                Response.Write("Data not deleted");
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string s = "select Name,City,Address from crud where id =" + TextBox4.Text;
            SqlConnection cn = new SqlConnection(@"Data Source = Akku; Initial Catalog = Crud; Integrated Security = True");
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TextBox1.Text = dr[0].ToString();
                TextBox2.Text= dr[1].ToString();
                TextBox3.Text= dr[2].ToString();
            }
            else
            {
                Response.Write("Data not found");
            }
        }
    }
}