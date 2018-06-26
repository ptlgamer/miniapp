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
    public partial class AddRiceForm : Form
    {
        public AddRiceForm()
        {
            InitializeComponent();
        }

        private void AddRiceForm_Load(object sender, EventArgs e)
        {
            cbLoaiGao.DataSource = LoaiGaoDB.Instance.loadLoaiGao();
            cbLoaiGao.DisplayMember = "TENLOAI";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRowView data = (DataRowView)cbLoaiGao.SelectedItem;
            int idloai = (int)data.Row.ItemArray[0];


            if(txtTenGao.Text == "" || txtGiaGao.Text == "" || txtSoKg.Text == "")
            {
                MessageBox.Show("Please input info");
                return;
            }

            float giagao = 0;
            if(!float.TryParse(txtGiaGao.Text, out giagao))
            {
                MessageBox.Show("Giá gạo là số!");
                return;
            }

            float sokg = 0;
            if (!float.TryParse(txtSoKg.Text, out sokg))
            {
                MessageBox.Show("Số kg là số!");
                return;
            }

            SanPhamDB.Instance.addSanPham(new SanPham(idloai,txtTenGao.Text,giagao,sokg));

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
