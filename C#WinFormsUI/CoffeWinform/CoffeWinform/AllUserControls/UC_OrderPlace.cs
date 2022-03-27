using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeWinform.AllUserControls
{
    public partial class UC_OrderPlace : UserControl
    {
        Function fn = new CoffeWinform.Function();
        String query;

        public UC_OrderPlace()
        {
            InitializeComponent();
        }

        private void uC_PlaceOrder1_Load(object sender, EventArgs e)
        {

        }
        private void showItemList(String query)
        {
            listBox1.Items.Clear();
            DataSet dataSet = fn.getData(query);
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantityUpDown.ResetText();
            txtTotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            txtName.Text = text;

            query = "select price from items where name='" + text + "'";
            DataSet dataSet = fn.getData(query);
            try
            {
                txtPrice.Text = dataSet.Tables[0].Rows[0][0].ToString();
            }
            catch { }

        }

        private void comboCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            String category = comboCateg.Text;
            query = "Select name from items where category ='" + category + "'";
            showItemList(query);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                listBox1.Items.Clear();
                String category = comboCateg.Text;
                query = "Select name from items where category ='" + category + "' and name like '" + txtSearch.Text + "%'";
                showItemList(query);
            }
        }

        private void txtQuantityUpDown_ValueChanged(object sender, EventArgs e)
        {
            decimal quan = decimal.Parse(txtQuantityUpDown.Value.ToString());
            decimal price = decimal.Parse(txtPrice.Text);

            txtTotal.Text = (quan * price).ToString();
        }

        protected int n=0;
        protected decimal total = 0; 
        private void btnAddCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = txtName.Text;
                guna2DataGridView1.Rows[n].Cells[1].Value = txtPrice.Text;
                guna2DataGridView1.Rows[n].Cells[2].Value = txtQuantityUpDown.Text;
                guna2DataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;

                total += int.Parse(txtTotal.Text);
                labelTotalAmount.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Minimal Quantity need to be 1","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        decimal amount;

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
            }
            catch  {   }
            total -=  amount;
            labelTotalAmount.Text = "Rs. " + total;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = decimal.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch  {   }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter  printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = String.Format("Date: {0}", DateTime.UtcNow.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Pauble Amount:" + labelTotalAmount.Text;
            printer.PrintDataGridView(guna2DataGridView1);

            total = 0;
            guna2DataGridView1.Rows.Clear();
            labelTotalAmount.Text = "Rs. " + total;
        }
    }
}
