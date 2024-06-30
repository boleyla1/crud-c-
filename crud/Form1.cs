using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.human.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public db db = new db();
        bool b = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (b == false)
            {
                human human = new human()
                { name = textBox1.Text, family = textBox2.Text, job = textBox3.Text };
                bool b = human.register(human);
                if (b)
                {
                    MessageBox.Show("register succsesfuly");
                }
                else
                {
                    MessageBox.Show("register is feild");
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = human.readbyall();
            }
            else
            {
                if (id != 0)
                {
                    human human = new human()
                    { name = textBox1.Text, family = textBox2.Text, job = textBox3.Text };
                    human.update(id, human);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = human.readbyall();
                }
                button1.Text = "register";
                b = false;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            human humans = new human();
            {
                if (textBox4.Text == "")
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = humans.readbyall();
                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = humans.readbyname(textBox4.Text);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public int id=0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id =(int) dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            human human = new human();
            human = human.readbyid(id);
            textBox1 .Text = human.name;
            textBox2.Text = human.family;
            textBox3.Text = human.job;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            human human = new human();
            DialogResult = MessageBox.Show("do you want delete this","warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                if (id != 0)
                {
                    human.delete(id);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = human.readbyall();
                }
                else
                {
                    MessageBox.Show("please select human");
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        { 
         button1.Text = "update";
         b = true;
            
        }
    }
}
