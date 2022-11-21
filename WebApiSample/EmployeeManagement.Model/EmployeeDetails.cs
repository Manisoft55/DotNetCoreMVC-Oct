using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }        
        
        //public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please enter your first name"), MaxLength(50)]
        [Display(Name = "First Name")]
        public string EmployeeFirstName {  get; set; }

        [Required(ErrorMessage = "Please enter your last name"), MaxLength (50)]
        [Display (Name = "Last Name")]
        public string EmployeeLastName { get; set; }

        [Required(ErrorMessage = "Please enter your email id")]
        [MinLength(10, ErrorMessage = "Please enter atleast 10 characters")]
        [MaxLength(50, ErrorMessage = "Please enter upto 50 characters")]
        [DataType(DataType.EmailAddress)]
        public string EmployeeEmail {  get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [MaxLength(10, ErrorMessage = "Please enter upto 10 digits")]
        public string EmployeePhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter hire date")]
        public DateTime EmployeeHireDate {  get; set; }

        [Required(ErrorMessage = "Please enter your job id")]
        public int EmployeeJobId { get; set; }

        [Required(ErrorMessage = "Please enter your salary")]
        public decimal EmployeeSalary  { get; set; }

        [Required(ErrorMessage = "Please enter your manager id")]
        public int EmployeeManagerID { get; set; }

        [Required(ErrorMessage = "Please enter your departmentid")]
        public int EmployeeDepartmentID { get; set; }
    }
}
