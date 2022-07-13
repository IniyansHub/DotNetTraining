using Microsoft.AspNetCore.Mvc;
using SimpleDashboard.Models;
namespace SimpleDashboard.Controllers
{
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        [Route("first")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("details")]
        public IActionResult GetStudentDetails()
        {
            List<StudentsModel> students = getDetails();
            return View(students);
        }

        private List<StudentsModel> getDetails()
        {
            List<StudentsModel> students = new List<StudentsModel>();
            var std1 = new StudentsModel();
            std1.studentId = 1;
            std1.Name = "Iniyan";
            std1.Marks = 100;
            students.Add(std1);

            var std2 = new StudentsModel();
            std2.studentId = 2;
            std2.Name = "Avinash";
            std2.Marks = 99;
            students.Add(std2);

            return students;
        }

    }
}
