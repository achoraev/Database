--TASK 1.What is SQL? What is DML? What is DDL? Recite the most important SQL commands.
Declarative language for query and manipulation of relational data.
Data Manipulation Language (DML)
SELECT, INSERT, UPDATE, DELETE
Data Definition Language (DDL)
CREATE, DROP, ALTER
GRANT, REVOKE

--TASK 2.What is Transact-SQL (T-SQL)?
T-SQL (Transact SQL) is an extension to the standard SQL language
T-SQL is the standard language used in MS SQL Server

--TASK 3.Start SQL Management Studio and connect to the database TelerikAcademy. Examine the major tables in the "TelerikAcademy" database.
DONE;

--TASK 4 Write a SQL query to find all information about all departments.(use "TelerikAcademy" database).
SELECT * FROM Departments

--TASK 5 Write a SQL query to find all department names.
SELECT name FROM Departments

--TASK 6 Write a SQL query to find the salary of each employee.
SELECT FirstName + ' ' + LastName as Name, Salary FROM Employees

--TASK 7 Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + MiddleName + ' ' + LastName as Name FROM Employees
WHERE MiddleName IS NOT NULL
UNION
SELECT FirstName + ' ' + LastName as Name FROM Employees
WHERE MiddleName IS NULL

--TASK 8 Write a SQL query to find the email addresses of each employee (by his first and last name). 
--Consider that the mail domain is telerik.com. Emails should look like �John.Doe@telerik.com". 
--The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' as [Full Email Addresses] FROM Employees

--TASK 9 Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary FROM Employees

--TASK 10 Write a SQL query to find all information about the employees whose job title is �Sales Representative�.
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

--TASK 11 Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName + ' ' + LastName AS Name FROM Employees
Where FirstName LIKE 'SA%'

--TASK 12 Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName + ' ' + LastName AS Name FROM Employees
WHERE LASTNAME LIKE '%ei%'

--TASK13 Write a SQL query to find the salary of all employees whose salary is in the range [20000�30000].
SELECT FirstName + ' ' + LastName AS Name, Salary FROM Employees
WHERE SALARY BETWEEN 20000 AND 30000

--TASK14 Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + LastName AS Name, Salary FROM Employees
WHERE SALARY IN (25000, 14000, 12500, 23600)

--TASK 15 Write a SQL query to find all employees that do not have manager.
SELECT FirstName + ' ' + LastName AS Name FROM Employees
WHERE ManagerID IS NULL

--TASK 16 Write a SQL query to find all employees that have salary more than 50000. 
--Order them in decreasing order by salary.
SELECT FirstName + ' ' + LastName AS Name, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--TASK 17 Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 FirstName + ' ' + LastName AS Name, Salary FROM Employees
ORDER BY Salary DESC

--TASK 18 Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT FirstName + ' ' + LastName AS Name, addr.AddressText AS Address FROM Employees emp
JOIN Addresses addr ON emp.AddressID = addr.AddressID

--TASK 19 Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT FirstName + ' ' + LastName AS Name, addr.AddressText AS Address 
	FROM Employees emp, Addresses addr
WHERE emp.AddressID = addr.AddressID

--TASK 20 Write a SQL query to find all employees along with their manager.
SELECT emp1.FirstName + ' ' + emp1.LastName AS Name, emp2.FirstName + ' ' + emp2.LastName AS Manager FROM Employees emp1
JOIN Employees emp2 ON emp1.ManagerID = emp2.EmployeeID

--TASK 21 Write a SQL query to find all employees, along with their manager and their address. 
--Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT emp1.FirstName + ' ' + emp1.LastName AS Name, emp2.FirstName + ' ' + emp2.LastName AS Manager, a.AddressText AS Address FROM Employees emp1
JOIN Employees emp2 ON emp1.ManagerID = emp2.EmployeeID
JOIN Addresses a ON emp1.AddressID = a.AddressID

--TASK 22 Write a SQL query to find all departments and all region names, country names and city names as a single list. Use UNION.
SELECT Name FROM Departments
UNION 
SELECT Name FROM Towns

--TASK 23 Write a SQL query to find all the employees and the manager for each of them along with the employees 
--that do not have manager. User right outer join. Rewrite the query to use left outer join.
--With Right join
SELECT emp.FirstName + ' ' + emp.LastName AS EmployeeName, m.FirstName + ' ' + m.LastName AS Manager FROM Employees m
RIGHT JOIN Employees emp ON emp.ManagerID = m.EmployeeID
--With Left join
SELECT emp.FirstName + ' ' + emp.LastName AS EmployeeName, m.FirstName + ' ' + m.LastName AS Manager FROM Employees emp
LEFT JOIN Employees m ON emp.ManagerID = m.EmployeeID

--TASK 24 Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" 
--whose hire year is between 1995 and 2005.
SELECT emp.FirstName + ' ' + emp.LastName AS EmployeeName, d.Name, emp.HireDate FROM Employees emp
JOIN Departments d ON emp.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance') AND (YEAR(emp.HireDate) > 1995 AND YEAR(emp.HireDate) < 2005)