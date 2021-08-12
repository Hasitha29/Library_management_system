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
    public partial class StudentInformation : Form
    {
        public StudentInformation()
        {
            InitializeComponent();
        }

        private void StudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con=new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
            SqlCommand com=new SqlCommand();
            com.Connection = con;

            com.CommandText = "select *from NewStudent";
            SqlDataAdapter Da=new SqlDataAdapter(com);
            DataSet Ds = new DataSet();
            Da.Fill(Ds);

           dataGridView1.DataSource=Ds.Tables[0];


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
            SqlCommand com = new SqlCommand();
            com.Connection = con;

            com.CommandText = "select *from NewStudent where StuNo LIKE'"+textBox1.Text+"%'";
            SqlDataAdapter Da = new SqlDataAdapter(com);
            DataSet Ds = new DataSet();
            Da.Fill(Ds);
            dataGridView1.DataSource = Ds.Tables[0];
        }

        int bids;
        Int32 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {

                bids = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
                panel2.Visible = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                com.CommandText = "select *from NewStudent where Stuid=" + bids + "";
                SqlDataAdapter Da = new SqlDataAdapter(com);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);
                rowid = Int32.Parse(Ds.Tables[0].Rows[0][0].ToString());

                textSname.Text = Ds.Tables[0].Rows[0][1].ToString();
                textSno.Text = Ds.Tables[0].Rows[0][2].ToString();
                textDepar.Text = Ds.Tables[0].Rows[0][3].ToString();
                textSsem.Text = Ds.Tables[0].Rows[0][4].ToString();
                textScon.Text = Ds.Tables[0].Rows[0][5].ToString();
                textSemail.Text = Ds.Tables[0].Rows[0][6].ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string name = textSname.Text;
            string no = textSno.Text;
            string depart = textDepar.Text;
            string semester=textSsem.Text;
            Int32 contact = Int32.Parse(textScon.Text);
            string mail = textSemail.Text;

            if (MessageBox.Show("Data Will Be Updated", "Confirm.?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                com.CommandText = "update NewStudent set StuName='" + name + "',StuNo='" + no + "',StuDepart='" + depart + "',StuSem='" + semester + "',StuCont=" + contact + ",StuEmail='" + mail + "'where Stuid="+rowid+"";
                SqlDataAdapter Da = new SqlDataAdapter(com);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);

                panel2.Visible = false;
               // StudentInformation_Load(this, null);
                
            }
               
            }

        private void btnrefres_Click(object sender, EventArgs e)
        {
            StudentInformation_Load(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Deleted", "Confirm.?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                com.CommandText = "delete from NewStudent where Stuid=" + rowid + "";
                SqlDataAdapter Da = new SqlDataAdapter(com);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);

                StudentInformation_Load(this, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure Exit","Close",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
            this.Close();
            }
        }
            
        }
    
}
