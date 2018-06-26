using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Classes
{
    public class Employee
    {
        public Employee(int manv, string tennv, int dienthoai)
        {
            this.Manv = manv;
            this.Tennv = tennv;
            this.Dienthoai = dienthoai;
        }

        public Employee(DataRow row) : this((int)row["MANV"], row["TENNV"].ToString(), (int)row["DIENTHOAI"])
        {}

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
        private int dienthoai;

        public int Dienthoai
        {
            get { return dienthoai; }
            set { dienthoai = value; }
        }
    }
}
