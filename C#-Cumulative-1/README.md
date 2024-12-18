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

## How to get the list of items' information or only one item's detail from the database:
1. check on teacher/course/student APIcontroller to see ListTeacherInfos and FindTeacher function
2. if you want them demonstrate on the web page, creating pagecontroller that links to List.cshtml and show.cshtml to build the function

## How to add new one item's detail to the database or delete an existing item from the database;?
1. check on teacher/course/student APIcontroller to see AddTeachers and DeleteTeacher function
2. If you want them to demonstrate the process and see the result on the web page, create a pagecontroller that links to List.cshtml and Show.cshtml, while adding New.cshtml's link to List.cshtml so you can add a new item anytime, and adding DeleteConfirm.cshtml's link to Show.cshtml so you can delete this item anytime.
## Common Errors
1. System.InvalidOperationException: Unable to resolve service for type 'School.Controllers.TeacherAPIController' while attempting to activate 'School.Controllers.TeacherPageController'

2. InvalidOperationException: The view 'List' was not found. The following locations were searched: /Views/TeacherPage/List.cshtml /Views/Shared/List.cshtml

3. If your database's column is auto-incremented then it will automatically assign unique id to your item instead of using the one you set up, make sure to check your item's id in the database and make error handling when trying to delete a teacher that does not exist.

4. Beware of writing errors, it's @Model not @model, and when updating teacher don't write an extra @ in the command, e.g. hiredate = @@hiredate.