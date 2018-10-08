using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices_DBConnectivity.Models;

namespace WebServices_DBConnectivity.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee/GetEmployees
        [HttpGet]
        public DataTable GetEmployees()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OwnConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Employees"))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                    {
                        command.Connection = connection;
                        dataAdapter.SelectCommand = command;
                        using (DataTable dataTable = new DataTable())
                        {
                            dataTable.TableName = "Employees";
                            dataAdapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
        }

        // POST: Employee/InsertEmployee
        [HttpPost]
        public HttpResponseMessage InsertEmployee([FromBody]Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                else
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OwnConnection"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("INSERT INTO Employees (Name, Department, Rate) VALUES (@Name, @Department, @Rate)"))
                        {
                            command.Parameters.AddWithValue("@Name", employee.Name);
                            command.Parameters.AddWithValue("@Department", employee.Department);
                            command.Parameters.AddWithValue("@Rate", employee.Rate);
                            command.Connection = connection;
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch (Exception exp)
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
        }
    }
}