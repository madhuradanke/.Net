using BOL;
using DAl;
using StudentApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StudentApp.Repository
{
    public class StudentManagerImpl : IStudentManager
    {
        public StudentManagerImpl()
        {
        }

        public void addNewStudent(Student student)
        {
            using (var context = new CollectionsContext())
            {
                context.students.Add(student);
                context.SaveChanges();
            }
        }

        public void delete(int student_id)
        {
            using (var context = new CollectionsContext())
            {
                context.students.Remove(context.students.Find(student_id));
                context.SaveChanges();
            }

        }

        public List<Student> getByStatus(Status status)
        {
            List<Student> list = new List<Student>();
            using (var context = new CollectionsContext())
            {
                return context.students.Where(s => s.Status == status).ToList();
            }
        }
        public List<Student> getStudents()
        {
            List<Student> students = new List<Student>();
            using (var context = new CollectionsContext())
            {
                foreach (Student s in context.students)
                {
                    students.Add(s);
                }
            }
            return students;
        }

        public List<Student> sortStudents()
        {
            List <Student> students = new List<Student>();
            using (var context = new CollectionsContext())
            {
               students=  context.students.OrderBy(s => s.student_name).ToList();
            }
            return students;
        }

        public void update(Student student)
        {
            using (var context = new CollectionsContext())
            {
                var stud = context.students.Find(student.student_id);
                stud.student_name = student.student_name;
                stud.Email = student.Email;
                stud.Mobile = student.Mobile;
                stud.Address= student.Address;
                stud.admission_date = student.admission_date;
                stud.Fees = student.Fees;
                stud.Status = student.Status;
                context.SaveChanges();
            }
        }
    }
}
