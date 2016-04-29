using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace final
{
    public partial class Form2 : Form
    {
        OracleConnection conn;
        /*OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        */
        public Form2()
        {
            InitializeComponent();
        }
        public void connectt()
        {
            string oradb = "Data Source=Kartike;User ID=orcl;Password=Kartike123";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            Hide();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectt();
            Random rnd = new Random();
            int empid = rnd.Next(10000000,99999999);
            long mob= 9999999999;
            mob = long.Parse(textBox2.Text);
            int engg = 0;

            if(radioButton1.Checked==true)
            {
                engg = 1;
            }
            else if(radioButton2.Checked==true)
            {
                engg = 0;
            }
            string empp = empid.ToString();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            cm.CommandText = "insert into employee values('"+ empp + "' ,'" + textBox1.Text + "','" +mob + "' ,'"+textBox3.Text + "' ,'"+ textBox4.Text + "','"+ 0 + "','"+ engg +"' )";

            cm.ExecuteNonQuery();
            MessageBox.Show("New Employee Added!");
            cm.CommandText = "commit";
            cm.ExecuteNonQuery();
            MessageBox.Show("Commit done");
            conn.Close();
            this.eMPLOYEETableAdapter.Fill(this.dataSet1.EMPLOYEE);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.EMPLOYEE' table. You can move, or remove it, as needed.
            eMPLOYEETableAdapter.Fill(dataSet1.EMPLOYEE);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
