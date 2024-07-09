namespace BOL;
using StudentApp.Models;
using BOL;
public interface IStudentService
{
    void addNewStudent(Student student);
    void delete(int student_id);
    List<Student> getStudents();

    void Update(Student student);

    List<Student> getByStatus(Status status);

    List<Student> sortStudents();
}
