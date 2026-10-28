using System;
using System.Collections.Generic;
using StudentApp.Models;
using StudentApp.Repository;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentApp.Services;

public class StudentService
{
    public void Register()
    {
        Console.WriteLine("Enter student ID: ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter student name: ");
        string b = Console.ReadLine();

        Console.WriteLine("Enter email: ");
        string c = Console.ReadLine();

        Console.WriteLine("Enter age: ");
        int d = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter dept ID: ");
        int e = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Admission date: ");
        DateTime f;
        if (DateTime.TryParse(Console.ReadLine(), out f)) { }
        else Console.WriteLine("Enter valid date data");

        List<Student> std = new List<Student>();
        std.Add(new Student(a, b, c, d, e, f, true));

        StudentRepository obj = new StudentRepository();
        obj.AsyncAddStudent(std);

        Console.WriteLine("Student Added Successfully");
    }

    public void Display()
    {
        StudentRepository obj = new StudentRepository();
        List<Student> l = obj.GetStudentData();

        foreach (Student s in l)
        {
            Console.WriteLine($"ID: {s.StudentId} | Name: {s.Name} | Email: {s.Email} | Age: {s.Age} | Dept ID: {s.DepartmentId} | Date: {s.AdmissionDate.ToShortDateString()} | Active: {s.IsActive}");
        }
    }

    public void Search()
    {
        Console.WriteLine("Enter Searching student name: ");
        string name = Console.ReadLine();

        StudentRepository obj = new StudentRepository();
        List<Student> l = obj.SearchData(name);

        if (l.Count == 0)
        {
            Console.WriteLine("No Student Data Exists");
        }
        else
        {
            Console.WriteLine("Student Data Found !:\n ");
            Console.WriteLine($"ID: {l[0].StudentId} | Name: {l[0].Name} | Email: {l[0].Email} | Age: {l[0].Age} | Dept ID: {l[0].DepartmentId} | Date: {l[0].AdmissionDate.ToShortDateString()} | Active: {l[0].IsActive}");
        }
    }

    public void Update()
    {
        Console.WriteLine("Enter ID to Update Data: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter student updated name: ");
        string b = Console.ReadLine();

        Console.WriteLine("Enter updated email: ");
        string c = Console.ReadLine();

        Console.WriteLine("Enter updated age: ");
        int d = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter updated dept ID: ");
        int e = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter updated Admission date: ");
        DateTime f;
        if (DateTime.TryParse(Console.ReadLine(), out f)) { }
        else Console.WriteLine("Enter valid date data");

        List<Student> std = new List<Student>();
        std.Add(new Student(id, b, c, d, e, f, true));

        StudentRepository obj = new StudentRepository();
        int flag = obj.UpdateData(new Student(id, b, c, d, e, f, true));

        if (flag == 1)
        {
            Console.WriteLine("Student data Updated Successfully");
        }
        else
        {
            Console.WriteLine("Can't Update the Data of student");
        }
    }

    public void Delete()
    {
        Console.WriteLine("Enter ID to Update Data: ");
        int id = int.Parse(Console.ReadLine());

        StudentRepository obj = new StudentRepository();
        int flag = obj.DeleteData(id);

        if (flag == 1)
        {
            Console.WriteLine("Student data Deleted Successfully");
        }
        else
        {
            Console.WriteLine("Can't delete the Data of student");
        }
    }

    public void Run()
    {
        bool valid = true;
        while (valid)
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Searching");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
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
                    Search();
                    break;
                case "4":
                    Update();
                    break;
                case "5":
                    Delete();
                    break;
                case "0":
                    valid = false;
                    break;
            }
        }
    }
}
