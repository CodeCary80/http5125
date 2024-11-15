using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using System;
using MySql.Data.MySqlClient;

namespace School.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context; //Changed 'context' to 'schoolDbContext' for clarity
        
        public StudentAPIController(SchoolDbContext context)
        {
            _context = context;
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
        [HttpGet]
        [Route(template:"ListStudentInfos")]
        public List<Student> ListStudentInfos()
        {
            List<Student> students = new List<Student>(); //Signify a list of stduents


            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                Connection.Open();

                MySqlCommand Command = Connection.CreateCommand();

    
                Command.CommandText = "SELECT * FROM students";
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                int Id = Convert.ToInt32(ResultSet["studentid"]); //Student's ID
                string FirstName = ResultSet["studentfname"]?.ToString() ?? string.Empty; //Student's firstname
                string LastName = ResultSet["studentlname"]?.ToString() ?? string.Empty; ////Student's lastname

                string StudentNumber = ResultSet["studentnumber"]?.ToString() ?? string.Empty; //Student's employeenumber
               
                DateTime StudentEnrolDate = Convert.ToDateTime(ResultSet["enroldate"]); //Student's hiredate

              
                
                
              
    
                 // Create a new Stduent object and initialize with values       
                Student currentStudent = new Student(){
                    StudentID = Id,
                    StudentFName = FirstName,
                    StudentLName = LastName,
                    StudentNumber = StudentNumber,
                    StudentEnrolDate = StudentEnrolDate ,
                        
                };

                students.Add(currentStudent);
                    }
                }                    
            }
            

            return students; // Return a list of Stduents
                    
        }

        /// <summary>
        /// Returns a Student in the school database
        /// </summary>
        /// <example>
        /// GET api/Student/FindStudent/1 -> [studentID":1,"studentFName":"Sarah","studentLName":"Valdez","studentNumber":"N1678","studentEnrolDate": "2018-18T00:00:00"]
        /// </example>
        /// <returns>
        /// strings, Datetime,formatted "{Id} {First Name} {Last Name} {StudentNumber} {StudentEnrolDate}"
        /// </returns>

        [HttpGet]
        [Route("FindStudent/{id}")]
        public Student FindStudent(int id) 
        {
            Student selectedStudent = new Student(); //indicate a Teacher in the school database

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM students WHERE studentid=@id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    if (ResultSet.Read())
                    {
                int Id = Convert.ToInt32(ResultSet["studentid"]);
                string FirstName = ResultSet["studentfname"]?.ToString() ?? string.Empty;
                string LastName = ResultSet["studentlname"]?.ToString() ?? string.Empty;
                string StudentNumber = ResultSet["studentnumber"]?.ToString() ?? string.Empty;
                DateTime StudentEnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);


                        selectedStudent.StudentID = Id;
                        selectedStudent.StudentFName  = FirstName;
                        selectedStudent.StudentLName = LastName;
                        selectedStudent.StudentNumber = StudentNumber;
                        selectedStudent.StudentEnrolDate = StudentEnrolDate;
                
                    }
                }
            }

            return selectedStudent; // Returns a student in the school database
        }
    }
}