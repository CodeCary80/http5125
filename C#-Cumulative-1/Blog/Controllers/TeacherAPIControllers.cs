using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using System;
using MySql.Data.MySqlClient;

namespace School.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context; //Changed 'context' to 'schoolDbContext' for clarity
        
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Returns a list of Teachers in the school database
        /// </summary>
        /// <example>
        /// GET api/Teacher/ListTeacherInfos -> [Alexander Bennett Hire Date: 2016-08-05 12:00:00 AM Employee Number: T378 Salary: $55.30],[Caitlin CummingsHire Date: 2014-06-10 12:00:00 AM Employee Number: T381 Salary: $62.77],...
        /// </example>
        /// <returns>
        /// A list of strings,Datetime, and decimal, formatted "{Id} {First Name} {Last Name} {TeacherHireDate} {EmployeeNumber} {Salary}"
        /// </returns>
        [HttpGet]
        [Route(template:"ListTeacherInfos")]
        public List<Teacher> ListTeacherInfos(DateTime hiredate)
        {
            List<Teacher> teachers = new List<Teacher>(); //Signify a list of teachers 


            using (MySqlConnection Connection = _context.AccessDatabase())
            {

                Connection.Open();

                MySqlCommand Command = Connection.CreateCommand();

    
                Command.CommandText = "SELECT * FROM teachers";
                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    while (ResultSet.Read())
                    {
                           int Id = Convert.ToInt32(ResultSet["teacherid"]); //Teacher's ID
                string FirstName = ResultSet["teacherfname"]?.ToString() ?? string.Empty; //Teacher's firstname
                string LastName = ResultSet["teacherlname"]?.ToString() ?? string.Empty; ////Teacher's lastname
               
                DateTime TeacherHireDate = Convert.ToDateTime(ResultSet["hiredate"]); //Teacher's hiredate

              
                string EmployeeNumber = ResultSet["employeenumber"]?.ToString() ?? string.Empty; //Teacher's employeenumber
                
               
                decimal Salary = Convert.ToDecimal(ResultSet["salary"]); //Teacher's salary
                
              
    
                 // Create a new Teacher object and initialize with values       
                Teacher currentTeacher = new Teacher(){
                    TeacherID = Id,
                    TeacherFName = FirstName,
                    TeacherLName = LastName,
                    TeacherHireDate = TeacherHireDate,
                    EmployeeNumber = EmployeeNumber,
                    TeacherSalary = decimal.Parse(Salary.ToString("F2"))
                        
                };

                teachers.Add(currentTeacher);
                    }
                }                    
            }
            

            return teachers; // Return a list of teachers
                    
        }

        /// <summary>
        /// Returns a Teacher in the school database
        /// </summary>
        /// <example>
        /// GET api/Teacher/FindTeacher/1 -> [Alexander Bennett Hire Date: 2016-08-05 12:00:00 AM Employee Number: T378 Salary: $55.30]
        /// </example>
        /// <returns>
        /// A list of strings,Datetime, and decimal, formatted "{Id} {First Name} {Last Name} {TeacherHireDate} {EmployeeNumber} {Salary}"
        /// </returns>

        [HttpGet]
        [Route("FindTeacher/{id}")]
        public Teacher FindTeacher(int id) 
        {
            Teacher selectedTeacher = new Teacher(); //indicate a Teacher in the school database

            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                MySqlCommand Command = Connection.CreateCommand();
                Command.CommandText = "SELECT * FROM teachers WHERE teacherid=@id";
                Command.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader ResultSet = Command.ExecuteReader())
                {
                    if (ResultSet.Read())
                    {
                             int Id = Convert.ToInt32(ResultSet["teacherid"]);
                string FirstName = ResultSet["teacherfname"]?.ToString() ?? string.Empty;
                string LastName = ResultSet["teacherlname"]?.ToString() ?? string.Empty;
                
               
                DateTime TeacherHireDate = Convert.ToDateTime(ResultSet["hiredate"]);

              
                string EmployeeNumber = ResultSet["employeenumber"]?.ToString() ?? string.Empty;
                
               
                decimal Salary = Convert.ToDecimal(ResultSet["salary"]);

                        selectedTeacher.TeacherID = Id;
                        selectedTeacher.TeacherFName  = FirstName;
                        selectedTeacher.TeacherLName = LastName;
                        selectedTeacher.TeacherHireDate = TeacherHireDate;
                        selectedTeacher.EmployeeNumber = EmployeeNumber;
                        selectedTeacher.TeacherSalary  = decimal.Parse(Salary.ToString("F2"));
                
                    }
                }
            }

            return selectedTeacher; // Returns a Teacher in the school database
        }

        internal List<Teacher> ListTeacherInfos()
        {
            throw new NotImplementedException();
        }
    }
}