using Microsoft.AspNetCore.Mvc;
using BOL;
using StudentApp.Models;
namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(string studentName, string email, string mobile, string address, string admissionDate, double fees, string status)
        {
            DateOnly date = DateOnly.Parse(admissionDate);
            if (!Enum.TryParse<Status>(status, out var parsedStatus))
            {
                return BadRequest("Invalid status value.");
            }
            Student student = new Student(studentName, email, mobile, address, date, fees, parsedStatus);
            _studentService.addNewStudent(student);
            return View();
        }


        [HttpGet]
        public IActionResult DeleteStudent()
        {
            return View();
        }


        [HttpPost]
        public IActionResult DeleteStudent(int student_id)
        {
            _studentService.delete(student_id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> students = _studentService.getStudents();
            ViewData["catalog"] = students;
            return View();
        }

        [HttpGet]

        public IActionResult UpdateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStudent(int student_id, string studentName, string email, string mobile, string address, string admissionDate, double fees, string status)
        {
            DateOnly date = DateOnly.Parse(admissionDate);
            if (!Enum.TryParse<Status>(status, out var parsedStatus))
            {
                return BadRequest("Invalid status value.");
            }
            Student student = new Student(student_id, studentName, email, mobile, address, date, fees, parsedStatus);
            _studentService.Update(student);
            return View();
        }

        [HttpGet]

         public IActionResult GetByStatus(string status)
         {
             if (!Enum.TryParse<Status>(status, ignoreCase: true, out var parsedStatus))
             {
                 return BadRequest("Invalid status value.");
             }

             try
             {
                 var students = _studentService.getByStatus(parsedStatus);
                ViewData["status"] = students;
                return View();
                 //return Json(students); // Return JSON response
             }
             catch (Exception ex)
             {
                 return StatusCode(500, $"Internal server error: {ex.Message}");
             }
         }

        [HttpGet]
        public IActionResult sort()
        {
           List<Student> students= _studentService.sortStudents();
            ViewData["catalog"]=students;
            //return View();
            return Json(students);
        }
    }
    }
    


