
# StudentClass application is an ASP.NET MVC5 web site designed to demonstrate a master detail relationship, between Classes in a school and the Student in those classes.


## Pre-requisites:<br />
Visual Studio 2013<br />
IIS<br />
SQL Server<br />
Your SQL Server installation should be the default instance (not YOURMACHINE\SQLEXPRESS).


## Follow these steps to run web site:
1. Under the repository name, click Clone or download. 
2. Build solution.
3. In the Package Manager Console enter the command: update-database.
<br />
The update-database runs the first migration which creates the database. By default, the database is created as a SQL Server Express LocalDB database. <br />
4. Press CTRL+F5 to run the web site.<br />


## Known issue 
Editing of Student and Class not working. 


## TODO
Error Handling.
