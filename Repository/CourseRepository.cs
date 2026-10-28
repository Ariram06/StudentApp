using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Services;
using Microsoft.Data.SqlClient;
namespace StudentApp.Repository
{
        public class CourseRepository
        {
            public void AsyncAddCourse(List<Course> l)
            {
                string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
                using SqlConnection connection = new SqlConnection(connectString);

                connection.Open();
                string query = "INSERT INTO Courses (CourseName, DurationMonths, Fee, DepartmentId, IsActive) VALUES (@CourseName, @DurationMonths, @Fee, @DepartmentId, @IsActive);";

                foreach (Course x in l)
                {
                    using SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@CourseName", x.CourseName);
                    cmd.Parameters.AddWithValue("@DurationMonths", x.DurationMonths);
                    cmd.Parameters.AddWithValue("@Fee", x.Fee);
                    cmd.Parameters.AddWithValue("@DepartmentId", x.DepartmentId);
                    cmd.Parameters.AddWithValue("@IsActive", x.IsActive);

                    cmd.ExecuteNonQuery();
                }
            }

            public List<Course> GetCourseData()
            {
                List<Course> data = new List<Course>();

                string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
                using SqlConnection connection = new SqlConnection(connectString);

                connection.Open();
                string query = "SELECT CourseId, CourseName, DurationMonths, Fee, DepartmentId, IsActive FROM Courses;";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course c = new Course();
                    c.CourseId = reader.GetInt32(0);
                    c.CourseName = reader.GetString(1);
                    c.DurationMonths = reader.GetInt32(2);
                    c.Fee = reader.GetDecimal(3);
                    c.DepartmentId = reader.GetInt32(4);
                    c.IsActive = reader.GetBoolean(5);

                    data.Add(c);
                }

                return data;
            }

            public List<Course> SearchData(string name)
            {
                List<Course> data = new List<Course>();
                string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
                using SqlConnection connection = new SqlConnection(connectString);

                connection.Open();
                string query = $"select * from Courses where CourseName='{name}';";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course c = new Course();
                    c.CourseId = reader.GetInt32(0);
                    c.CourseName = reader.GetString(1);
                    c.DurationMonths = reader.GetInt32(2);
                    c.Fee = reader.GetDecimal(3);
                    c.DepartmentId = reader.GetInt32(4);
                    c.IsActive = reader.GetBoolean(5);

                    data.Add(c);
                }

                return data;
            }

            public List<Course> FilterByDepartment(int deptId)
            {
                List<Course> data = new List<Course>();
                string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
                using SqlConnection connection = new SqlConnection(connectString);

                connection.Open();
                string query = $"select * from Courses where DepartmentId={deptId};";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course c = new Course();
                    c.CourseId = reader.GetInt32(0);
                    c.CourseName = reader.GetString(1);
                    c.DurationMonths = reader.GetInt32(2);
                    c.Fee = reader.GetDecimal(3);
                    c.DepartmentId = reader.GetInt32(4);
                    c.IsActive = reader.GetBoolean(5);

                    data.Add(c);
                }

                return data;
            }

            public int UpdateData(Course obj)
            {
                string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
                using SqlConnection connection = new SqlConnection(connectString);

                connection.Open();
                string query = "UPDATE Courses SET CourseName = @CourseName, DurationMonths = @DurationMonths, Fee = @Fee, DepartmentId = @DepartmentId, IsActive = @IsActive WHERE CourseId = @CourseId";

                using SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@CourseId", obj.CourseId);
                cmd.Parameters.AddWithValue("@CourseName", obj.CourseName);
                cmd.Parameters.AddWithValue("@DurationMonths", obj.DurationMonths);
                cmd.Parameters.AddWithValue("@Fee", obj.Fee);
                cmd.Parameters.AddWithValue("@DepartmentId", obj.DepartmentId);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? 1 : 0;
            }

            public int DeactivateData(int id)
            {
                string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
                using SqlConnection connection = new SqlConnection(connectString);

                connection.Open();
                string query = "UPDATE Courses SET IsActive = 0 WHERE CourseId = @CourseId";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@CourseId", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? 1 : 0;
            }
        }
    }


