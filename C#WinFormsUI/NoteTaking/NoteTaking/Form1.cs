using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {//creating columns when form is starting
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Messages", typeof(string));

            dgvNote.DataSource = table;

            dgvNote.Columns["Messages"].Visible = false;
            dgvNote.Columns["Title"].Width = 346;


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtMessage.Text);
            //clear the input fields
           // btnNew.PerformClick();
            this.btnNew_Click(this,e);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int index = dgvNote.CurrentCell.RowIndex;//taking from grid index
            if (index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dgvNote.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }

        private void dgvNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnRead_Click(this, e);
        }
    }
}
