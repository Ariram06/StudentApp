using StudentApp.Models;
using StudentApp.Repository;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.Services;

public class StudentService
{
    public void Register()
    {
        Console.WriteLine("enter student id: ");
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("enter studetn name: ");
        string b = Console.ReadLine();

        Console.WriteLine("enter email:");
        string c = Console.ReadLine();

        Console.WriteLine("enter age: ");
        int d = int.Parse(Console.ReadLine());

        Console.WriteLine("enter dept id: ");
        int e = int.Parse(Console.ReadLine());

        Console.WriteLine("enter Admission date: ");
        DateTime f;
        if (DateTime.TryParse(Console.ReadLine(), out f)) { }
        else Console.WriteLine("enter valid date data");

        List<Student> std = new List<Student>();
        std.Add(new Student(a, b, c, d, e,f, true));

        StudentRepository obj = new StudentRepository();
        obj.AsyncAddStudent(std);

        Console.WriteLine("student Added Suucessfuly ");
    }


    public void Display()
    {
        StudentRepository obj = new StudentRepository();
        List<Student> l = obj.GetStudentData();

        foreach(Student s in l)
        {
            Console.WriteLine($"ID: {s.StudentId} | Name: {s.Name} | Email: {s.Email} | Age: {s.Age} | Dept ID: {s.DepartmentId} | Date: {s.AdmissionDate.ToShortDateString()} | Active: {s.IsActive}");
        }


    }


    public void Run()
    {
        bool valid = true;
        while (valid)
        {

            Console.WriteLine("1.Register");
            Console.WriteLine("2.Display");
            Console.WriteLine("3. searching ");
            Console.WriteLine("4. filter by dept ");
            Console.WriteLine("5.update");
            Console.WriteLine("6.deactivate student ");
            Console.WriteLine("0.exit");

            Console.WriteLine("enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;

                case "2":
                    Display();
                    break;


            }
        }
    }
}
