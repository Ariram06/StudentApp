using StudentApp.Models;
using StudentApp.Repository;

namespace StudentApp.Services;

using System;
using System.Collections.Generic;
using StudentApp.Models;
using StudentApp.Repository;
using System.ComponentModel.DataAnnotations;
using System.Data;



public class CourseService
{
    public void Register()
    {
        Console.WriteLine("Enter course ID: ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter course name: ");
        string b = Console.ReadLine();

        Console.WriteLine("Enter duration months: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter fee: ");
        decimal d = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter dept ID: ");
        int e = int.Parse(Console.ReadLine());

        List<Course> crs = new List<Course>();
        crs.Add(new Course { CourseId = a, CourseName = b, DurationMonths = c, Fee = d, DepartmentId = e, IsActive = true });

        CourseRepository obj = new CourseRepository();
        obj.AsyncAddCourse(crs);

        Console.WriteLine("Course Added Successfully");
    }

    public void Display()
    {
        CourseRepository obj = new CourseRepository();
        List<Course> l = obj.GetCourseData();

        foreach (Course c in l)
        {
            Console.WriteLine($"ID: {c.CourseId} | Name: {c.CourseName} | Duration: {c.DurationMonths} Months | Fee: {c.Fee} | Dept ID: {c.DepartmentId} | Active: {c.IsActive}");
        }
    }

    public void Search()
    {
        Console.WriteLine("Enter Searching course name: ");
        string name = Console.ReadLine();

        CourseRepository obj = new CourseRepository();
        List<Course> l = obj.SearchData(name);

        if (l.Count == 0)
        {
            Console.WriteLine("No Course Data Exists");
        }
        else
        {
            Console.WriteLine("Course Data Found !:\n ");
            Console.WriteLine($"ID: {l[0].CourseId} | Name: {l[0].CourseName} | Duration: {l[0].DurationMonths} Months | Fee: {l[0].Fee} | Dept ID: {l[0].DepartmentId} | Active: {l[0].IsActive}");
        }
    }

    public void FilterByDept()
    {
        Console.WriteLine("Enter Department ID to filter: ");
        int deptId = int.Parse(Console.ReadLine());

        CourseRepository obj = new CourseRepository();
        List<Course> l = obj.FilterByDepartment(deptId);

        if (l.Count == 0)
        {
            Console.WriteLine("No Course Data Exists for this Department");
        }
        else
        {
            Console.WriteLine("Courses Found:\n ");
            foreach (Course c in l)
            {
                Console.WriteLine($"ID: {c.CourseId} | Name: {c.CourseName} | Duration: {c.DurationMonths} Months | Fee: {c.Fee} | Dept ID: {c.DepartmentId} | Active: {c.IsActive}");
            }
        }
    }

    public void Update()
    {
        Console.WriteLine("Enter ID to Update Data: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter course updated name: ");
        string b = Console.ReadLine();

        Console.WriteLine("Enter updated duration months: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter updated fee: ");
        decimal d = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter updated dept ID: ");
        int e = int.Parse(Console.ReadLine());

        CourseRepository obj = new CourseRepository();
        int flag = obj.UpdateData(new Course { CourseId = id, CourseName = b, DurationMonths = c, Fee = d, DepartmentId = e, IsActive = true });

        if (flag == 1)
        {
            Console.WriteLine("Course data Updated Successfully");
        }
        else
        {
            Console.WriteLine("Can't Update the Data of course");
        }
    }

    public void Deactivate()
    {
        Console.WriteLine("Enter ID to Deactivate Data: ");
        int id = int.Parse(Console.ReadLine());

        CourseRepository obj = new CourseRepository();
        int flag = obj.DeactivateData(id);

        if (flag == 1)
        {
            Console.WriteLine("Course data Deactivated Successfully");
        }
        else
        {
            Console.WriteLine("Can't deactivate the Data of course");
        }
    }

    public void Run()
    {
        bool valid = true;
        while (valid)
        {
            Console.WriteLine("1. Register Course");
            Console.WriteLine("2. Display Courses");
            Console.WriteLine("3. Searching Course");
            Console.WriteLine("4. Filter By Department");
            Console.WriteLine("5. Update Course");
            Console.WriteLine("6. Deactivate Course");
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
                    FilterByDept();
                    break;
                case "5":
                    Update();
                    break;
                case "6":
                    Deactivate();
                    break;
                case "0":
                    valid = false;
                    break;
            }
        }
    }
}

