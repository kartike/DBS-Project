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


namespace newstart
{
    public partial class Form4 : Form
    {
        OracleConnection conn;

        public Form4()
        {
            InitializeComponent();
        }

        public void connectt()
        {
            string oradb = "Data Source=Kartike;User ID=orcl;Password=Kartike123";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectt();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;

            long id = long.Parse(textBox1.Text);
            long qty = long.Parse(textBox2.Text);
            double sp = double.Parse(textBox4.Text);

            cm.CommandText = "insert into inventory values('" + id + "' ,'" + qty + "' ,'" + textBox3.Text + "' ,'" + sp + "' )";

            cm.ExecuteNonQuery();
            MessageBox.Show("New Spare-Part Added!");
            cm.CommandText = "commit";
            cm.ExecuteNonQuery();;
            conn.Close();

            this.iNVENTORYTableAdapter.Fill(this.dataSet1.INVENTORY);


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.REQUEST' table. You can move, or remove it, as needed.
            this.rEQUESTTableAdapter.Fill(this.dataSet1.REQUEST);
            // TODO: This line of code loads data into the 'dataSet1.INVENTORY' table. You can move, or remove it, as needed.
            this.iNVENTORYTableAdapter.Fill(this.dataSet1.INVENTORY);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connectt();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;

            long id = long.Parse(textBox5.Text);
            long qty = long.Parse(textBox6.Text);
            double sp = double.Parse(textBox7.Text);
            string datee = DateTime.Today.ToString("dd-MMMM-yy");
            cm.CommandText = "insert into request values('" + id + "' ,'" + qty + "' ,'" + sp + "' ,'" + datee + "','" + textBox8.Text + "'  )";

            cm.ExecuteNonQuery();
            MessageBox.Show("New Request Added!");
            cm.CommandText = "commit";
            cm.ExecuteNonQuery(); ;
            conn.Close();

            this.rEQUESTTableAdapter.Fill(this.dataSet1.REQUEST);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            Hide();
            f2.ShowDialog();
        }
    }
}
