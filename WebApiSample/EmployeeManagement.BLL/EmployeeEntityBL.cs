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
    }
}
