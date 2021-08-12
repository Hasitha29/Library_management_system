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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void texUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (texUserName.Text == "User Name")
            {
                texUserName.Clear();
            }
        }

        private void texPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (texPassword.Text == "Password")
            {
                texPassword.Clear();
                texPassword.PasswordChar = '*'; 
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-IGBAERS ; database=master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from loginTable where username='" + texUserName.Text + "'and pass='" + texPassword.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();

            }
            else {
                MessageBox.Show("Worong Username OR Password", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup snp = new Signup();
            snp.Show();
            
           
            
            
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
