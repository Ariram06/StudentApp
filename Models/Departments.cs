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
}
