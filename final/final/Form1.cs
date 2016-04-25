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
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;

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
            // TODO: This line of code loads data into the 'dataSet1.WORK' table. You can move, or remove it, as needed.
            this.wORKTableAdapter.Fill(this.dataSet1.WORK);
            //BackColor = Color.Aquamarine;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Image myimage = new Bitmap(@"K:\Coding\DBS-Project\background.jpg");
            BackgroundImage = myimage;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            Hide();
            f2.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
