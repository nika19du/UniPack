using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace CRUDWithEF
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd=new OpenFileDialog() { Filter="JPEG|*.jpg"})
            {
                if (ofd.ShowDialog()==DialogResult.OK)
                {
                    pic.Image = Image.FromFile(ofd.FileName);
                    Employee obj = employeeBindingSource.Current as Employee;
                    if(obj!=null)
                    {
                        obj.ImageUrl = ofd.FileName;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(ModelContext db=new ModelContext())
            {
                employeeBindingSource.DataSource = db.EmpList.ToList(); 
            }

            metroPanel.Enabled = false;

            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
                pic.Image = Image.FromFile(obj.ImageUrl);
         }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pic.Image = null;
            metroPanel.Enabled = true;
            employeeBindingSource.Add(new Employee());
            employeeBindingSource.MoveLast();
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = true;
            txtName.Focus();
            Employee obj = employeeBindingSource.Current as Employee;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            metroPanel.Enabled = false;
            employeeBindingSource.ResetBindings(false);
            Form1_Load(sender, e);
        }

        private void metroGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Employee obj = employeeBindingSource.Current as Employee;
            if (obj != null)
                pic.Image = Image.FromFile(obj.ImageUrl);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             if(MetroFramework.MetroMessageBox.Show(this,"Are You Sure Want To Delete This Record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes) 
            {
                using (ModelContext db=new ModelContext())
                {
                    Employee obj= employeeBindingSource.Current as Employee;

                    if (obj!=null)
                    {
                        if(db.Entry<Employee>(obj).State==EntityState.Detached)
                        {
                            db.Set<Employee>().Attach(obj);
                        }
                        db.Entry<Employee>(obj).State=EntityState.Deleted;
                        db.SaveChanges();
                        MetroFramework.MetroMessageBox.Show(this, "Deleted Successfully");
                        employeeBindingSource.RemoveCurrent();
                        metroPanel.Enabled = false;
                        pic.Image = null;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (ModelContext db=new ModelContext())
            {
                Employee obj = employeeBindingSource.Current as Employee;
                if(obj != null)
                {
                    if(db.Entry<Employee>(obj).State==EntityState.Detached)
                    {
                        db.Set<Employee>().Attach(obj);
                    }
                    if (obj.EmpID == 0)
                    {
                        db.Entry<Employee>(obj).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry<Employee>(obj).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    MetroFramework.MetroMessageBox.Show(this, "Saved Successfully");
                    metroGrid.Refresh();
                    metroPanel.Enabled=false;
                }
            }
        }
    }
}
