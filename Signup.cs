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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text != "" && txtpasw.Text != "")
            {
                string sname = txtname.Text;
                string spasw = txtpasw.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                con.Open();
                com.CommandText = "insert into loginTable(username,pass)values('" + sname + "','" + spasw + "')";
                com.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("You are sign up", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();

            }
            else
            {
                MessageBox.Show("Plese Enter User Name and Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
      
    }
  
}
