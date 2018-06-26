using quanlybangao.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybangao.Models
{
    public class EmployeeDB
    {
        private static EmployeeDB instance;

        public static EmployeeDB Instance
        {
            get 
            {
                if (instance == null)
                    instance = new EmployeeDB();
                return EmployeeDB.instance; 
            }
            private set { instance = value; }
        }

        public List<Employee> loadEmployee()
        {
            List<Employee> employees = new List<Employee>();

            DataTable dataTable = DataProvider.Instance.ExecuteQuery("EXEC sp_loadEmployee");
            foreach(DataRow row in dataTable.Rows)
            {
                Employee employee = new Employee(row);
                employees.Add(employee);
            }

            return employees;
        }

        public void updateEmployee(Employee employee)
        {
            DataProvider.Instance.ExecuteNonQuery("UPDATE NHANVIEN SET TENNV= @TENNV , DIENTHOAI= @DIENTHOAI WHERE MANV= @MANV",
                new object[] { employee.Tennv, employee.Dienthoai, employee.Manv });
        }
    }
}
