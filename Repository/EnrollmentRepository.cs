using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Services;
using Microsoft.Data.SqlClient;

namespace StudentApp.Repository
{
  
        public class EnrollmentRepository
        {
            private readonly string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";

            public void AsyncAddEnrollment(List<Enrollments> l)
            {
                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = "INSERT INTO Enrollments (StudentId, CourseId, EnrolledAt, Status) VALUES (@StudentId, @CourseId, @EnrolledAt, @Status);";

                foreach (Enrollments x in l)
                {
                    using SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@StudentId", x.StudentId);
                    cmd.Parameters.AddWithValue("@CourseId", x.CourseId);
                    cmd.Parameters.AddWithValue("@EnrolledAt", x.EnrolledAt);
                    cmd.Parameters.AddWithValue("@Status", x.Status);

                    cmd.ExecuteNonQuery();
                }
            }

            public List<Enrollments> GetEnrollmentData()
            {
                List<Enrollments> data = new List<Enrollments>();

                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = "SELECT EnrollmentId, StudentId, CourseId, EnrolledAt, Status FROM Enrollments;";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int studentId = reader.GetInt32(1);
                    int courseId = reader.GetInt32(2);
                    DateTime enrolledAt = reader.GetDateTime(3);
                    string status = reader.GetString(4);

                    data.Add(new Enrollments(id, studentId, courseId, enrolledAt, status));
                }

                return data;
            }

            public List<Enrollments> GetCoursesByStudent(int studentId)
            {
                List<Enrollments> data = new List<Enrollments>();

                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = $"SELECT EnrollmentId, StudentId, CourseId, EnrolledAt, Status FROM Enrollments WHERE StudentId = {studentId};";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int sId = reader.GetInt32(1);
                    int cId = reader.GetInt32(2);
                    DateTime enrolledAt = reader.GetDateTime(3);
                    string status = reader.GetString(4);

                    data.Add(new Enrollments(id, sId, cId, enrolledAt, status));
                }

                return data;
            }

            public List<Enrollments> GetStudentsByCourse(int courseId)
            {
                List<Enrollments> data = new List<Enrollments>();

                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = $"SELECT EnrollmentId, StudentId, CourseId, EnrolledAt, Status FROM Enrollments WHERE CourseId = {courseId};";

                using SqlCommand cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int sId = reader.GetInt32(1);
                    int cId = reader.GetInt32(2);
                    DateTime enrolledAt = reader.GetDateTime(3);
                    string status = reader.GetString(4);

                    data.Add(new Enrollments(id, sId, cId, enrolledAt, status));
                }

                return data;
            }

            public int UpdateStatus(int enrollmentId, string status)
            {
                using SqlConnection connection = new SqlConnection(connectString);
                connection.Open();
                string query = "UPDATE Enrollments SET Status = @Status WHERE EnrollmentId = @EnrollmentId";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);
                cmd.Parameters.AddWithValue("@Status", status);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0 ? 1 : 0;
            }
        }
    }


