using EmployeeManagement.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.DAL
{
    public class EmployeeEntityDAL
    {
        public DataSet GetAllEmployee()
        {
            DataSet ds = new DataSet();
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from employees order by employee_id desc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds;
        }

        public void UpdateEmployee(string employeeName, int empId)
        {
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update employees set first_name = @empName where employee_id = @empId", con);
                cmd.Parameters.AddWithValue("@empName", employeeName);
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.ExecuteNonQuery();                
            }            
        }

        public void DeleteEmployee(int empId)
        {
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM employees WHERE employee_id = @empId", con);
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.ExecuteNonQuery();
            }
        }

        public int CreateEmployee(EmployeeDetails employeeDetails)
        {
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.usp_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", employeeDetails.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@last_name", employeeDetails.EmployeeLastName);
                cmd.Parameters.AddWithValue("@email", employeeDetails.EmployeeEmail);
                cmd.Parameters.AddWithValue("@phone_number", employeeDetails.EmployeePhoneNumber);
                cmd.Parameters.AddWithValue("@hire_date", employeeDetails.EmployeeHireDate);
                cmd.Parameters.AddWithValue("@job_id", employeeDetails.EmployeeJobId);
                cmd.Parameters.AddWithValue("@salary", employeeDetails.EmployeeSalary);
                cmd.Parameters.AddWithValue("@manager_id", employeeDetails.EmployeeManagerID);
                cmd.Parameters.AddWithValue("@department_id", employeeDetails.EmployeeDepartmentID);

                SqlParameter outputPara = new SqlParameter();
                outputPara.ParameterName = "@EmpId";
                outputPara.Direction = ParameterDirection.Output;
                outputPara.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(outputPara);
                cmd.ExecuteNonQuery();

                var empId = outputPara.Value;
                return Convert.ToInt32(empId);
            }                                    
        }


        public void UpdateEmployeeDetails(string employeeName, int empId)
        {            
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update employees set first_name = @employeeName where employee_id = @empId", con);
                cmd.Parameters.AddWithValue("@employeeName", employeeName);
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.ExecuteNonQuery();
            }            
        }

        public void DeleteEmployeeDetails(int empId)
        {
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from employees where employee_id = @empId", con);
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.ExecuteNonQuery();
            }
        }

        public int CreateEmployeeDetails(EmployeeDetails employeeInfo)
        {
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.CreateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", employeeInfo.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@last_name", employeeInfo.EmployeeLastName);
                cmd.Parameters.AddWithValue("@email", employeeInfo.EmployeeEmail);
                cmd.Parameters.AddWithValue("@phone_number", employeeInfo.EmployeePhoneNumber);
                cmd.Parameters.AddWithValue("@hire_date", employeeInfo.EmployeeHireDate);
                cmd.Parameters.AddWithValue("@job_id", employeeInfo.EmployeeJobId);
                cmd.Parameters.AddWithValue("@salary", employeeInfo.EmployeeSalary);
                cmd.Parameters.AddWithValue("@manager_id", employeeInfo.EmployeeManagerID);
                cmd.Parameters.AddWithValue("@department_id", employeeInfo.EmployeeDepartmentID);

                SqlParameter outputPara = new SqlParameter();
                outputPara.ParameterName = "@empid";
                outputPara.Direction = ParameterDirection.Output;
                outputPara.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(outputPara);
                cmd.ExecuteNonQuery();

                var empId = outputPara.Value;
                return Convert.ToInt32(empId);
            }
        }

        public void EditEmployeeDetails(EmployeeDetails employeeInfo)
        {
            string strConString = @"Data Source=MSP-LAPTOP;Initial Catalog=InstituteCmd;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbo.EditEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id", employeeInfo.EmployeeID);
                cmd.Parameters.AddWithValue("@first_name", employeeInfo.EmployeeFirstName);
                cmd.Parameters.AddWithValue("@last_name", employeeInfo.EmployeeLastName);
                cmd.Parameters.AddWithValue("@email", employeeInfo.EmployeeEmail);
                cmd.Parameters.AddWithValue("@phone_number", employeeInfo.EmployeePhoneNumber);
                //cmd.Parameters.AddWithValue("@hire_date", employeeInfo.EmployeeHireDate);
                cmd.Parameters.AddWithValue("@job_id", employeeInfo.EmployeeJobId);
                cmd.Parameters.AddWithValue("@salary", employeeInfo.EmployeeSalary);
                cmd.Parameters.AddWithValue("@manager_id", employeeInfo.EmployeeManagerID);
                cmd.Parameters.AddWithValue("@department_id", employeeInfo.EmployeeDepartmentID);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
