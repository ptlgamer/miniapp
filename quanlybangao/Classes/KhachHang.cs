using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Classes
{
    public class KhachHang
    {
        public KhachHang(int id, string ten, string diachi, int dienthoai)
        {
            this.Id = id;
            this.Ten = ten;
            this.Diachi = diachi;
            this.Dienthoai = dienthoai;
        }

        public KhachHang(DataRow row)
        {
            this.Id = (int)row["MAKH"];
            this.Ten = row["TEN"].ToString();
            this.Diachi = row["DIACHI"].ToString();
            this.Dienthoai = (int)row["DIENTHOAI"];
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
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
    }
}
