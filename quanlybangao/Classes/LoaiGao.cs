using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Classes
{
    public class LoaiGao
    {
        public LoaiGao(int idloai, string tenloai)
        {
            this.Idloai = idloai;
            this.Tenloai = tenloai;
        }

        public LoaiGao(DataRow row)
        {
            this.Idloai = (int)row["IDLOAI"];
            this.Tenloai = row["TENLOAI"].ToString();
        }

        private int idloai;

        public int Idloai
        {
            get { return idloai; }
            set { idloai = value; }
        }
        private string tenloai;

        public string Tenloai
        {
            get { return tenloai; }
            set { tenloai = value; }
        }
    }
}
