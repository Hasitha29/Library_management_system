using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class View_Book : Form
    {
        public View_Book()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void View_Book_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
        SqlConnection con=new SqlConnection();
        con.ConnectionString = "data source= DESKTOP-IGBAERS;database=master;integrated security=True";
            SqlCommand com=new SqlCommand();
            com.Connection = con;

            com.CommandText = "select * from Addbook";
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }
        int bid;
        Int32 rowID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-IGBAERS;database=master;integrated security=True";
            SqlCommand com = new SqlCommand();
            com.Connection = con;

            com.CommandText = "select * from Addbook where bid="+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowID=Int32.Parse(ds.Tables[0].Rows[0][0].ToString());

            texName.Text = ds.Tables[0].Rows[0][1].ToString();
            texAuthName.Text = ds.Tables[0].Rows[0][2].ToString();
            texpublica.Text = ds.Tables[0].Rows[0][3].ToString();
            texPuchD.Text = ds.Tables[0].Rows[0][4].ToString();
            texPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            texQuanti.Text = ds.Tables[0].Rows[0][6].ToString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void texBookName_TextChanged(object sender, EventArgs e)
        {
            if (texBookName.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                com.CommandText = "select * from Addbook where bName LIKE'"+texBookName.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
               SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                com.CommandText = "select * from Addbook";
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            texBookName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Will Be Updated", "Confirm.?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bName = texName.Text;
                string bAuthName = texAuthName.Text;
                string bPublicat = texpublica.Text;
                string bPurD = texPuchD.Text;
                Int32 bPrice = Int32.Parse(texPrice.Text);
                Int32 bQuntity = Int32.Parse(texQuanti.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                com.CommandText = "update Addbook set bName='" + bName + "',bAuthor='" + bAuthName + "',bPubl='" + bPublicat + "',bDate='" + bPurD + "',bPrice=" + bPrice + ",bQuanti=" + bQuntity + "where bId= " + rowID + "";
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Data Will Be Delete", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                com.CommandText = "delete from Addbook where bId= "+rowID+"";
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
