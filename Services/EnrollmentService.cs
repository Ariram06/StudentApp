using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Repository;

namespace StudentApp.Services;

public class EnrollmentService
{
    public void Register()
    {
        Console.WriteLine("Enter Enrollment ID: ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Student ID: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Course ID: ");
        int c = int.Parse(Console.ReadLine());

        List<Enrollments> std = new List<Enrollments>();
        std.Add(new Enrollments(a, b, c, DateTime.Now, "Enrolled"));

        EnrollmentRepository obj = new EnrollmentRepository();
        obj.AsyncAddEnrollment(std);

        Console.WriteLine("Student Enrolled Successfully");
    }

    public void Display()
    {
        EnrollmentRepository obj = new EnrollmentRepository();
        List<Enrollments> l = obj.GetEnrollmentData();

        foreach (Enrollments s in l)
        {
            Console.WriteLine($"Enrollment ID: {s.EnrollmentId} | Student ID: {s.StudentId} | Course ID: {s.CourseId} | Date: {s.EnrolledAt.ToShortDateString()} | Status: {s.Status}");
        }
    }

    public void ViewStudentCourses()
    {
        Console.WriteLine("Enter Student ID to view courses: ");
        int id = int.Parse(Console.ReadLine());

        EnrollmentRepository obj = new EnrollmentRepository();
        List<Enrollments> l = obj.GetCoursesByStudent(id);

        if (l.Count == 0)
        {
            Console.WriteLine("No Enrolled Courses Found for this Student");
        }
        else
        {
            Console.WriteLine($"\nCourses for Student ID {id}:");
            foreach (Enrollments s in l)
            {
                Console.WriteLine($"Enrollment ID: {s.EnrollmentId} | Course ID: {s.CourseId} | Date: {s.EnrolledAt.ToShortDateString()} | Status: {s.Status}");
            }
        }
    }

    public void ViewCourseStudents()
    {
        Console.WriteLine("Enter Course ID to view enrolled students: ");
        int id = int.Parse(Console.ReadLine());

        EnrollmentRepository obj = new EnrollmentRepository();
        List<Enrollments> l = obj.GetStudentsByCourse(id);

        if (l.Count == 0)
        {
            Console.WriteLine("No Students Enrolled in this Course");
        }
        else
        {
            Console.WriteLine($"\nStudents in Course ID {id}:");
            foreach (Enrollments s in l)
            {
                Console.WriteLine($"Enrollment ID: {s.EnrollmentId} | Student ID: {s.StudentId} | Date: {s.EnrolledAt.ToShortDateString()} | Status: {s.Status}");
            }
        }
    }

    public void Complete()
    {
        Console.WriteLine("Enter Enrollment ID to Complete: ");
        int id = int.Parse(Console.ReadLine());

        EnrollmentRepository obj = new EnrollmentRepository();
        int flag = obj.UpdateStatus(id, "Completed");

        if (flag == 1)
        {
            Console.WriteLine("Enrollment Status Updated to Completed Successfully");
        }
        else
        {
            Console.WriteLine("Can't update enrollment data");
        }
    }

    public void Cancel()
    {
        Console.WriteLine("Enter Enrollment ID to Cancel: ");
        int id = int.Parse(Console.ReadLine());

        EnrollmentRepository obj = new EnrollmentRepository();
        int flag = obj.UpdateStatus(id, "Cancelled");

        if (flag == 1)
        {
            Console.WriteLine("Enrollment Status Updated to Cancelled Successfully");
        }
        else
        {
            Console.WriteLine("Can't update enrollment data");
        }
    }

    public void Run()
    {
        bool valid = true;
        while (valid)
        {
            Console.WriteLine("\n--- Enrollment Management ---");
            Console.WriteLine("1. Enroll Student");
            Console.WriteLine("2. List Enrollments");
            Console.WriteLine("3. View Student Courses");
            Console.WriteLine("4. View Course Students");
            Console.WriteLine("5. Complete Enrollment");
            Console.WriteLine("6. Cancel Enrollment");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Display();
                    break;
                case "3":
                    ViewStudentCourses();
                    break;
                case "4":
                    ViewCourseStudents();
                    break;
                case "5":
                    Complete();
                    break;
                case "6":
                    Cancel();
                    break;
                case "0":
                    valid = false;
                    break;
            }
        }
    }
}
    

