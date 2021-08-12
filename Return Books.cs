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
    public partial class Return_Books : Form
    {
        public Return_Books()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SqlConnection con =new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IRBook where std_no='" + texsearch.Text + "'and book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Student Number or No Book Issued", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void Return_Books_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            texsearch.Clear();
        }

        string bname;
        string bdate;
        Int32 rowid;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            texbname.Text = bname;
            texidate.Text = bdate;

        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update IRBook set book_return_date='"+dateTimePicker+"'where std_no='"+texsearch.Text+"'and id="+rowid+"";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Return Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Return_Books_Load(this, null);
        }

        private void texsearch_TextChanged(object sender, EventArgs e)
        {
            if (texsearch.Text == "")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            texsearch.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure Exit.","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
