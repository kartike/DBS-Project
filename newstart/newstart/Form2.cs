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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace newstart
{
    public partial class Form2 : Form
    {
        OracleConnection conn;
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

        public string var;

        public void button1_Click(object sender, EventArgs e)
        {
            connectt();
            Random rnd = new Random();
            int jobid = rnd.Next(10000000, 99999999);
            string job = jobid.ToString();

            long prod = long.Parse(textBox1.Text);
            long mob = long.Parse(textBox4.Text);

            string datee = DateTime.Today.ToString("dd-MMMM-yy");
            //long engg = long.Parse(textBox7.Text);
            //string var;
            var = comboBox1.Text;
            long aa = long.Parse(var);


            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
             
            cm.CommandText = "insert into work values('" + job + "' ,'" + prod + "' ,'" + textBox2.Text + "','" + textBox3.Text + "' ,'" + mob + "' ,'" + textBox4.Text + "','" +datee + "' ,'" + textBox6.Text + "','" + 0 + "','" + aa + "','" + 0 + "')";

            cm.ExecuteNonQuery();
            MessageBox.Show("New JobSheet Added!");
            cm.CommandText = "commit";
            cm.ExecuteNonQuery();
            MessageBox.Show("Commit done");
            conn.Close();
            wORKTableAdapter.Fill(dataSet1.WORK);
            eMPLOYEETableAdapter.Fill(dataSet1.EMPLOYEE);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.WORK_PART' table. You can move, or remove it, as needed.
            this.wORK_PARTTableAdapter.Fill(this.dataSet1.WORK_PART);
            // TODO: This line of code loads data into the 'dataSet1.INVENTORY' table. You can move, or remove it, as needed.
            this.iNVENTORYTableAdapter.Fill(this.dataSet1.INVENTORY);
            // TODO: This line of code loads data into the 'dataSet1.EMPLOYEE' table. You can move, or remove it, as needed.
            eMPLOYEETableAdapter.Fill(dataSet1.EMPLOYEE);
            // TODO: This line of code loads data into the 'dataSet1.WORK' table. You can move, or remove it, as needed.
            wORKTableAdapter.Fill(dataSet1.WORK);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f3 = new Form3();
            Hide();
            f3.ShowDialog();
        }

        public void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("K:/pdftest.pdf", FileMode.Create));
                doc.Open();
                Paragraph p1 = new Paragraph(var);
                doc.Add(p1);
                doc.Close();
                MessageBox.Show("PDF file created");
            }
            catch(Exception )
            {

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f4 = new Form4();
            Hide();
            f4.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            connectt();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;

            string var1 = comboBox2.Text;
            long aa = long.Parse(var1);
            string var2 = comboBox3.Text;
            long aaa = long.Parse(var2);

            cm.CommandText = "insert into work_part values('" + aa + "' ,'" + aaa + "' )";

            cm.ExecuteNonQuery();
            MessageBox.Show("New SparePart Included!");
            cm.CommandText = "commit";
            cm.ExecuteNonQuery();
            conn.Close();
            wORK_PARTTableAdapter.Fill(dataSet1.WORK_PART);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
