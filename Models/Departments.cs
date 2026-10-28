using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Models;


public class Departments
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public string? Location { get; set; }
    public bool IsActive { get; set; }


    public Departments(int a, string b, string c, bool d)
    {
        DepartmentId = a;
        DepartmentName = b; Location = c; IsActive = d;
    }
}
