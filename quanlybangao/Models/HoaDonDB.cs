using quanlybangao.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Models
{
    public class HoaDonDB
    {
        private static HoaDonDB instance;

        public static HoaDonDB Instance
        {
            get 
            { 
                if(instance == null)
                {
                    instance = new HoaDonDB();
                }
                return HoaDonDB.instance; 
            }
            private set { HoaDonDB.instance = value; }
        }

        public void addHoaDon(int makh, int manv)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC sp_addHoaDon @MAKH , @MANV", new object[] { makh, manv });
        }

        public void addTPHoaDon(SanPham sp)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC sp_addTPHoaDon @IDGAO , @SOKG", new object[] { sp.Idgao, sp.Selectedkg });
        }
        
        public List<DetailBill> loadDetailBill(int mahd)
        {
            List<DetailBill> dbList = new List<DetailBill>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC sp_loadDetailBill @MAHD", new object[] { mahd });

            foreach (DataRow row in data.Rows)
            {
                DetailBill db = new DetailBill(row);
                dbList.Add(db);
            }

            return dbList;
        }

        public DataTable loadDetailBill()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC sp_loadDetailBill");
        }

        public void updateDetailBill(List<DetailBill> dbList)
        {
            int makh = dbList[0].Makh;
            string tenkh = dbList[0].Tenkh;
            string diachi = dbList[0].Diachi;
            int dienthoai = dbList[0].Dienthoai;
            DataProvider.Instance.ExecuteNonQuery("exec sp_updateInfoKH @MAKH , @TENKH , @DIACHI , @DIENTHOAI",
                new object[] { makh, tenkh, diachi, dienthoai });

            int mahd = dbList[0].Mahd;
            int manv = dbList[0].Manv;
            string ngay = dbList[0].Ngay;
            int trangthai = dbList[0].Trangthai;
            DataProvider.Instance.ExecuteNonQuery("exec sp_updateHoaDon @MAHD , @MANV , @NGAY , @TRANGTHAI",
                new object[] { mahd, manv, ngay, trangthai });

            foreach(DetailBill db in dbList)
            {
                int idgao = db.Idgao;
                float sokg = db.Sokg;
                DataProvider.Instance.ExecuteNonQuery("exec sp_updateTPHoaDon @MAHD , @IDGAO , @SOKG",
                    new object[] { mahd, idgao, sokg });
            }
        }

        public void updateStatusBill(int mahd, int trangthai)
        {
            DataProvider.Instance.ExecuteNonQuery("UPDATE HOADON SET TRANGTHAI= @trangthai WHERE MAHD= @mahd", new object[] { trangthai, mahd });
        }
    }
}
