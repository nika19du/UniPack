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
    public partial class UC_RemoveItem : UserControl
    {
        public UC_RemoveItem()
        {
            InitializeComponent();
        }

        CoffeWinform.Function fn = new Function();
        String query;
        private void UC_RemoveItem_Load(object sender, EventArgs e)
        {
            DelLabel.Text = "How to DELETE?";
            DelLabel.ForeColor = Color.Blue;
            loadData();
        }

        public void loadData()
        {
            query = "select*from items";
            DataSet dataSet = fn.getData(query);
            guna2DataGridView1.DataSource = dataSet.Tables[0];

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            query = "select*from items where name like'" + txtSearch.Text + "%'";
            DataSet dataSet = fn.getData(query);
            guna2DataGridView1.DataSource = dataSet.Tables[0];
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Delete item?","Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {//when user enter ok we delete it
                int id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //we delete that row with that id
                query="delete from items where id="+id+"";
                fn.setData(query);
                loadData();
            }
        }

        private void DelLabel_Click(object sender, EventArgs e)
        {
            DelLabel.ForeColor = Color.Red;
            DelLabel.Text = "*Click on Row to Delete the Item.";
        }

        private void UC_RemoveItem_Enter(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
