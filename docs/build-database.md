# Build database
Building the database is important prior to launching the program. The MySQL/MariaDB database must be filled with a lot of tables, columns and some default data in order to make RA work.

1. Build Solution in Visual Studio
2. Go to Tools->Command Line->Developer Command Prompt
3. Once the cmd window is open, install entity framework tools using `dotnet tool install --global dotnet-ef`
4. navigate to the "RA.Database" and type `dotnet ef migrations script 0 -o MigrationScript.sql`
5. If everything goes fine, you should have a sql script named after "MigrationScript.sql"
6. Go to your SQL Manager (MySQL Workbench, HeidiSQL etc) and create a database called "ra_prod1" in your server
7. Inside the database execute the script we built earlier (the "MigrationScript.sql")
   
