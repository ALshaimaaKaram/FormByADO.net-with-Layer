using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTiers
{
    public partial class Form1 : Form
    {
        int Dno;
        public Form1()
        {
            InitializeComponent();

            DepartmentService departmentService = new DepartmentService();
            Department department = new Department();

            cmbDepartments.DisplayMember = "Name";
            cmbDepartments.ValueMember = "ID";
            Dno = department.ID;
            cmbDepartments.DataSource = departmentService.GetDepartments();

            //foreach (Department dept in departmentService.GetDepartments())
            //{
            //    cmbDepartments.Items.Add(dept.Name);
            //}
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeService employeeService  = new EmployeeService();
            lstboxEmployee.DisplayMember = "Fname";
            lstboxEmployee.DataSource = employeeService.GetEmployeeInDept((int)cmbDepartments.SelectedValue);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            Employee employee = new Employee();
            employee.SSN = Int32.Parse(txtSSN.Text);
            employee.Fname = txtFname.Text;
            employee.Lname = txtLname.Text;
            employee.BDate = dtimepBdate.Value;
            employee.Salary = Int32.Parse(txtSalary.Text);
            employee.Dno = (int)cmbDepartments.SelectedValue;


            employeeService.AddEmployee(employee);

            lstboxEmployee.DisplayMember = "Fname";
            lstboxEmployee.DataSource = employeeService.GetEmployeeInDept(employee.Dno);

        }

        private void lstboxEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            // = (List<Employee>)lstboxEmployee.DataSource;
            Employee emp = (Employee)lstboxEmployee.SelectedItem;

            txtSSN.Text = emp.SSN.ToString();
            txtFname.Text = emp.Fname;
            txtLname.Text = emp.Lname;
            txtSalary.Text = emp.Salary.ToString();
            dtimepBdate.Text = emp.BDate.ToString();     
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee empOLd = (Employee)lstboxEmployee.SelectedItem;
            EmployeeService employeeService = new EmployeeService();

            int id = empOLd.SSN;
           
            Employee employee = new Employee();
            employee.SSN = Int32.Parse(txtSSN.Text);
            employee.Fname = txtFname.Text;
            employee.Lname = txtLname.Text;
            employee.BDate = dtimepBdate.Value;
            employee.Salary = Int32.Parse(txtSalary.Text);
            employee.Dno = (int)cmbDepartments.SelectedValue;

            employeeService.UpdateEmployee(employee, id);
           
            //Refresh for ListBox
            lstboxEmployee.DisplayMember = "Fname";
            lstboxEmployee.DataSource = employeeService.GetEmployeeInDept(employee.Dno);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EmployeeService employeeService = new EmployeeService();
            employeeService.DeleteEmployee(Int32.Parse(txtSSN.Text));

            //Refresh for ListBox
            lstboxEmployee.DisplayMember = "Fname";
            lstboxEmployee.DataSource = employeeService.GetEmployeeInDept((int)cmbDepartments.SelectedValue);
        }
    }
}
