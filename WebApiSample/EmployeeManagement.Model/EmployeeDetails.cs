using System;

namespace EmployeeManagement.Model
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeFirstName {  get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeEmail {  get; set; }
        public string EmployeePhoneNumber { get; set; }
        public DateTime EmployeeHireDate {  get; set; }
        public int EmployeeJobId { get; set; }
        public decimal EmployeeSalary  { get; set; }
        public int EmployeeManagerID { get; set; }
        public int EmployeeDepartmentID { get; set; }
    }
}
