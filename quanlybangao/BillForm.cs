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
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            showBill();
        }

        private void showBill()
        {
            dtgvBill.DataSource = HoaDonDB.Instance.loadDetailBill();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int n = dtgvBill.Rows.Count;

            for(int i = 0; i < n - 1; i++)
            {
                int mahd = (int)dtgvBill.Rows[i].Cells["MAHD"].Value;
                int trangthai = (int)dtgvBill.Rows[i].Cells["TRANGTHAI"].Value;

                HoaDonDB.Instance.updateStatusBill(mahd, trangthai);
            }

            this.Close();
        }
    }
}
