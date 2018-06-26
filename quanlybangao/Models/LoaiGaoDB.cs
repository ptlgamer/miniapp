using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Models
{
    public class LoaiGaoDB
    {
        private static LoaiGaoDB instance;

        public static LoaiGaoDB Instance
        {
            get 
            {
                if (instance == null)
                    instance = new LoaiGaoDB();
                return LoaiGaoDB.instance;
            }
            private set { LoaiGaoDB.instance = value; }
        }

        public DataTable loadLoaiGao()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC sp_loadLoaiGao");
        }
    }
}
