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
    public partial class fHoaDon : Form
    {
        List<DetailBill> dbList;
        public fHoaDon()
        {
            InitializeComponent();
        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {
            showDetailBill();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            updateDetailBill();

            this.Close();
        }

        private void showDetailBill()
        {
            dbList = HoaDonDB.Instance.loadDetailBill(-1);
           
            txtTenKH.Text = dbList[0].Tenkh;
            txtDiaChi.Text = dbList[0].Diachi;
            txtDienThoai.Text = dbList[0].Dienthoai.ToString();
            txtNgay.Text = dbList[0].Ngay;
            txtTotal.Text = dbList[0].Tongtien.ToString();
            txtXacNhan.Text = dbList[0].Trangthai == 1 ? "Đã thanh toán" : "Chưa thanh toán";
            txtNhanVien.Text = dbList[0].Tennv;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("TenGao");
            dataTable.Columns.Add("GiaGao");
            dataTable.Columns.Add("SoKg");
            dataTable.Columns.Add("ThanhTien");

            DataRow newRow;
            foreach(DetailBill db in dbList)
            {
                newRow = dataTable.NewRow();
                newRow["TenGao"] = db.Tengao;
                newRow["GiaGao"] = db.Giagao;
                newRow["SoKg"] = db.Sokg;
                newRow["ThanhTien"] = (db.Sokg * db.Giagao);

                dataTable.Rows.Add(newRow);
            }

            dtgvTPHoaDon.DataSource = dataTable;
        }

        private void updateDetailBill()
        {
            int i = 0;
            foreach(DetailBill db in dbList)
            {
                db.Tenkh = txtTenKH.Text;
                db.Diachi = txtDiaChi.Text;
                int dienthoai;
                db.Dienthoai = Int32.TryParse(txtDienThoai.Text, out dienthoai) ? dienthoai : 0;

                db.Ngay = txtNgay.Text;
                db.Trangthai = txtXacNhan.Text == "Đã thanh toán" ? 1 : 0;

                db.Sokg = (float)Convert.ToDouble(dtgvTPHoaDon.Rows[i].Cells["SoKg"].Value);
                i++;
            }

            HoaDonDB.Instance.updateDetailBill(dbList);
        }
    }
}
