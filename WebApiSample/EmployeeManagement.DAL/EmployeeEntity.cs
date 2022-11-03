using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.DAL
{
    public class EmployeeEntity
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
    }
}
