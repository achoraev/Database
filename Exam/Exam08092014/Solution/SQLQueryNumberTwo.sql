USE Company
GO

SELECT Department.Name AS [Name]
FROM Department
INNER JOIN Employee AS e
ON e.DepartmentId = Department.DepartmentId
GO