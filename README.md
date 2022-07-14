# ReminderCreate New Project Asp.net core Web App
Right Click on the Project and go to Manage NuGet Packages - entity framework 
   - Microsoft.EntityFrameworkCore
   - Microsoft.EntityFrameworkCore.Design
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools
   - Microsoft.VisualStudio.Web.CodeGeneration
Create DataContext and set connection string for database.
Create model for reminder
Click on Tools > Nugnet Package Manager>> Package Manager Console
Run Enable-Migrations, add-migration, update-database after that "Migrations" folder generated automatically and also create table in database.
Add new controller with the name "Reminder".
hit F5 to run the sample.
Add "app.MapControllers();" in program file.
Changes in controller,pages,layout(add jquery path)  for reminder app. 
