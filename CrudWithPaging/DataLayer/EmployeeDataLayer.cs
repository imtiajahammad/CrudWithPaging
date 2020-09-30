using CrudWithPaging.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudWithPaging.DataLayer
{
    public class EmployeeDataLayer
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using(SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = "SELECT * FROM Employee";
                using(SqlCommand cmd=new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.id = Convert.ToInt32(reader["id"].ToString());
                        employee.firstName = reader["firstName"].ToString();
                        employee.lastName = reader["lastName"].ToString();
                        employee.age = Convert.ToInt32(reader["age"].ToString());
                        employee.salary = Convert.ToInt32(reader["salary"].ToString());
                        employee.taxRate = Convert.ToDecimal(reader["taxRate"].ToString());
                        employee.dob = Convert.ToDateTime(reader["dob"].ToString());
                        employees.Add(employee);
                    }
                    con.Close();
                }
            }
            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection sqlConnection=new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = "SELECT * FROM Employee WHERE id=@id";
                using(SqlCommand sqlCommand=new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        employee.id = Convert.ToInt32(reader["id"].ToString());
                        employee.firstName = reader["firstName"].ToString();
                        employee.lastName = reader["lastName"].ToString();
                        employee.age = Convert.ToInt32(reader["age"].ToString());
                        employee.salary = Convert.ToInt32(reader["salary"].ToString());
                        employee.taxRate = Convert.ToDecimal(reader["taxRate"].ToString());
                        employee.dob = Convert.ToDateTime(reader["dob"].ToString());
                    }
                    sqlConnection.Close();
                }
            }
            return employee;
        }
        public bool AddNewEmployee(Employee employee)
        {
            int rowsEffected;
            using (SqlConnection sqlConnection=new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = "INSERT INTO Employee(firstName,lastName,age,salary,taxRate,dob) VALUES(@firstName,@lastName,@age,@salary,@taxRate,@dob)";
                using(SqlCommand sqlCommand=new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@firstName", employee.firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", employee.lastName);
                    sqlCommand.Parameters.AddWithValue("@age", employee.age);
                    sqlCommand.Parameters.AddWithValue("@salary", employee.salary);
                    sqlCommand.Parameters.AddWithValue("@taxRate", employee.taxRate);
                    sqlCommand.Parameters.AddWithValue("@dob", employee.dob);
                    sqlConnection.Open();
                    rowsEffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            return (rowsEffected>0)?true:false;
        }
        public bool UpdateEmployeeById(Employee employee)
        {
            int rowsEffected;
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = "UPDATE Employee SET firstName=@firstName,lastName=@lastName,age=@age,salary=@salary,taxRate=@taxRate,dob=@dob WHERE id=@id";
                using(SqlCommand sqlCommand=new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@id", employee.id);
                    sqlCommand.Parameters.AddWithValue("@firstName", employee.firstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", employee.lastName);
                    sqlCommand.Parameters.AddWithValue("@age", employee.age);
                    sqlCommand.Parameters.AddWithValue("@salary", employee.salary);
                    sqlCommand.Parameters.AddWithValue("@taxRate", employee.taxRate);
                    sqlCommand.Parameters.AddWithValue("@dob", employee.dob);
                    sqlConnection.Open();
                    rowsEffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            return (rowsEffected > 0) ? true : false;
        }
        public bool DeleteEmployeeById(int id)
        {
            int rowsEffected;
            using(SqlConnection sqlConnection=new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
            {
                string query = "DELETE from Employee WHERE id=@id";
                using(SqlCommand sqlCommand=new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlConnection.Open();
                    rowsEffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            return (rowsEffected>0)?true:false;
        }
    }
}