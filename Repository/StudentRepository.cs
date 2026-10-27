
using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Services;
using Microsoft.Data.SqlClient;

namespace StudentApp.Repository
{
    public  class StudentRepository
    {
        public void AsyncAddStudent(List<Student> l)
        {
            string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
            using SqlConnection connection = new SqlConnection(connectString) ;

            connection.Open();
            string query = "INSERT INTO Students ( Name, Email, Age, DepartmentId, AdmissionDate, IsActive) VALUES ( @Name, @Email, @Age, @DepartmentId, @AdmissionDate, @IsActive);";
            foreach (Student x in l) {

                using SqlCommand cmd = new SqlCommand(query,connection);


                //cmd.Parameters.AddWithValue("@StudentId", x.StudentId);
                cmd.Parameters.AddWithValue("@Name", x.Name);
                cmd.Parameters.AddWithValue("@Email", x.Email);
                cmd.Parameters.AddWithValue("@Age", x.Age);
                cmd.Parameters.AddWithValue("@DepartmentId", x.DepartmentId);
                cmd.Parameters.AddWithValue("@AdmissionDate", x.AdmissionDate);
                cmd.Parameters.AddWithValue("@IsActive", x.IsActive);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
