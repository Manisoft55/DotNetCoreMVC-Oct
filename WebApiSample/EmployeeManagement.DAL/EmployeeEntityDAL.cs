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
                SqlCommand cmd = new SqlCommand("select * from employees", con);
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

    }
}
