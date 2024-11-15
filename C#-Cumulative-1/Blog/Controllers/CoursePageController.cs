using School.Models;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
     /// <summary>
    /// Controller for getting course' information on the web page
    /// </summary>
    public class CoursePageController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the public class CoursePageController
        /// </summary>
        /// <param name="api">An instance of the public class CoursePageController to interact with the course API.</param>
        private readonly CourseAPIController _api;
        
        public CoursePageController(CourseAPIController api)
        {
            _api = api;
        }
        /// <summary>
        /// Returns a list of courses in the school database
        /// </summary>
        /// <example>
        /// GET api/Course/ListCourseInfos -> ["courseID": 1, "courseCode": "http5101", "teacherID": 1, "courseStartDate": "2018-09-04T00:00:00", "courseFinishDate": "2018-12-14T00:00:00", "courseName": "Web Application Development"],["courseID": 2, "courseCode": "http5102", "teacherID": 2, "courseStartDate": "2018-09-04T00:00:00", "courseFinishDate": "2018-12-14T00:00:00", "courseName": "Project Management"]...
        /// </example>
        /// <returns>
        /// A list of strings,Datetimes, formatted "{CId} {Code} {Tid} {CourseStartDate} {CourseFinishDate} {CName }"
        /// </returns>
        public IActionResult List()
        {
            List<Course> courses = _api.ListCourseInfos();
            return View(courses);
        }
        /// <summary>
        /// Returns a course in the school database
        /// </summary>
        /// <example>
        /// GET api/Course/FindCourse/1 -> ["courseID": 1, "courseCode": "http5101", "teacherID": 1, "courseStartDate": "2018-09-04T00:00:00", "courseFinishDate": "2018-12-14T00:00:00", "courseName": "Web Application Development"]
        /// </example>
        /// <returns>
        /// Strings, Datetimes, formatted "{CId} {Code} {Tid} {CourseStartDate} {CourseFinishDate} {CName }"
        /// </returns>

        public IActionResult Show(int id)
        {
            Course selectedCourse = _api.FindCourse(id);
            return View(selectedCourse);
        }

    }
}