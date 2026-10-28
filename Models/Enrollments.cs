using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Models;
public class Enrollments
{
    public int EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
    public string Status { get; set; } = "Enrolled";


    public Enrollments(int enrollmentId, int studentId, int courseId, DateTime enrolledAt, string status)
    {
        EnrollmentId = enrollmentId;
        StudentId = studentId;
        CourseId = courseId;
        EnrolledAt = enrolledAt;
        Status = status;
    }
}
