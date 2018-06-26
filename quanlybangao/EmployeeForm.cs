using quanlybangao.Classes;
using quanlybangao.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybangao
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            showEmployee();
        }

        private void showEmployee()
        {
            List<Employee> employees = EmployeeDB.Instance.loadEmployee();
            dtgvEmployee.Rows.Add(employees.Count);

            int i = 0;
            foreach(Employee employee in employees)
            {
                dtgvEmployee.Rows[i].Cells["MaNV"].Value = employee.Manv;
                dtgvEmployee.Rows[i].Cells["TenNV"].Value = employee.Tennv;
                dtgvEmployee.Rows[i].Cells["DienThoai"].Value = employee.Dienthoai;
                i++;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int n = dtgvEmployee.Rows.Count;

            for(int i = 0; i < n - 1; i++)
            {
                int manv = (int)dtgvEmployee.Rows[i].Cells["MaNV"].Value;
                string tennv = dtgvEmployee.Rows[i].Cells["TenNV"].Value.ToString();
                int dienthoai = (int)dtgvEmployee.Rows[i].Cells["DienThoai"].Value;

                Employee employee = new Employee(manv, tennv, dienthoai);
                EmployeeDB.Instance.updateEmployee(employee);
            }

            this.Close();
        }
    }
}
