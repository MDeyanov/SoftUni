--ZAD 1
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	Name VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(AGE BETWEEN 14 and 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(AGE BETWEEN 18 and 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL REFERENCES Departments(Id)
)

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL REFERENCES Categories(Id),
	StatusId INT NOT NULL REFERENCES Status(Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description VARCHAR(200) NOT NULL,
	UserId INT NOT NULL REFERENCES Users(Id),
	EmployeeId INT REFERENCES Employees(Id)
)

--ZAD 2
INSERT INTO Employees(FirstName,LastName,Birthdate, DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21',	1),
('Niki', 'Stanaghan', '1969-11-26',	4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20',	5)

INSERT INTO Reports(CategoryId,StatusId, OpenDate, CloseDate,Description,UserId, EmployeeId) VALUES
(1,	1,	'2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6,	3,	'2015-09-05', '2015-12-06', 'Charity trail running', 3,	5),
(14, 2,	'2015-09-07', NULL, 'Falling bricks on Str.58',	5, 2),
(4,	3,	'2017-07-03', '2017-07-06',	'Cut off streetlight on Str.11', 1, 1)

--ZAD 3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--ZAD 4
DELETE From Reports  
WHERE StatusId = 4
 
--ZAD 5

SELECT Description,FORMAT(OpenDate,'dd-MM-yyyy') AS OpenDate 
FROM Reports r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate ASC, r.Description ASC

--ZAD 6
SELECT r.Description, c.Name
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
ORDER BY r.Description,c.Name

--ZAD 7
SELECT TOP(5) c.Name AS CategoryName,COUNT(*) AS ReportsNumber
FROM Categories c
JOIN Reports r ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC,CategoryName

--ZAD 8

SELECT u.Username, c.Name
FROM Reports r
JOIN Users u ON r.UserId = u.Id
JOIN Categories c ON r.CategoryId = c.Id
WHERE MONTH(r.OpenDate) LIKE MONTH(u.Birthdate)AND  DAY(r.OpenDate) LIKE DAY(u.Birthdate)
ORDER BY u.Username, c.Name

--ZAD 9

SELECT CONCAT(e.FirstName,' ',e.LastName) AS FullName, COUNT(u.Id) AS UserCount
FROM Employees  e
LEFT JOIN Reports r ON r.EmployeeId = e.Id
LEFT JOIN Users u ON r.UserId = u.Id
GROUP BY e.FirstName,e.LastName
ORDER BY UserCount DESC,FullName

-- drugo reshenie s right join
 SELECT CONCAT(e.FirstName,' ',e.LastName) AS FullName, COUNT(u.Id) AS UserCount
FROM Users  u
RIGHT JOIN Reports r ON r.UserId  = u.Id
RIGHT JOIN Employees e ON r.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY UserCount DESC,FullName

--ZAD 10

SELECT
CASE
             WHEN r.EmployeeId IS NULL THEN 'None'
			 ELSE CONCAT(e.FirstName, ' ', e.LastName) 
		  END [Employee],
		  ISNULL(d.[Name], 'None')[Department],
		  ISNULL(c.[Name], 'None')[Category],
		  ISNULL(r.[Description], 'None')[Description],
		  ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None')[OpenDate],
		  ISNULL(s.[Label], 'None')[Status],
		  ISNULL(u.[Name],'None')[User]
FROM Reports r
LEFT JOIN Users u ON r.UserId = u.Id
LEFT JOIN Employees e ON r.EmployeeId = e.Id
LEFT JOIN Status s ON r.StatusId = s.Id
LEFT JOIN Categories c ON r.CategoryId = c.Id
LEFT JOIN Departments d ON e.DepartmentId = d.Id
ORDER BY 
e.FirstName DESC,
e.LastName DESC,
d.Name ASC,
c.Name ASC,
r.Description ASC,
r.OpenDate ASC,
s.Label ASC,
u.Name ASC

--ZAD 11
GO
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL)
		RETURN 0

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END
GO

--ZAD 12
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN

DECLARE @resultEmployee VARCHAR(MAX) = (SELECT d.Name 
											FROM Employees e
											JOIN Departments d ON e.DepartmentId = d.Id
											WHERE e.Id = @EmployeeId
										)
	
DECLARE @resultReport VARCHAR(MAX) = (SELECT d.Name
										FROM Reports r
										JOIN Categories c ON r.CategoryId = c.Id
										JOIN Departments d ON c.DepartmentId = d.Id
										WHERE r.Id = @ReportId
									 )
IF(@resultEmployee != @resultReport)
THROW 50001, 'Employee doesn''t belong to the appropriate department!' ,1
 
UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId
END

EXEC usp_AssignEmployeeToReport 17, 2
 
 




