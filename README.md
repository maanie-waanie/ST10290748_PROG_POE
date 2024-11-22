Aman Adams's (ST10290748) PROG 2B POE Part 3

Steps to Run the Application

System Requirements
-

-Before running the application, ensure the following tools and frameworks are installed on your system:

-.NET SDK: Version 6.0 or later (preferably 8.0).

-Visual Studio 2022: Community or higher edition with ASP.NET and web development workload installed.

-Web Browser: Any modern browser (e.g., Chrome, Edge, Firefox).

-Clone the Repository:

-Download or clone the project repository from the provided GitHub link

-Navigate to the project folder

-Open the Project in Visual Studio:

-Open Visual Studio.

-Select File → Open → Project/Solution and navigate to the project folder.

-Open the .csproj file.

Restore Dependencies:
-

-Ensure all required NuGet packages are installed by running

-Alternatively, in Visual Studio, right-click on the solution in the Solution Explorer and select Restore NuGet Packages.

-Run Migrations:
-Open the Package Manager Console in Visual Studio (Tools → NuGet Package Manager → Package Manager Console).
-Apply migrations to create the database
Update-Database 

-Run the Application:

-Press F5 in Visual Studio to run the application in Debug mode, or Ctrl+F5 to run without debugging.

-The application will open in your default browser at a URL like:
http://localhost:5000 (HTTP)
https://localhost:5001 (HTTPS)

-Login with Predefined Credentials:
Use the following credentials to access the system:
Lecturer: Email: lecturer@poe.com Password: Lecturer@123
Coordinator: Email: coordinator@poe.com Password: Coordinator@123 
HR: Email: hr@poe.com Password: HR@123





