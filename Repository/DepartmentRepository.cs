using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Services;
using Microsoft.Data.SqlClient;
namespace StudentApp.Repository
{
   
        public class DepartmentRepository
        {
            private readonly string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";

            public void AsyncAddDepartment(List<Departments> l)
            {
                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();

                string query = "INSERT INTO Departments (DepartmentName, Location, IsActive) VALUES (@DepartmentName, @Location, @IsActive);";

                foreach (Departments x in l)
                {
                    using SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@DepartmentName", x.DepartmentName);
                    cmd.Parameters.AddWithValue("@Location", x.Location);
                    cmd.Parameters.AddWithValue("@IsActive", x.IsActive);

                    cmd.ExecuteNonQuery();
                }
            }

            public List<Departments> GetDepartmentData()
            {
                List<Departments> data = new List<Departments>();

                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();

                string query = "SELECT DepartmentId, DepartmentName, Location, IsActive FROM Departments;";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string loc = reader.GetString(2);
                    bool isActive = reader.GetBoolean(3);

                    data.Add(new Departments(id, name, loc, isActive));
                }

                return data;
            }

            public List<Departments> SearchData(string name)
            {
                List<Departments> data = new List<Departments>();

                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();

                string query = $"SELECT * FROM Departments WHERE DepartmentName = '{name}';";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string n = reader.GetString(1);
                    string desc = reader.GetString(2);
                    bool isActive = reader.GetBoolean(3);

                    data.Add(new Departments(id, n, desc, isActive));
                }

                return data;
            }

            public int UpdateData(Departments obj)
            {
                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();

                string query = "UPDATE Departments SET DepartmentName = @DepartmentName, Location = @Location, IsActive = @IsActive WHERE DepartmentId = @DepartmentId";

                using SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@DepartmentId", obj.DepartmentId);
                cmd.Parameters.AddWithValue("@DepartmentName", obj.DepartmentName);
                cmd.Parameters.AddWithValue("@Location", obj.Location);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? 1 : 0;
            }

            public int DeactivateData(int id)
            {
                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();

                string query = "UPDATE Departments SET IsActive = 0 WHERE DepartmentId = @DepartmentId";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@DepartmentId", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? 1 : 0;
            }
        }
    }


