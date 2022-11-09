using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Model
{
    public class EmployeeInfo
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HireDate { get; set; }
        public int JobId { get; set; }
        public decimal Salary { get; set; }
        public int ManagerId { get; set; }
        public int DepartmentId { get; set; }
    }
}
