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
    public partial class UC_AddItems : UserControl
    {
        Function function = new CoffeWinform.Function();
        String query;
        public UC_AddItems()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            query="insert into Items (name,category,price) values('"+txtItemName.Text+"','"+
                txtCategory.Text+"',"+txtPrice.Text+")";
            function.setData(query);
            this.clearAll();
        }

        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
        }
    }
}
