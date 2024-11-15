using School.Models;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
     /// <summary>
    /// Controller for getting students' information on the web page
    /// </summary>
    public class StudentPageController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the public class StudentPageController
        /// </summary>
        /// <param name="api">An instance of the public class StudentPageController to interact with the student API.</param>
        private readonly StudentAPIController _api;
        
        public StudentPageController(StudentAPIController api)
        {
            _api = api;
        }
        /// <summary>
        /// Returns a list of Stduents in the school database
        /// </summary>
        /// <example>
        /// GET api/Student/ListStudentInfos -> [studentID":1,"studentFName":"Sarah","studentLName":"Valdez","studentNumber":"N1678","studentEnrolDate": "2018-18T00:00:00"],["studentID": 2,"studentFName": "Jennifer","studentLName": "Faulkner","studentNumber": "N1679","studentEnrolDate": "2018-08-02T00:00:00"]...
        /// </example>
        /// <returns>
        /// A list of strings,Datetime, formatted "{Id} {First Name} {Last Name} {StudentNumber} {StudentEnrolDate}"
        /// </returns>
        public IActionResult List()
        {
            List<Student> students = _api.ListStudentInfos();
            return View(students);
        }
        /// <summary>
        /// Returns a Student in the school database
        /// </summary>
        /// <example>
        /// GET api/Student/FindStudent/1 -> [studentID":1,"studentFName":"Sarah","studentLName":"Valdez","studentNumber":"N1678","studentEnrolDate": "2018-18T00:00:00"]
        /// </example>
        /// <returns>
        /// Strings, Datetime, formatted "{Id} {First Name} {Last Name} {StudentNumber} {StudentEnrolDate}"
        /// </returns>

        public IActionResult Show(int id)
        {
            Student selectedStudent = _api.FindStudent(id);
            return View(selectedStudent);
        }

    }
}