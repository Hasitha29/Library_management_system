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
    public partial class addStudent : Form
    {
        public addStudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Exit.?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
            
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            texName.Clear();
            texStuNo.Clear();
            texDepart.Clear();
            texSemester.Clear();
            texContact.Clear();
            texEmail.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (texName.Text!=""&&texStuNo.Text!=""&&texDepart.Text!=""&&texSemester.Text!=""&&texContact.Text!=""&&texEmail.Text!="")
            {
                string name = texName.Text;
                string no = texStuNo.Text;
                string depart = texDepart.Text;
                string semester = texSemester.Text;
                Int32 contact = Int32.Parse(texContact.Text);
                string email = texEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                con.Open();
                com.CommandText = "insert into NewStudent(StuName,StuNo,StuDepart,StuSem,StuCont,StuEmail) values('" + name + "','" + no + "','" + depart + "','" + semester + "'," + contact + ",'" + email + "')";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Enter Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Please Fill Empty Feild", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
        }
    }
}
