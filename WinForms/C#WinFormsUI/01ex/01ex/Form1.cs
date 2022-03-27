using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.Black;
            var temp= MessageBox.Show("Are you sure you want to leave?", "Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(temp==DialogResult.Yes)
            this.Close();  
            
        }
         
        private void btnNew_MouseEnter(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.Red;
            btnExit.BackColor = Color.White;
        }

        private void btnEditText_Click(object sender, EventArgs e)
        {
            lab.Text = "Nicole";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            double firstN= Double.Parse(txtFirstN.Text);
            double secN = Double.Parse(txtLastN.Text);
            double sum = firstN + secN;
            txtSum.Text =sum.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstN.Text = "";
            txtLastN.Text = "";
            txtSum.Text = ""; 

        }
         //MessageBox.Show("","")
    }
}
