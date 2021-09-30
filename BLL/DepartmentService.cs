using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentService
    {
        DbHelper dbHelper = new DbHelper();

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            foreach (DataRow row in dbHelper.GetAllDepartments().Rows)
            {
                departments.Add(new Department
                {
                    ID = (int)row["Dnum"],
                    Name = row["Dname"].ToString(),
                }
                );
            }

            return departments;
        }

        //public void AddDepartment(Department department)
        //{

        //}
    }
}
