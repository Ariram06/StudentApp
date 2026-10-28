using System;
using System.Collections.Generic;
using System.Text;
using StudentApp.Models;
using StudentApp.Repository;

namespace StudentApp.Services
{
   

    public class DepartmentService
    {
        public void Register()
        {
            Console.WriteLine("Enter department ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter department name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter description: ");
            string desc = Console.ReadLine();

            List<Departments> dept = new List<Departments>();
            dept.Add(new Departments(id, name, desc, true));

            DepartmentRepository obj = new DepartmentRepository();
            obj.AsyncAddDepartment(dept);

            Console.WriteLine("Department Added Successfully");
        }

        public void Display()
        {
            DepartmentRepository obj = new DepartmentRepository();
            List<Departments> l = obj.GetDepartmentData();

            foreach (Departments d in l)
            {
                Console.WriteLine($"ID: {d.DepartmentId} | Name: {d.DepartmentName} | Description: {d.Location} | Active: {d.IsActive}");
            }
        }

        public void Search()
        {
            Console.WriteLine("Enter Searching department name: ");
            string name = Console.ReadLine();

            DepartmentRepository obj = new DepartmentRepository();
            List<Departments> l = obj.SearchData(name);

            if (l.Count == 0)
            {
                Console.WriteLine("No Department Data Exists");
            }
            else
            {
                Console.WriteLine("Department Data Found !:\n ");
                Console.WriteLine($"ID: {l[0].DepartmentId} | Name: {l[0].DepartmentName} | Description: {l[0].Location} | Active: {l[0].IsActive}");
            }
        }

        public void Update()
        {
            Console.WriteLine("Enter ID to Update Data: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter department updated name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter updated description: ");
            string desc = Console.ReadLine();

            DepartmentRepository obj = new DepartmentRepository();
            int flag = obj.UpdateData(new Departments(id, name, desc, true));

            if (flag == 1)
            {
                Console.WriteLine("Department data Updated Successfully");
            }
            else
            {
                Console.WriteLine("Can't Update the Data of department");
            }
        }

        public void Deactivate()
        {
            Console.WriteLine("Enter Department ID to Deactivate: ");
            int id = int.Parse(Console.ReadLine());

            DepartmentRepository obj = new DepartmentRepository();
            int flag = obj.DeactivateData(id);

            if (flag == 1)
            {
                Console.WriteLine("Department Deactivated Successfully");
            }
            else
            {
                Console.WriteLine("Can't deactivate the Data of department");
            }
        }

        public void Run()
        {
            bool valid = true;
            while (valid)
            {
                Console.WriteLine("\n--- Department Management ---");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Searching");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Deactivate");
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
                        Deactivate();
                        break;
                    case "0":
                        valid = false;
                        break;
                }
            }
        }
    }

}
