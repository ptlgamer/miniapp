using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace quanlybangao.Classes
{
    public class SanPham
    {
        public SanPham(int idgao, string tenloai, string tengao, float giagao, float sokg)
        {
            this.Idgao = idgao;
            this.Tenloai = tenloai;
            this.Tengao = tengao;
            this.Giagao = giagao;
            this.Sokg = sokg;
        }

        public SanPham(int idloai, string tengao, float giagao, float sokg)
        {
            this.Idloai = idloai;
            this.Tengao = tengao;
            this.Giagao = giagao;
            this.Sokg = sokg;
        }

        public SanPham(DataRow row)
        {
            this.Idgao = (int)row["IDGAO"];
            this.Tenloai = row["TENLOAI"].ToString();
            this.Tengao = row["TENGAO"].ToString();
            
            this.Giagao = (float)Convert.ToDouble(row["GIAGAO"]);
            this.Sokg = (float)Convert.ToDouble(row["SOKG"]);
        }


        private int idgao;
        public int Idgao
        {
            get { return idgao; }
            set { idgao = value; }
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

        private float selectedkg;

        public float Selectedkg
        {
            get { return selectedkg; }
            set { selectedkg = value; }
        }
    }
}
