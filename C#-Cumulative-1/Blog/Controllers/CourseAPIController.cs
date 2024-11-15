using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using System;
using MySql.Data.MySqlClient;

namespace School.Controllers
{
    [Route("api/Course")]
    [ApiController]
    public class CourseAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context; //Changed 'context' to 'schoolDbContext' for clarity
        
        public CourseAPIController(SchoolDbContext context)
        {
            _context = context;
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
        [HttpGet]
        [Route(template:"ListCourseInfos")]
        public List<Course> ListCourseInfos()
        {
            List<Course> courses = new List<Course>(); //Signify a list of teachers 


            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                Connection.Open();

                MySqlCommand Command = Connection.CreateCommand();

    
                Command.CommandText = "SELECT * FROM courses";
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                int CId = Convert.ToInt32(ResultSet["courseid"]); //Teacher's ID
                string Code = ResultSet["coursecode"]?.ToString() ?? string.Empty; //Teacher's firstname
                int TId = Convert.ToInt32(ResultSet["teacherid"]); //Teacher's ID
                DateTime CourseStartDate = Convert.ToDateTime(ResultSet["startdate"]); //Teacher's hiredate
                DateTime CourseFinishDate = Convert.ToDateTime(ResultSet["finishdate"]); //Teacher's hiredate
                string CName = ResultSet["coursename"]?.ToString() ?? string.Empty; //Teacher's firstname
              
                
                
              
    
                 // Create a new Teacher object and initialize with values       
                Course currentCourse = new Course(){
                    CourseID = CId,
                    CourseCode = Code,
                    TeacherID= TId,
                    CourseStartDate = CourseStartDate,
                    CourseFinishDate = CourseFinishDate,
                    CourseName = CName
                        
                };

                courses.Add(currentCourse);
                    }
                }                    
            }
            

            return courses; // Return a list of teachers
                    
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

        [HttpGet]
        [Route("FindCourse/{id}")]
        public Course FindCourse(int id) 
        {
            Course selectedCourse = new Course(); //indicate a Teacher in the school database

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM courses WHERE courseid=@id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    if (ResultSet.Read())
                    {
                 int CId = Convert.ToInt32(ResultSet["courseid"]); //Teacher's ID
                string Code = ResultSet["coursecode"]?.ToString() ?? string.Empty; //Teacher's firstname
                int TId = Convert.ToInt32(ResultSet["teacherid"]); //Teacher's ID
                DateTime CourseStartDate = Convert.ToDateTime(ResultSet["startdate"]); //Teacher's hiredate
                DateTime CourseFinishDate = Convert.ToDateTime(ResultSet["finishdate"]); //Teacher's hiredate
                string CName = ResultSet["coursename"]?.ToString() ?? string.Empty; //Teacher's firstname


                        selectedCourse.CourseID = CId;
                        selectedCourse.CourseCode  = Code;
                        selectedCourse.TeacherID = TId;
                        selectedCourse.CourseStartDate = CourseStartDate;
                        selectedCourse.CourseFinishDate= CourseFinishDate;
                        selectedCourse.CourseName = CName;
                
                    }
                }
            }

            return selectedCourse; // Returns a Teacher in the school database
        }
    }
}