namespace StudentApp.Models;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; } 
    public string Email { get; set; } 
    public int Age { get; set; }
    public int DepartmentId { get; set; }
    public DateTime AdmissionDate { get; set; }
    public bool IsActive { get; set; }


    public Student(int a,string b,string c,int d,int e,DateTime f,bool g)
    {
        StudentId = a;Name = b;Email = c;Age = d;DepartmentId = e;AdmissionDate = f;IsActive = g;
    }
}
