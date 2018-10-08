# WebServices_DBConnectivity
ASP.NET project consisting of following 2 REST Web Services (to insert random data to SQL DB and to return all data stored in that DB)

You can use Postman (or something like it) to Send or Receive data through those Services.

DB is a file-based SQL data base which contains a table 'Employees' with the following fields:
Id, Name, Department, Rate.

To read all data from the DB you need to call GET command using 'http://localhost:49576/Employee/GetEmployees' URL.

To insert a new data to the DB you need to call POST command using 'http://localhost:49576/Employee/InsertEmployee' URL. Data can be posted from Body using JSON format like: 

{
	"name": "Name_xxx",
	"department": "Dept_xxx",
	"rate": 10
}
