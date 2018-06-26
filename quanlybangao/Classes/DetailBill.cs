using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Classes
{
    public class DetailBill
    {
        public DetailBill(int mahd, string ngay, float tongtien, int trangthai, 
            int manv, string tennv, 
            int makh, string tenkh, string diachi, int dienthoai,
            int idgao, string tengao, float giagao, float sokg)
        {
            this.Mahd = mahd;
            this.Ngay = ngay;
            this.Tongtien = tongtien;
            this.Trangthai = trangthai;
            this.Manv = manv;
            this.Tennv = tennv;
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Diachi = diachi;
            this.Dienthoai = dienthoai;
            this.Idgao = idgao;
            this.Tengao = tengao;
            this.Giagao = giagao;
            this.Sokg = sokg;
        }

        public DetailBill(DataRow row)
            : this((int)row["MAHD"], row["NGAY"].ToString(), (float)Convert.ToDouble(row["TONGTIEN"]), (int)row["TRANGTHAI"],
            (int)row["MANV"], row["TENNV"].ToString(), (int)row["MAKH"], row["TEN"].ToString(), row["DIACHI"].ToString(),
            (int)row["DIENTHOAI"], (int)row["IDGAO"], row["TENGAO"].ToString(), (float)Convert.ToDouble(row["GIAGAO"]), (float)Convert.ToDouble(row["SOKG"]))
        {

        }

        private int mahd;

        public int Mahd
        {
            get { return mahd; }
            set { mahd = value; }
        }
        private string ngay;

        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        private float tongtien;

        public float Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
        private int trangthai;

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private int manv;

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }
        private string tennv;

        public string Tennv
        {
            get { return tennv; }
            set { tennv = value; }
        }
        private int makh;

        public int Makh
        {
            get { return makh; }
            set { makh = value; }
        }
        private string tenkh;

        public string Tenkh
        {
            get { return tenkh; }
            set { tenkh = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private int dienthoai;

        public int Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }
        private int idgao;

        public int Idgao
        {
            get { return idgao; }
            set { idgao = value; }
        }
        private string tengao;

        public string Tengao
        {
            get { return tengao; }
            set { tengao = value; }
        }
        private float giagao;

        public float Giagao
        {
            get { return giagao; }
            set { giagao = value; }
        }
        private float sokg;

        public float Sokg
        {
            get { return sokg; }
            set { sokg = value; }
        }
    }
}
