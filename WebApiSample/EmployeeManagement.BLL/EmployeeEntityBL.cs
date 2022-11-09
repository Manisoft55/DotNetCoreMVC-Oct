using EmployeeManagement.DAL;
using EmployeeManagement.Model;
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

        public int CreateEmployee(EmployeeDetails employeeDetails)
        {
            var empId = employeeDAL.CreateEmployee(employeeDetails);
            return empId;
        }

        public void UpdateEmployeeDetails(string employeeName, int empId)
        {
            employeeDAL.UpdateEmployeeDetails(employeeName, empId);
        }

        public void DeleteEmployeeDetails(int empId)
        {
            employeeDAL.DeleteEmployeeDetails(empId);
        }

        public int CreateEmployeeDetails(EmployeeInfo employeeInfo)
        {
            return employeeDAL.CreateEmployeeDetails(employeeInfo);
        }
    }
}
