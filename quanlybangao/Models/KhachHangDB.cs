using quanlybangao.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybangao.Models
{
    public class KhachHangDB
    {
        private static KhachHangDB instance;

        public static KhachHangDB Instance
        {
            get 
            {
                if (instance == null)
                    instance = new KhachHangDB();

                return KhachHangDB.instance; 
            }
            private set { KhachHangDB.instance = value; }
        }

        public int addKhachHang(string ten, string diachi, int dienthoai)
        {
            return (int)DataProvider
                .Instance
                .ExecuteScalar("exec sp_addKhachHang @TEN , @DIACHI , @DIENTHOAI", new object[] { ten, diachi, dienthoai });
        }

        public List<KhachHang> loadKhachHang()
        {
            List<KhachHang> customers = new List<KhachHang>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("EXEC sp_loadCustomer");
            foreach(DataRow row in dataTable.Rows)
            {
                KhachHang kh = new KhachHang(row);
                customers.Add(kh);
            }
            return customers;
        }
        
        public void updateKhachHang(int id, string ten, string diachi, int dienthoai)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC sp_updateKhachHang @id , @ten , @diachi , @dienthoai",
                new object[] { id, ten, diachi, dienthoai });
        }
    }
}
