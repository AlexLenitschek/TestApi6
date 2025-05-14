This is a ReadMe file for the `ASP.NET Web API CRUD Operations - .NET8 and Entity Framework Core` project.
It follows the following Tutorial: "https://www.youtube.com/watch?v=6YIRKBsRWVI"
This project demonstrates how to perform basic CRUD (Create, Read, Update, Delete) operations using ASP.NET Web API. 
The project is structured to provide a clear understanding of how to set up a Web API and interact with a database using Entity Framework.

Let Me Give a short Step by Step Explanation of the steps discussed in the Video.

1. **Create a New Project**: Start by creating a new ASP.NET Web API project in Visual Studio. Choose the appropriate template and configure the project settings.

2. **Install Entity Framework**: Use NuGet Package Manager to install Entity Framework, which will help in database operations. Especially EF Core SQL Server and EF Core Tools.

3. **Create a Model**: Define a model class that represents the data structure you want to work with. 
	For example, create an `Employee` class with properties like `Guid Id`, `Name`, `Position`, etc.
	Here you can use the required Keyword before the type of the property to make it required.

4. **Create a Database Context**: Create a database context class that inherits from `DbContext`. 
	This class will manage the connection to the database and provide access to the data.
	Make sure the constructor has the `DbContextOptions option` parameter and inherits from the `base(options)` class.
	In here we are using the `public DbSet<Employee> Employees { get; set}` to represent the Employees table in the database.

5. **Configure Database Connection**: In the `appsettings.json` file, configure the connection string to connect to your SQL Server database. 
	Make sure to use the correct server name and database name. Mine is a dot `.` which means the local machine.
	"ConnectionStrings": {
        "DefaultConnection": "Server=.;Database=EmployeesDb;Trusted_connection=true;TrustServerCertificate=true"
    }
	Àlso don't forget to add the following in the Program.cs file:
	builder.Services.AddDbContext<EmployeesDbContext>(options => 
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

6. **Add Migrations**: Use the Package Manager Console to add migrations ` add-migration "initial migration" `and update `update database` the database.

7. **Create a Controller**: Create a controller class that will handle HTTP requests. 
	Use the `[ApiController]` and `[Route("api/[controller]")]` attributes to define the routing for the controller.
	Here we are using the `EmployeesController` class which inherits from `ControllerBase` and has the following methods (All of the type IActionResult): 
	- `GetAllEmployees()`: Retrieves all employees from the database.
	- `GetEmployeeById(Guid id)`: Retrieves a specific employee by ID.
	- `AddEmployee(AddEmployeeDto employee)`: Adds a new employee to the database.
	- `UpdateEmployee(Guid id, UpdateEmployeeDto employee)`: Updates an existing employee.
	- `DeleteEmployee(Guid id)`: Deletes an employee by ID.
	--> You might have noticed the usage of DTOs (Data Transfer Objects) in the Add and Update methods. 
		These are simple classes that represent the data structure for adding and updating employees.
		For example, `AddEmployeeDto` and `UpdateEmployeeDto` classes with all the same properties except for `id`.
		The point of using DTOs is to separate the data structure used in the API from the data structure used in the database to avoid exposing sensitive data.

8. **Test the API**: Use tools like Postman or Swagger to test the API endpoints.