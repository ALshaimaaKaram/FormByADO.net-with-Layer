using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeService
    {
        DbHelper dbHelper = new DbHelper();

        public List<Employee> GetEmployeeInDept(int Dno)
        {
            List<Employee> employeeInDepts = new List<Employee>();

            foreach (DataRow row in dbHelper.GetAllEmployeeInDept(Dno).Rows)
            {
                employeeInDepts.Add(new Employee
                {
                    SSN = (int)row["SSN"],
                    Fname = row["Fname"].ToString(),
                    Lname = row["Lname"].ToString(),
                    BDate = (DateTime)row["Bdate"],
                    Salary = (int)row["Salary"]
                }
               );
            }

            return employeeInDepts;
        }

        public void AddEmployee(Employee employee)
        {
            dbHelper.AddEmployeeDB(employee.SSN, employee.Fname,
                employee.Lname, employee.BDate, employee.Salary, employee.Dno);
        }

        public void UpdateEmployee(Employee employee, int id)
        {
            dbHelper.UpdateEmployeeDB(employee.SSN, employee.Fname,
                employee.Lname, employee.BDate, employee.Salary, employee.Dno, id);
        }

        public void DeleteEmployee(int SSN)
        {
            dbHelper.DeleteEmployeeDB(SSN);
        }

        //public Employee GetEmployee(int SSN)
        //{
        //    Employee employee = new Employee();
        //    foreach (DataRow row in dbHelper.GetOneEmployee(SSN))
        //    {
        //        new Employee()
        //        {
        //            SSN = (int)row["SSN"],
        //            Fname = row["Fname"].ToString(),
        //            Lname = row["Lname"].ToString(),
        //            BDate = (DateTime)row["Bdate"],
        //            Salary = (int)row["Salary"]
        //        }

        //    }
        //}
    }
}
