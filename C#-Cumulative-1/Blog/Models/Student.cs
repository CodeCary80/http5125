namespace School.Models
{
    /// <summary>
    /// Represents a student in the school.models from the database.
    /// </summary>
    public class Student
    {
         /// <summary>
        /// Use ID as the primary key in the database to identify students, and gets their information
        /// </summary>
         public int StudentID { get; set; }
         /// <summary>
        /// Gets or sets the first name of the student, and also makes it be nullable to allow missing first name in certain cases
        /// Identifies the first name of a student in the database 
        /// </summary>
        public string? StudentFName { get; set; } 
        /// <summary>
        /// Gets or sets the last name of the student, and also makes it be nullable to allow missing last name in certain cases
        /// Identifies the last name of a student in the database 
        /// </summary>
        public string? StudentLName { get; set; } 
         /// <summary>
        /// Gets or sets the student number of the student, and also make it be nullable for the some cases that stduent number may not be set
        ///Identifies the stduent number of a stduent in the database 
        /// </summary>
        public string? StudentNumber { get; set; } 
        /// <summary>
        /// Gets or sets the date when the stduent was enrolled, and also make it be nullable for the some cases that student enrol date may not be set
        ///Identifies the enrol date of a student in the database 
        /// </summary>
        
        public DateTime? StudentEnrolDate { get; set; }

}
}