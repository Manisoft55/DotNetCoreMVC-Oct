using EmployeeManagement.DAL;
using System;
using System.Data;

namespace EmployeeManagement.BLL
{
    public class EmployeeEntityBL
    {
        EmployeeEntityDAL employeeDAL = new EmployeeEntityDAL();
        public DataSet GetAllEmployeeDetails()
        {
            return employeeDAL.GetAllEmployee();
        }

        public void UpdateEmployee(string empName, int empId)
        {
            employeeDAL.UpdateEmployee(empName, empId);
        }

        public void DeleteEmployee(int empId)
        {
            employeeDAL.DeleteEmployee(empId);
        }
    }
}
