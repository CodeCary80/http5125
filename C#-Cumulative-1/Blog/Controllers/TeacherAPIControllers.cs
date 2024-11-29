using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using System;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

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
         /// <summary>
        /// Adds an teacher to the database
        /// </summary>
        /// <param name="TeacherData">Teacher Object</param>
        /// <example>
        /// POST: api/Teacher/AddTeacher
        /// Headers: Content-Type: application/json
        /// Request Body:
        /// {
        ///	    "teacherID": 14,
        ///	    "teacherFName": "Alicia",
        ///	    "teacherLName": "Florrick",
        ///	    "teacherHireDate": "2024-11-29T00:24:28.450Z",
        ///	    "teacherSalary": 85.92
        /// } -> 16(I have deleted it two times while adding other new teachers, this time when i added this teacher, it returned 16 as 'id' is configured as an auto-increment or identity column in the database I think maybe )
        /// </example>
        /// <returns>
        /// The inserted Teacher Id from the database if successful. 500 if Unsuccessful
        /// </returns>
        [HttpPost(template:"AddTeacher")]
        public IActionResult AddTeacher([FromBody]Teacher TeacherData)
        {
            try{
                 // if Teacher Name is empty, it returns error message
        if (string.IsNullOrEmpty(TeacherData.TeacherFName))
        {
            return BadRequest( " Name cannot be empty!" );
        }
        if (string.IsNullOrEmpty(TeacherData.TeacherLName))
        {
            return BadRequest( " Name cannot be empty!" );
        }
                // if Teacher Hire Date is in the future, it returns error message
        if (TeacherData.TeacherHireDate > DateTime.Now)
        {
            return BadRequest("Date cannot be after the current date");
        }
        // if Employee Number does not match "T" followed by digits (e.g., T123), it returns error message
        // applying 'using System.Text.RegularExpressions' to ensure Regex to work
        if (!Regex.IsMatch(TeacherData.EmployeeNumber, @"^T\d+$"))
        {
            return BadRequest("Employeenumber needs to start with 'T'");
        }
        // if Employee Number already taken, it returns error message
        using (MySqlConnection connection = _context.AccessDatabase())
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM teachers WHERE employeenumber = @employeenumber";
            command.Parameters.AddWithValue("@employeenumber", TeacherData.EmployeeNumber);
            int existedRepeatingEmployeeNumber = Convert.ToInt32(command.ExecuteScalar());

            // existedRepeatingEmployeeNumber is the count of the how many employee number are repeating in the database
            if (existedRepeatingEmployeeNumber > 0)
            {
                return BadRequest("The employee number is already existed" );
            }
        }

            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                // @hiredate for the teacher join date in this context to main consistency
                Command.CommandText = "insert into teachers (teacherfname, teacherlname, hiredate, employeenumber, salary) values (@teacherfname, @teacherlname, @hiredate, @employeenumber, @salary)";
                Command.Parameters.AddWithValue("@teacherfname", TeacherData.TeacherFName);
                Command.Parameters.AddWithValue("@teacherlname", TeacherData.TeacherLName);
                 Command.Parameters.AddWithValue("@hiredate", TeacherData.TeacherHireDate);
                Command.Parameters.AddWithValue("@employeenumber", TeacherData.EmployeeNumber );
                Command.Parameters.AddWithValue("@salary", TeacherData.TeacherSalary);

                Command.ExecuteNonQuery();
                 /* (unreachable) return Convert.ToInt32(Command.LastInsertedId);*/
                int insertedId = Convert.ToInt32(Command.LastInsertedId);
                return Ok(insertedId);
              }
                
            }

            // use try-catch to ensure the app doesn't crash when errors happen
            catch (Exception ex)
    {
        return StatusCode(500, "An unexpected error occurred.");
    }
 
        }

         /// <summary>
        /// Deletes a teacher from the database
        /// </summary>
        /// <param name="TeacherId">Primary key of the teacher to delete</param>
        /// <example>
        /// DELETE: api/Teacher/DeleteTeacher/12' -> 1
        /// </example>
        /// <returns>
        /// Number of rows affected by delete operation.
        /// </returns>
         [HttpDelete(template:"DeleteTeacher/{TeacherId}")]
        public int DeleteTeacher(int TeacherId)
        {
            // 'using' will close the connection after the code executes
            using (MySqlConnection Connection = _context.AccessDatabase())
            {
                Connection.Open();
                //Establish a new command (query) for our database
                MySqlCommand Command = Connection.CreateCommand();

                
                Command.CommandText = "delete from teachers where teacherid=@id";
                Command.Parameters.AddWithValue("@id", TeacherId);
                return Command.ExecuteNonQuery();

            }

    }
     
 }
}

