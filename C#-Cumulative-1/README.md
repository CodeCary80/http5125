# ASP.NET Core Blog Application
This example connects our server to a MySQL Database with MySql.Data.MySqlClient.
- Models/SchoolDbContext.cs
    - A class which represents the connection to the database. 
- Controllers/TeacherAPIController.cs and 
Controllers/TeacherPageController.cs
    - two APIs Controller which allow us to access information about Teachers
-List/Show.cshtml 
 Razor view file that renders the HTML for displaying a list of teachers ,click one of them to get specific details. 
-Teacher.cs
The services we need for everything connects, including the information in database.
- Program.cs
    - Configuration of the application
## How to Install:
1. Download [MAMP](https://www.mamp.info/en/downloads/) or similar MySQL environment
2. [Download schooldb.sql from course]
3. Create a blog database 
    - PhpyMyAdmin -> new database -> school
4. : Import Tables [VIDEO GUIDE](https://youtu.be/wWMcIza-k4s)
  - PhpMyAdmin -> Import -> Upload schooldb.sql
5. Access Connection String properties for your blog DB and change User, Pass, Port, Database, Server in "/Models/SchoolDbContext.cs".
6. Make sure "MySQL.Data" is installed in your project
    - If not installed, go to "Tools" > "Nuget Package Manager" > "Manage Nuget Packages for Solution" > "Browse" > type "MySQL.Data" > "Install"
7. Run the project debugging mode (F5) **while** the database environment is running
8. : Test to see if the ListAuthorNames API responds with information about authors.
    - 
GET api/TeacherPage/List 
   
## Common Errors
System.InvalidOperationException: Unable to resolve service for type 'School.Controllers.TeacherAPIController' while attempting to activate 'School.Controllers.TeacherPageController'

InvalidOperationException: The view 'List' was not found. The following locations were searched: /Views/TeacherPage/List.cshtml /Views/Shared/List.cshtml

