using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class DbHelper
    {
        SqlConnection connection;

        public DbHelper()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-QDTFMRF;Initial Catalog=Company;Integrated Security=True");
        }

        public DataTable GetAllDepartments()
        {
            SqlCommand command = new SqlCommand("select Dnum, Dname from Departments");
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable GetAllEmployeeInDept(int Dno)
        {
            SqlCommand command = new SqlCommand("EmployeeInDept", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param;

            param = command.Parameters.Add("@Dno", SqlDbType.Int);
            param.Value = Dno;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public void AddEmployeeDB(int SSN, string Fname, string Lname, DateTime Bdate, int Salary, int Dno)
        {
            try
            {
                string cmd = $"insert into Employee (SSN,Fname,Lname,Bdate,Salary,Dno)" +
                             $"VALUES(" + SSN + " , '" + Fname + "' , '" + Lname + "' , '" + Bdate + "' , " + Salary + " , " + Dno + " )";

                SqlCommand command = new SqlCommand(cmd, connection);
                //connection.Open();
                //int rowsAffectedCount = command.ExecuteNonQuery();
                //connection.Close(); 

                connection.Open();

                command.ExecuteNonQuery();
                MessageBox.Show("Success Add");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Connection" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateEmployeeDB(int SSN, string Fname, string Lname, DateTime Bdate, int Salary, int Dno, int Id)
        {
            try
            {
                string cmd = $"update employee" +
                             $" set SSN = { SSN } ,Fname = '{Fname}' ,Lname = '{Lname}',Bdate = '{Bdate}'" +
                             $",Salary = {Salary},Dno = {Dno} where SSN = {Id}";
                SqlCommand command = new SqlCommand(cmd, connection);
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Success Update");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Connection" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteEmployeeDB(int SSN)
        {
            try
            {
                string cmd = $"delete from employee where SSN = {SSN}";
                SqlCommand command = new SqlCommand(cmd, connection);
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Success Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Connection" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }


        //public DataTable GetOneEmployee(int SSN)
        //{
        //    string cmd = "select SSN, Fname, Lname, Bdate, Salary from Employee where SSN = " + SSN;
        //    SqlCommand command = new SqlCommand(cmd, connection);

        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
        //    DataTable dataTable = new DataTable();
        //    sqlDataAdapter.Fill(dataTable);

        //    return dataTable;
        //}


    }
}
