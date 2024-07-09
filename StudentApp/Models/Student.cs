using StudentApp.Models;
namespace BOL
{
    public class Student
    {
        public int student_id { get; set; }
        public string student_name { get; set; }
        public string Email { get;  set;}
        public string Mobile { get; set;}
        public string Address {  get; set;}
        public DateOnly admission_date { get; set;}
        public double Fees { get; set;}
        public Status Status {  get; set;}

        public Student(int studentId, string studentName, string email, string mobile, string address, DateOnly admissionDate, double fees, Status status)
        {
            student_id = studentId;
            student_name = studentName;
            Email = email;
            Mobile = mobile;
            Address = address;
            admission_date = admissionDate;
            Fees = fees;
            Status = status;
        }

        public Student(string studentName, string email, string mobile, string address, DateOnly admissionDate, double fees, Status status)
        {
            student_name = studentName;
            Email = email;
            Mobile = mobile;
            Address = address;
            admission_date = admissionDate;
            Fees = fees;
            Status = status;
        }

        public Student()
        {
        }
    }
}
