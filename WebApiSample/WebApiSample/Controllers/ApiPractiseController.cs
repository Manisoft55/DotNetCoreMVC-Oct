using EmployeeManagement.BLL;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("employeeapi/[controller]")]
    public class ApiPractiseController : ControllerBase
    {
        //[HttpGet]
        //public string GetString()
        //{
        //    return "Output";
        //}
        
        EmployeeEntityBL employeeEntityBL = new EmployeeEntityBL();

        //[HttpGet]
        //public string InputData(string inputVariable)
        //{
        //    return $"Your input data is {inputVariable}";
        //}


        [HttpGet]
        [Route("SelectEmployeeDetails")]
        public IEnumerable<EmployeeDetails> GetAllEmployee()
        {
            var data = employeeEntityBL.GetAllEmployeeDetails().Tables[0];
            var myData = data.AsEnumerable().Select(r => new EmployeeDetails
            {
            EmployeeID = r.Field<int>("employee_id"),
            EmployeeFirstName = r.Field<string>("first_name"),
            EmployeeLastName = r.Field<string>("last_name"),
            EmployeeEmail = r.Field<string>("email"),
            EmployeePhoneNumber = r.Field<string>("phone_number"),
            EmployeeHireDate = r.Field<DateTime>("hire_date"),
            EmployeeJobId = r.Field<int>("job_id"),
            EmployeeSalary = r.Field<decimal>("salary"),
            EmployeeManagerID = r.Field<int>("manager_id"),
            EmployeeDepartmentID = r.Field<int>("department_id")
            });

            return myData;
        }

        //[HttpPut]
        //public void UpdateEmployee(string employeeName, int empId)
        //{
        //    employeeEntityBL.UpdateEmployee(employeeName, empId);
        //}

        //[HttpDelete]
        //public void DeleteEmployee(int empId)
        //{
        //    employeeEntityBL.DeleteEmployee(empId);
        //}

        //[HttpPost]
        //public int CreateEmployee([FromBody]EmployeeDetails employeeDetails)
        //{
        //    var empId = employeeEntityBL.CreateEmployee(employeeDetails);
        //    return empId;
        //}

        [HttpGet("author/{id:int}")]
        //[HttpGet("author")]
        public string GetMyId(string id)
        {
            return "My id is " + id;
        }


        [HttpPut]
        public void UpdateEmployee(string employeeName, int empId)
        {
            employeeEntityBL.UpdateEmployeeDetails(employeeName, empId);
        }

        [HttpDelete]
        public void DeleteEmployee(int empid)
        {
            employeeEntityBL.DeleteEmployee(empid);
        }

        [HttpPost]
        public int CreateEmployee([FromBody]EmployeeInfo employeeInfo)
        {
            return employeeEntityBL.CreateEmployeeDetails(employeeInfo);
        }
        

    }
}
