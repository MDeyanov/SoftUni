--ZAD 1 MNOGO DA VNIMAVAM!!!!!!!!!!!! S NULL I NOT NULL dali e razresheno ili ne!
CREATE TABLE Passengers 
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(AGE BETWEEN 21 AND 62),
	Rating FLOAT  CHECK(Rating BETWEEN 0.0 AND 10.0) 
)

CREATE TABLE AircraftTypes 
(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL,
)

CREATE TABLE Aircraft 
(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	Year INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeId INT NOT NULL REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft 
(
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PilotId INT NOT NULL REFERENCES Pilots(Id)
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports 
(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations 
(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL REFERENCES Airports(Id),
	Start DATETIME NOT NULL,
	AircraftId INT NOT NULL REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	TicketPrice DECIMAL (18,2) NOT NULL DEFAULT 15  
)

--ZAD 2 
INSERT INTO Passengers
SELECT CONCAT(FirstName, ' ', LastName) AS FullName,
CONCAT(FirstName,LastName,'@gmail.com') AS Email
FROM Pilots
WHERE Id BETWEEN 5 and 15

--ZAD 3
UPDATE Aircraft
SET Condition = 'A'
WHERE 
Condition IN ('C','B')
	AND (FlightHours IS NULL OR FlightHours <= 100)
	AND [Year] >= 2013
	
--ZAD 4
DELETE FROM Passengers
WHERE LEN(FullName) <=10
 
--ZAD 5
SELECT Manufacturer,Model,FlightHours,Condition
FROM Aircraft
ORDER BY FlightHours DESC
 
--ZAD 6
SELECT  FirstName,LastName,Manufacturer,Model,FlightHours 
FROM PilotsAircraft pa
JOIN Pilots p ON pa.PilotId = p.Id
JOIN Aircraft a ON pa.AircraftId = a.Id
WHERE a.FlightHours IS NOT NULL AND FlightHours <=304
ORDER BY FlightHours DESC, FirstName ASC

--ZAD 7
SELECT TOP(20) f.Id AS DestinationId, f.Start, p.FullName,a.AirportName,f.TicketPrice
FROM FlightDestinations f
JOIN Airports a ON f.AirportId = a.Id
JOIN Passengers p ON f.PassengerId = p.Id
WHERE DAY(f.Start)%2=0
ORDER BY f.TicketPrice DESC, a.AirportName ASC

--ZAD 8
SELECT 
	a.Id AS AircraftId, 
	a.Manufacturer,
	a.FlightHours,
	COUNT(*) AS FlightDestinationsCount,
	ROUND(AVG(TicketPrice),2)
FROM Aircraft a
JOIN FlightDestinations fd ON a.Id = fd.AircraftId
GROUP BY a.Id, a.Manufacturer,a.FlightHours
HAVING COUNT(*) >= 2
ORDER BY FlightDestinationsCount DESC, a.Id ASC

--ZAD 9
SELECT p.FullName,COUNT(*),SUM(fd.TicketPrice)
FROM FlightDestinations fd
JOIN Aircraft a ON a.Id = fd.AircraftId
JOIN Passengers p ON fd.PassengerId = p.Id
WHERE p.FullName LIKE '_a%'
GROUP BY p.FullName
HAVING COUNT(*) >= 2
ORDER BY p.FullName

--ZAD 10
SELECT 
	  ap.AirportName, 
	  fd.Start AS DayTime,
	  fd.TicketPrice,
	  p.FullName,
	  a.Manufacturer,
	  a.Model 
FROM FlightDestinations fd
JOIN Airports ap ON fd.AirportId = ap.Id
JOIN Aircraft a ON fd.AircraftId = a.Id
JOIN Passengers p ON fd.PassengerId = p.Id
WHERE (DATEPART(HOUR,fd.Start) BETWEEN 06 AND 20) AND fd.TicketPrice >= 2500
ORDER BY a.Model ASC

--ZAD 11
GO
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(MAX))
RETURNS INT
AS
BEGIN
	DECLARE @passengerId INT = (SELECT Id FROM Passengers
									WHERE Email = @email)
								

	DECLARE @result INT =	(SELECT COUNT(*) 
								FROM FlightDestinations
								WHERE PassengerId = @passengerId)
	RETURN @result
END
GO
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')

--ZAD 12
GO
CREATE PROC usp_SearchByAirportName(@airportName NVARCHAR(70))
AS
BEGIN
SELECT 
	ap.AirportName, 
	p.FullName, 
	(CASE 
			WHEN fd.TicketPrice <= 400 THEN 'Low'
			WHEN fd.TicketPrice <= 1500 THEN 'Medium'
			ELSE 'High'
		END) LevelOfTicketPrice,
	ac.Manufacturer, 
	ac.Condition,
	a.TypeName
FROM FlightDestinations fd
JOIN Airports ap ON fd.AirportId = ap.Id
JOIN Aircraft ac ON fd.AircraftId = ac.Id
JOIN Passengers p ON fd.PassengerId = p.Id
JOIN AircraftTypes a ON ac.TypeId = a.Id
WHERE AirportName = @airportName
ORDER BY ac.Manufacturer,p.FullName
END
GO
 
 