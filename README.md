# Selling-SellingMachine
# Overview

I'm trying to develop a sotware that manages stock and handles the selling of products using C#, winforms and SQL server so that I can improve my skills in C# and SQL relational database.

The program uses SQL commands to intract ,retrieve and manipulate data in the SQL Server database and the purpose of writing this program is to improve my C# skills andlearn how to create a windows app that perform CRUD features to a SQL server database.


[Software Demo Video](https://youtu.be/c5rGu_G0YMs)

# Relational Database

I'm using SQL server database for my application and the database has the following entities:
Users entity that manages the user account and profile
UsersManagement entity that manages roles of users and it has a 1 to 1 relationship with the Users
Products Entity that manages the adding of stocks and selling of stock
Customers Entity that manages the our customers
Transaction Entity that manages the payment of goods that has a 1 to many relationship with Customer entity and Users that has similar relationship
TransactionItems that contains the products purchased by the customer it has a relationship with the Products entity and Transaction entity.


# Development Environment

The tools I used for this Software are:
Visual Studio Community 2022
.Netframework
Github
Git
SQL Server

I used WinForms as my framework for developing the app and I also used C# programming language. I also ByCrypt .Net Core for the hashing of the passwords.

# Useful Websites



- [Microsoft](https://learn.microsoft.com/en-us/sql/sql-server/tutorials-for-sql-server-2016?view=sql-server-ver16)
- [SQL Server Tutorial](https://www.sqlservertutorial.net/)

# Future Work


- To add backend server with Asp.netcore to connect with the SQL Server database
- To use Entity framework so I can lavarage features like LINQ queries
- Improve my dashboard design for admin page
