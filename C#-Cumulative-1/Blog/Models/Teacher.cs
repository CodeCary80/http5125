namespace School.Models
{
    /// <summary>
    /// Represents a teacher in the school.models from the database.
    /// </summary>
    public class Teacher
    {
         /// <summary>
        /// Use ID as the primary key in the database to identify teachers, and gets their information
        /// </summary>
         public int TeacherID { get; set; }
         /// <summary>
        /// Gets or sets the first name of the teacher, and also makes it be nullable to allow missing first name in certain cases
        /// Identifies the first name of a tacher in the database 
        /// </summary>
        public string? TeacherFName { get; set; } 
        /// <summary>
        /// Gets or sets the last name of the teacher, and also makes it be nullable to allow missing last name in certain cases
        /// Identifies the last name of a tacher in the database 
        /// </summary>
        public string? TeacherLName { get; set; } 
         /// <summary>
        /// Gets or sets the employee number of the teacher, and also make it be nullable for the some cases that employee number may not be set
        ///Identifies the EmployeeNumber of a tacher in the database 
        /// </summary>
        public string? EmployeeNumber { get; set; } 
        /// <summary>
        /// Gets or sets the date when the teacher was joined, and also make it be nullable for the some cases that TeacherHireDate may not be set
        ///Identifies the hiredate of a tacher in the database 
        /// </summary>
        
        public DateTime? TeacherHireDate { get; set; }
        /// <summary>
        /// Gets or sets the salary of the teacher, and also make it be nullable for the some cases that TeacherSalary   may not be se
        ///Identifies the salary of a tacher in the database 
        /// </summary>
        public decimal? TeacherSalary { get; set; }
}
}