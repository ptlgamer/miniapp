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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            showCustomer();
        }

        private void showCustomer()
        {
            List<KhachHang> customers = KhachHangDB.Instance.loadKhachHang();
            dtgvCustomer.Rows.Add(customers.Count);

            int i = 0;
            foreach(KhachHang customer in customers)
            {
                dtgvCustomer.Rows[i].Cells["MaKh"].Value = customer.Id;
                dtgvCustomer.Rows[i].Cells["TenKh"].Value = customer.Ten;
                dtgvCustomer.Rows[i].Cells["DiaChi"].Value = customer.Diachi;
                dtgvCustomer.Rows[i].Cells["DienThoai"].Value = customer.Dienthoai;
                i++;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int n = dtgvCustomer.Rows.Count;

            for(int i = 0; i < n - 1; i++)
            {
                int id = (int)dtgvCustomer.Rows[i].Cells["MaKh"].Value;
                string tenkh = dtgvCustomer.Rows[i].Cells["TenKh"].Value.ToString();
                string diachi = dtgvCustomer.Rows[i].Cells["DiaChi"].Value.ToString();
                int dienthoai = (int)dtgvCustomer.Rows[i].Cells["DienThoai"].Value;

                KhachHangDB.Instance.updateKhachHang(id, tenkh, diachi, dienthoai);
            }

            this.Close();
        }
    }
}
