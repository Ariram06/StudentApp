
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


        public List<Student> GetStudentData()
        {
            List<Student> data = new List<Student>();

            string connectString = "Server=.\\SQLEXPRESS;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";
            using SqlConnection connection = new SqlConnection(connectString);

            connection.Open();
            string query = "SELECT StudentId, Name, Email, Age, DepartmentId, AdmissionDate, IsActive FROM Students;";


            using SqlCommand cmd = new SqlCommand(query, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
           
               while (reader.Read()){
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string email = reader.GetString(2);
                        int age = reader.GetInt32(3);
                        int deptId = reader.GetInt32(4);
                        DateTime admissionDate = reader.GetDateTime(5);
                        bool isActive = reader.GetBoolean(6);

                        data.Add(new Student(id, name, email, age, deptId, admissionDate, isActive));
                    }

            return data;
        }



    }
}
