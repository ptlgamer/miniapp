using quanlybangao.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using quanlybangao.Models;

namespace quanlybangao
{
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();
        }

        #region event
        private void fSanPham_Load(object sender, EventArgs e)
        {
            showSanPham();
        }

        void btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (e.Button == MouseButtons.Left)
            {
                if(btn.BackColor == Color.FromArgb(238,238,238))
                {
                    float value = 0;
                    string input = Interaction.InputBox("Nhập số lượng:", "Số lượng", "1");
                    if (float.TryParse(input, out value))
                    {
                        btn.BackColor = Color.Blue;
                        ((SanPham)btn.Tag).Selectedkg = value;
                    }
                }
                else
                {
                    btn.BackColor = Color.FromArgb(238, 238, 238);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                SanPham sp = (SanPham)btn.Tag;
                MessageBox.Show("  " + sp.Tenloai + "\n  " + sp.Sokg);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string ten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            if (ten == "" || diachi == "")
            {
                MessageBox.Show("Please input info!");
                return;
            }

            if(!itemSelected())
            {
                MessageBox.Show("Please select rice!");
                return;
            }

            int makh = addKhachHang();
            addHoaDon(makh);
            addTPHoaDon();

            fHoaDon fhoadon = new fHoaDon();
            fhoadon.ShowDialog();

            clearSelected();
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phạm Thành Lộc");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
        }

        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            billForm.ShowDialog();
        }

        private void addNewRiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRiceForm addRiceForm = new AddRiceForm();
            addRiceForm.ShowDialog();

            listViewGao.Controls.Clear();
            showSanPham();
        }

        #endregion

        #region method
        private void showSanPham()
        {
            List<SanPham> spList = SanPhamDB.Instance.loadSanPhamList();

            foreach (SanPham sp in spList)
            {
                Button btn = new Button() { Width = 150, Height = 150 };
                btn.Text = sp.Tengao + "\n" + sp.Giagao;
                btn.Tag = sp;
                btn.BackColor = Color.FromArgb(238, 238, 238);
                btn.ForeColor = Color.Red;
                btn.Font = new Font("Arial", 14f, FontStyle.Bold);
                btn.MouseUp += btn_MouseUp;

                listViewGao.Controls.Add(btn);
            }
        }

        private int addKhachHang()
        {
            string ten = txtTenKH.Text;
            string diachi = txtDiaChi.Text;
            int dienthoai = 0;
            Int32.TryParse(txtDienThoai.Text, out dienthoai);

            int makh = KhachHangDB.Instance.addKhachHang(ten, diachi, dienthoai);

            return makh;
        }

        private void addHoaDon(int makh)
        {
            HoaDonDB.Instance.addHoaDon(makh, 2);
        }

        private void addTPHoaDon()
        {   
            foreach(Button btn in listViewGao.Controls.OfType<Button>())
            {
                if(btn.BackColor == Color.Blue)
                {
                    SanPham sp = btn.Tag as SanPham;
                    HoaDonDB.Instance.addTPHoaDon(sp);
                }
            }
        }

        private bool itemSelected()
        {
            foreach (Button btn in listViewGao.Controls.OfType<Button>())
            {
                if (btn.BackColor == Color.Blue)
                {
                    return true;
                }
            }
            return false;
        }

        private void clearSelected()
        {
            foreach (Button btn in listViewGao.Controls.OfType<Button>())
            {
                if (btn.BackColor == Color.Blue)
                {
                    btn.BackColor = Color.FromArgb(238, 238, 238);
                }
            }
        }

        #endregion
    }
}
