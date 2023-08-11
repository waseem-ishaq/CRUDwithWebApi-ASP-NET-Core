using System;
using System.Collections.Generic;
using ADOWebApiCRUD.Models;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data;
using MySqlConnector;
using System.Configuration;

namespace ADOWebApiCRUD.Models
{
    
    public class DAL
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cName"].ConnectionString);

        Employee emp = new Employee();
        public List<Employee> GetAllEmployees()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("usp_GetAllEmployees", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee> lstEmployee = new List<Employee>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.id = Convert.ToInt32(dt.Rows[i]["id"]);
                    emp.name = dt.Rows[i]["name"].ToString();
                    emp.age = Convert.ToInt32(dt.Rows[i]["age"]);
                    emp.gender = dt.Rows[i]["gender"].ToString();
                    lstEmployee.Add(emp);
                }
            }
            if (lstEmployee.Count > 0)
            {
                return lstEmployee;
            }
            else
            {
                return null;
            }
        }

        public Employee GetEmployee(int id)
        {
            MySqlDataAdapter da = new MySqlDataAdapter("usp_GetEmployeeById", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("p_id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Employee emp = new Employee();
            if (dt.Rows.Count > 0)
            {
                emp.id = Convert.ToInt32(dt.Rows[0]["id"]);
                emp.name = dt.Rows[0]["name"].ToString();
                emp.age = Convert.ToInt32(dt.Rows[0]["age"]);
                emp.gender = dt.Rows[0]["gender"].ToString();
            }
            if (emp != null)
            {
                return emp;
            }
            else
            {
                return null;
            }
        }

        public string AddEmployee(Employee employee)
        {
            string msg = "";
            if (employee != null)
            {
                MySqlCommand cmd = new MySqlCommand("usp_AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_name", employee.name);
                cmd.Parameters.AddWithValue("p_age", employee.age);
                cmd.Parameters.AddWithValue("p_gender", employee.gender);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0) 
                {
                    msg = "Data has been inserted";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }

        public string UpdateEmployee(int id, Employee employee)
        {
            string msg = "";
            if (employee != null)
            {
                MySqlCommand cmd = new MySqlCommand("usp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id", id);
                cmd.Parameters.AddWithValue("p_name", employee.name);
                cmd.Parameters.AddWithValue("p_age", employee.age);
                cmd.Parameters.AddWithValue("p_gender", employee.gender);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i > 0)
                {
                    msg = "Data has been updated";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }

        public string DeleteEmployee(int id)
        {
            string msg = "";

            MySqlCommand cmd = new MySqlCommand("usp_DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("p_id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                msg = "Data has been deleted";
            }
            else
            {
                msg = "Error";
            }
            return msg;
        }
    }
}