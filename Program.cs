using StudentApp.Models;
using StudentApp.Services;
using StudentApp.Repository;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Student App for practice DB");
        bool valid = true;

        StudentService obj1 = new StudentService();
        CourseService obj2 = new CourseService();
        while (valid)
        {

            Console.WriteLine("1.studnt Service");
            Console.WriteLine("2.course Service");
            Console.WriteLine("3. Departments Service");
            Console.WriteLine("4. Enrollments  Service");
            Console.WriteLine("5.Auditlags Service");
            Console.WriteLine("0.exit ");

            Console.WriteLine("enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    obj1.Run();
                    break;

                case "2":
                    obj2.Run();
                    break;

            }
        }
    }
}