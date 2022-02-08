using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVC9pmCoreBatch.Models
{
    public class EmployeeContext
    {
        public List<EmployeeModel> GetEmployees(string conStr)
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("sp_getEmployee_Rock", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpId =Convert.ToInt32(dr[0]);
                emp.EmpName =Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                list.Add(emp);
            }
            return list;
        }

        public int SaveEmployee(string conStr,EmployeeModel emp)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = null;
            if (emp.EmpId == null)
            {
               cmd = new SqlCommand("sp_AddNeerjaEmployees", con);
            }
            else
            {
                cmd = new SqlCommand("sp_UpdateNeerjaEmployees", con);
                cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", emp.EmpSalary);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;    
        }

        
             public EmployeeModel GetEmployeesById(int? id,string conStr)
        {
            EmployeeModel emp = new EmployeeModel();
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("spr_getEmployeeDetailsbyId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid",id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
               
            }
            return emp;
        }
    }
}
