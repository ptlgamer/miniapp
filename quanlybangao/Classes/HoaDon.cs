using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Classes
{
    public class HoaDon
    {
        public HoaDon(int mahd, int makh, int manv, string ngay, float tongtien, int trangthai)
        {
            this.Mahd = mahd;
            this.Makh = makh;
            this.Manv = manv;
            this.Ngay = ngay;
            this.Tongtien = tongtien;
            this.Trangthai = trangthai;
        }

        public HoaDon(DataRow row)
        {
            this.Mahd = (int)row["MAHD"];
            this.Makh = (int)row["MAKH"];
            this.Manv = (int)row["MANV"];
            this.Ngay = row["NGAY"].ToString();
            this.Tongtien = (float)Convert.ToDouble(row["TONGTIEN"]);
            this.Trangthai = (int)row["TRANGTHAI"];
        }

        private int trangthai;

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        private float tongtien;

        public float Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
        private string ngay;

        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        private int manv;

        public int Manv
        {
            get { return manv; }
            set { manv = value; }
        }

        private int makh;
        public int Makh
        {
            get { return makh; }
            set { makh = value; }
        }

        private int mahd;

        public int Mahd
        {
            get { return mahd; }
            set { mahd = value; }
        }

    }
}
