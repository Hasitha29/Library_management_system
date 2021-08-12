using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentInformation stuI = new StudentInformation();
            stuI.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit.","confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)

            Application.Exit();
        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Books abs = new Add_Books();
            abs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Book vbs = new View_Book();
            vbs.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStudent adds = new addStudent();
            adds.Show();
        }

        private void issuerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook ib = new IssueBook();
            ib.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_Books rb = new Return_Books();
            rb.Show();
        }

        private void completeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Complete_Book_Details cbd = new Complete_Book_Details();
            cbd.Show();
        }
    }
}
