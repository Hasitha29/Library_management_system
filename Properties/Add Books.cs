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
    public partial class Add_Books : Form
    {
        public Add_Books()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (texName.Text != "" && texAuthName.Text != "" && texPrice.Text != "" && texQuantity.Text != "")
            {
                string bookName = texName.Text;
                string bookAuth = texAuthName.Text;
                string bookPubli = texPublication.Text;
                string bookDate = texPurDate.Text;
                Int32 bookPrice = Int32.Parse(texPrice.Text);
                Int32 bookQuntitiy = Int32.Parse(texQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-IGBAERS;database=master;integrated security=True";
                SqlCommand com = new SqlCommand();
                com.Connection = con;

                con.Open();
                com.CommandText = "insert into Addbook (bName,bAuthor,bPubl,bDate,bPrice,bQuanti)values('" + bookName + "','" + bookAuth + "','" + bookPubli + "','" + bookDate + "','" + bookPrice + "','" + bookQuntitiy + "')";
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                texName.Clear();
                texAuthName.Clear();
                texPublication.Clear();
                texPrice.Clear();
                texQuantity.Clear();
            }
            else 
            {
                MessageBox.Show("Empty Field Not Allowed", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This Will Delete Unsave Data.", "Are You Sure Exit.?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}