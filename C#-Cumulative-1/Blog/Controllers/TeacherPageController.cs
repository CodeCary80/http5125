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

    
          /// <summary>
        /// Displays a form to create a new teacher. 
        /// </summary>
        /// <example>
        /// GET : TeacherPage/New ->new.cshtml
        /// </example>
        /// <returns>
        /// A view that contains the form for adding a new teacher.
        /// </returns>
        [HttpGet]
        public IActionResult New(int id)
        {
            return View();
        }

         /// <summary>
        /// Adds a new teacher and redirects to the Show page 
        /// </summary>
        /// <example>
        /// POST: TeacherPage/Create -> show.cshtml -> list.cshtml
        /// </example>
        /// <returns>
        /// Redirects to the Show page with the new teacher's ID (but the id could be auto-incremented as it will assign unique id to the new insert so confirm the id in the database) if successful while returning error message if unccessful
        [HttpPost]
        public IActionResult Create(Teacher NewTeacher)
        {
            IActionResult result = _api.AddTeacher(NewTeacher);

            if (result is OkObjectResult okResult)
    {
        // Extract the teacher ID from OkObjectResult
        int teacherId = (int)okResult.Value;

        // Redirect to the "Show" action with the teacherId
        return RedirectToAction("Show", new { id = teacherId });
    }

    // If the result is not successful, return an error on the page
    return View("Error"); // 
        }

        
         /// <summary>
        /// Displays a confirmation page before deleting a teacher.
        /// </summary>
        /// <example>
        /// // GET : TeacherPage/DeleteConfirm/{11} (Cary Agos, teacher ID: 11)-> Are you sure you want to delete Cary Agos? Conform delete -> back to the list
        /// </example>
        /// <returns>
        /// A confirmation page
        /// </returns>
        [HttpGet]
        public IActionResult DeleteConfirm(int id)
        {
            Teacher selectedTeacher = _api.FindTeacher(id);
            return View(selectedTeacher);
        }

          /// <summary>
        /// Deletes the selected teacher by their ID and redirects to the list page. 
        /// </summary>
        /// /// <param name="id">Selected teacher's ID</param>
        /// <example>
        /// POST: /api/Teacher/DeleteTeacher/12 -> 1
        /// </example>
        /// <returns>
        /// A list without the selected teacher
        /// </returns>
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int TeacherId = _api.DeleteTeacher(id);
            // redirects to list action
            return RedirectToAction("List");
        }

      
}
}