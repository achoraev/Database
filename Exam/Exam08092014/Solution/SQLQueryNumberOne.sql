USE Company
GO

SELECT FirstName, LastName, YearSalary FROM Employee
WHERE YearSalary > 100000 AND YearSalary < 150000
ORDER BY YearSalary DESC
GO