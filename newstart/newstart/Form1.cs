using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newstart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string pass = textBox2.Text;
            if(id=="admin"&& pass=="admin")
            {
                MessageBox.Show("Login Successful!");
                var f2 = new Form2();
                Hide();
                f2.ShowDialog();
            }
            else if (id == "admin")
            {
                MessageBox.Show("Enter Correct Password!");
            }

            else if (id==""& pass=="")
            {
                MessageBox.Show("Enter details to Login!");
            }
            else
            {
                MessageBox.Show("Incorrect Login!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
