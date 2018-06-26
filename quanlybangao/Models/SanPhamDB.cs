using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using quanlybangao.Classes;
using System.Data;

namespace quanlybangao.Models
{
    public class SanPhamDB
    {
        private static SanPhamDB instance;

        public static SanPhamDB Instance
        {
            get 
            {
                if (instance == null)
                    instance = new SanPhamDB();

                return SanPhamDB.instance; 
            }
            private set { SanPhamDB.instance = value; }
        }

        public List<SanPham> loadSanPhamList()
        {
            List<SanPham> spList = new List<SanPham>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC sp_SANPHAM");

            foreach(DataRow row in data.Rows)
            {
                SanPham sp = new SanPham(row);
                spList.Add(sp);
            }

            return spList;
        }

        public void addSanPham(SanPham sp)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC sp_addSanPham @IDLOAI , @TENGAO , @GIAGAO , @SOKG",
                new object[] { sp.Idloai, sp.Tengao, sp.Giagao, sp.Sokg });
        }
    }
}
