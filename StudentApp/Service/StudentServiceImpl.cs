using StudentApp.Models;
using DAl;
using StudentApp.Repository;


namespace BOL
{
    public class StudentServiceImpl : IStudentService
    {
        StudentManagerImpl studentManager = new StudentManagerImpl();
        public void addNewStudent(Student student)
        {
            studentManager.addNewStudent(student);
        }

        public void delete(int student_id)
        {
            studentManager.delete(student_id);
        }

        public List<Student> getByStatus(Status status)
        {
          return  studentManager.getByStatus(status);
        }

        public List<Student> getStudents()
        {
            return studentManager.getStudents();
        }

        public List<Student> sortStudents()
        {
            List<Student> students = studentManager.sortStudents();
            return students;
        }

        public void Update(Student student)
        {
             studentManager.update(student);
        }
    }
}
