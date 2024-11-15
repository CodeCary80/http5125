namespace School.Models
{
    /// <summary>
    /// Represents a course in the school.models from the database.
    /// </summary>
    public class Course
    {
         /// <summary>
        /// Use ID as the primary key in the database to identify courses, and gets their information
        /// </summary>
         public int CourseID { get; set; }
         /// <summary>
        /// Gets or sets the Course ID of the course, and also makes it be nullable to allow missing Course Code in certain cases
        /// Identifies the Course Code of a course in the database 
        /// </summary>
        public string? CourseCode { get; set; } 
        /// <summary>
        /// Gets or sets the Teacher ID of the course, and also makes it be nullable to allow missing Teacher ID in certain cases
        /// Identifies the Teacher ID of a course in the database 
        /// </summary>
         public int TeacherID { get; set; }
        /// <summary>
        /// Gets or sets the date when the course was started, and also make it be nullable for the some cases that Course StartDate may not be set
        ///Identifies the startdate of a course in the database 
        /// </summary>
        public DateTime? CourseStartDate { get; set; }
        /// <summary>
        /// Gets or sets the date when the course was finished, and also make it be nullable for the some cases that Course fnishDate may not be set
        ///Identifies the finishdate of a course in the database 
        /// </summary>
        public DateTime? CourseFinishDate { get; set; }
         /// <summary>
        /// Gets or sets the Course Name of the course, and also makes it be nullable to allow missing Course name in certain cases
        /// Identifies the Course Name of a course in the database 
        /// </summary>
        public string? CourseName { get; set; } 

}
}