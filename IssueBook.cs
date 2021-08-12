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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from Addbook", con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    combBname.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textStudentNo.Text != "")
            {
                string eid = textStudentNo.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select *from NewStudent where StuNo='" + eid + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //-----------------------------------------

                //count issue books

                cmd.CommandText = "select count(Std_no)from IRBook where Std_no='" + eid + "'and book_return_date is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);

                count=int.Parse(ds1.Tables[0].Rows[0][0].ToString());





                if (ds.Tables[0].Rows.Count != 0)
                {
                    textName.Text = ds.Tables[0].Rows[0][1].ToString();
                    textDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
                    textSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    textContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    textEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    textName.Text = "";
                    textSemester.Clear();
                    textDepartment.Clear();
                    textEmail.Clear();
                    textContact.Clear();

                    MessageBox.Show("Invalid Data", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (textName.Text != "")
            {
                if (combBname.SelectedIndex != -1 && count<= 2)
                {
                    string snumb = textStudentNo.Text;
                    string sname = textName.Text;
                    string sdepart = textDepartment.Text;
                    string ssem = textSemester.Text;
                    Int32 scontact = Int32.Parse(textContact.Text);
                    string semail = textEmail.Text;
                    string bookname = combBname.Text;
                    string bookissudate = datetext.Text;


                    string eid = textStudentNo.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IRBook (std_no,std_name,std_dep,std_sem,std_contact,std_email,book_name,book_issue_date)values('" + snumb + "','" + sname + "','" + sdepart + "','" + ssem + "'," + scontact + ",'" + semail + "','" + bookname + "','" + bookissudate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textStudentNo.Clear();

                }
                else
                {
                    MessageBox.Show("Book is Not Selected Or Maximum Number of Books has been Issued", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Enter Valid Studen No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textStudentNo_TextChanged(object sender, EventArgs e)
        {
            if (textStudentNo.Text == "")
            {
                textName.Text = "";
                textSemester.Clear();
                textDepartment.Clear();
                textEmail.Clear();
                textContact.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            textStudentNo.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure Exit.","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes){
                
                       this.Close();
            }
        }
    }
}
