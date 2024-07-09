namespace DAl;
using StudentApp.Models;
using BOL;

public interface IStudentManager
{
    void addNewStudent(Student student);

    List<Student> getStudents();

    void delete(int student_id);

    void update(Student student);

    List<Student> getByStatus(Status status);
    List<Student> sortStudents();
}
