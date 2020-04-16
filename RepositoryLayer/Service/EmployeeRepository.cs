//
// Purpose: Repository Layer is for Connectivity between API and Database
// Author Vinayak Ushakola
// Date 16/04/2020
//

using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace RepositoryLayer.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public static string sqlConnectionString = @"Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True";

        /// <summary>
        /// It Retrieves Employee Data
        /// </summary>
        /// <returns></returns>
        public List<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployees", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(dataReader["ID"]);
                    employee.FirstName = dataReader["FirstName"].ToString();
                    employee.LastName = dataReader["LastName"].ToString();
                    employee.Gender = dataReader["Gender"].ToString();
                    employee.Department = dataReader["Department"].ToString();
                    employee.Salary = Convert.ToInt32(dataReader["Salary"]);

                    employees.Add(employee);
                }
            }
            return employees;
        }

        /// <summary>
        /// It Retrieve Specific Employee Data
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns></returns>
        public Employee Get(int id)
        {
            Employee employee = null;

            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeById", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    employee = new Employee();
                    employee.ID = Convert.ToInt32(dataReader["ID"]);
                    employee.FirstName = dataReader["FirstName"].ToString();
                    employee.LastName = dataReader["LastName"].ToString();
                    employee.Gender = dataReader["Gender"].ToString();
                    employee.Department = dataReader["Department"].ToString();
                    employee.Salary = Convert.ToInt32(dataReader["Salary"]);
                }
            }
            return employee;
        }

        /// <summary>
        /// It Adds the Employee Details to the Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int Add([FromBody]Employee employee)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                conn.Open();
                count = cmd.ExecuteNonQuery();
                conn.Close();
                return count;
            }
        }

        /// <summary>
        /// It Deletes the Employee Details from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                count = cmd.ExecuteNonQuery();

                return count;
            }
        }

        /// <summary>
        /// It Updates the Employee Details in the Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int Update(int id, [FromBody]Employee employee)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                conn.Open();
                count = cmd.ExecuteNonQuery();

                return count;
            }
        }

    }
}
