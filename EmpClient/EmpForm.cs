using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpClient
{
    public partial class EmpForm : Form
    {
        public EmpForm()
        {
            InitializeComponent();
        }

        private void EmpForm_Load(object sender, EventArgs e)
        {
            List<Emp> list = new EmpBUS().GetAll();
            EmpGrid.DataSource = list;
        }

        private void EmpGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (EmpGrid.SelectedRows.Count == 1)
            {
                int id = int.Parse(EmpGrid.SelectedRows[0].Cells["ID"].Value.ToString());
                Emp emp = new EmpBUS().GetEmps(id);
                if (emp != null)
                {
                    txtID.Text = emp.ID.ToString();
                    txtName.Text = emp.Name;
                    txtAddress.Text = emp.Address;
                    txtAge.Text = emp.Age.ToString();
                    txtSalary.Text = emp.Salary.ToString();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Emp employee = new Emp()
            {
                ID = 0,
                Name = txtName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Age = int.Parse(txtAge.Text.Trim()),
                Salary = int.Parse(txtSalary.Text.Trim()),

            };
            bool result = new EmpBUS().Add(employee);
            if (result)
            {
                List<Emp> list = new EmpBUS().GetAll();
                EmpGrid.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(txtID.Text.Trim());
                bool res = new EmpBUS().Delete(ID);
                if (res)
                {
                    List<Emp> list = new EmpBUS().GetAll();
                    EmpGrid.DataSource = list;

                }
                else
                {
                    MessageBox.Show("no value");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Emp employee = new Emp()
            {
                ID = int.Parse(txtID.Text.Trim()),
                Name = txtName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Age = int.Parse(txtAge.Text.Trim()),
                Salary = int.Parse(txtSalary.Text.Trim()),

            };
            bool result = new EmpBUS().Update(employee);
            if (result)
            {
                List<Emp> list = new EmpBUS().GetAll();
                EmpGrid.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Emp> employees = new EmpBUS().Search(keyword);
            EmpGrid.DataSource = employees;
        }
    }
}