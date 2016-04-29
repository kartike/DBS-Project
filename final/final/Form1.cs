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
    public partial class Form1 : Form
    {
        OracleConnection conn;
        /*OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        */
        public Form1()
        {
            InitializeComponent();
        }
        public void connectt()
        {
            string oradb = "Data Source=Kartike;UserID=orcl;Password=Kartike123;Unicode=True";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet11.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter.Fill(this.dataSet1.EMPLOYEE);
            // TODO: This line of code loads data into the 'dataSet1.WORK' table. You can move, or remove it, as needed.
            this.wORKTableAdapter.Fill(this.dataSet1.WORK);
            //BackColor = Color.Aquamarine;
        }

        private void label1_Click(object sender, EventArgs e)
        {}

        private void groupBox1_Enter(object sender, EventArgs e)
        {}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {}

        private void label1_Click_1(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            Hide();
            f2.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {}

        private void button4_Click(object sender, EventArgs e)
        {
            connectt();
            Random rnd = new Random();

            int jobid = rnd.Next(10000000, 99999999);
            string job = jobid.ToString();

            long mob = 9999999999;
            mob = long.Parse(textBox2.Text);
            
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;

            cm.CommandText = "insert into work values('" + job + "' ,'" + textBox2.Text + "' ,'" + textBox1.Text + "','" + textBox3.Text + "' ,'" + mob + "' ,'" + textBox4.Text + "','" + 0 + "' )";

            cm.ExecuteNonQuery();
            MessageBox.Show("New JobSheet Added!");
            cm.CommandText = "commit";
            cm.ExecuteNonQuery();
            MessageBox.Show("Commit done");
            conn.Close();
            this.wORKTableAdapter.Fill(this.dataSet1.WORK);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void eMPLOYEEBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.eMPLOYEETableAdapter.FillBy2(this.dataSet1.EMPLOYEE);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
