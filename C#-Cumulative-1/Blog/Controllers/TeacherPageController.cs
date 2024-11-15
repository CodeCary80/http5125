using School.Models;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
     /// <summary>
    /// Controller for getting teachers' information on the web page
    /// </summary>
    public class TeacherPageController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the public class TeacherPageController
        /// </summary>
        /// <param name="api">An instance of the public class TeacherPageController to interact with the teacher API.</param>
        private readonly TeacherAPIController _api;
        
        public TeacherPageController(TeacherAPIController api)
        {
            _api = api;
        }
        /// <summary>
        /// Returns a list of Teachers and their information in the system.
        /// </summary>
        /// <example>
        /// GET api/TeacherPage/List -> [Alexander Bennett Hire Date: 2016-08-05 12:00:00 AM Employee Number: T378 Salary: $55.30}],[Caitlin CummingsHire Date: 2014-06-10 12:00:00 AM Employee Number: T381 Salary: $62.77],...
        /// </example>
        /// <returns>
        /// A list of teacher objects.
        /// </returns>
        public IActionResult List(DateTime hiredate)
        {
            List<Teacher> teachers = _api.ListTeacherInfos(hiredate);
            if (teachers == null)
            {
                return NotFound("404 Not found");   
            }

            return View(teachers);
        }
         /// <summary>
        /// Returns a  Teachers and his information in the system.
        /// </summary>
        /// <example>
        /// GET api/TeacherPage/List -> [Caitlin Cummings Hire Date: 2014-06-10 12:00:00 AM Employee Number: T381 Salary: $62.77]
        /// </example>
        /// <returns>
        /// A teacher's information.
        /// </returns>

        public IActionResult Show(int id)
        {
            Teacher selectedTeacher = _api.FindTeacher(id);
            if (selectedTeacher == null)
            {
                return NotFound("404 Not found");   
            }
            return View(selectedTeacher);
        }

      
}
}