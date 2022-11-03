--ZADACHA 1
CREATE TABLE Cities
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL, -- kato pishe v uslovieto UNICODE znachi e NVARCHAR ASCII e VARCHAR
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL (18,2)
)
CREATE TABLE Rooms
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Price DECIMAL (18,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL REFERENCES Hotels(Id)
)
CREATE TABLE Trips
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL REFERENCES Rooms(Id),
	ReturnDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	BookDate DATE NOT NULL,
	CancelDate DATE,
	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate)
)
CREATE TABLE Accounts
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)
CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	TripId INT NOT NULL REFERENCES Trips(Id),
	Luggage INT NOT NULL,
	PRIMARY KEY(AccountId, TripId),
	CHECK(Luggage >=0)
)

--ZADACHA 2
INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email) VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov',	59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate) VALUES
(101, '2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102, '2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103, '2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104, '2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109, '2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--ZADACHA 3
UPDATE Rooms SET Price*=1.14
 WHERE HotelId IN(5,7,9)

 --ZADACHA 4
 DELETE  FROM AccountsTrips WHERE AccountId = 47

 --ZADACHA 5
 SELECT 
	FirstName,
	LastName,
	FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate,
	Name AS Hometown,
	Email
FROM Accounts a
JOIN Cities c ON a.CityId = c.Id
WHERE [Email] LIKE 'e%'
ORDER BY c.Name ASC

--ZADACHA 6
SELECT c.Name AS City, COUNT(*) AS Hotels
FROM Hotels h
JOIN Cities c ON h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name ASC

--ZADACHA 7
SELECT a.id AS AccountId,
	FirstName + ' ' + LastName,
	MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
	MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
FROM AccountsTrips at
JOIN Accounts a ON at.AccountId = a.Id
JOIN Trips t ON at.TripId = t.Id
WHERE MiddleName IS NULL AND CancelDate IS NULL
GROUP BY a.Id, FirstName, LastName
ORDER BY LongestTrip DESC, ShortestTrip ASC

--ZADACHA 8
SELECT TOP(10)c.Id, c.Name, c.CountryCode, COUNT(*) AS Accounts
FROM Accounts a
JOIN Cities c ON a.CityId=c.Id
GROUP BY c.Id, c.Name, c.CountryCode, c.CountryCode
ORDER BY Accounts DESC

--ZADACHA 9
SELECT AccountId AS Id, Email, ac.Name AS City, COUNT(*) AS Trips
FROM AccountsTrips at
JOIN Accounts a ON at.AccountId = a.Id
JOIN Cities ac ON a.CityId = ac.Id
JOIN Trips t ON at.TripId = t.Id
JOIN Rooms r ON t.RoomId = r.Id
JOIN Hotels h ON r.HotelId = h.Id
JOIN Cities hc ON h.CityId = hc.Id
WHERE hc.id = ac.Id
GROUP BY AccountId, Email, ac.Name
ORDER BY Trips DESC, AccountId ASC

--ZADACHA 10
SELECT 
TripId,
FirstName + ' ' + ISNULL(MiddleName + ' ','')+ LastName AS [Full Name],
ac.Name AS [From],
ht.Name AS [To],
CASE
	WHEN CancelDate IS NULL THEN CONVERT(NVARCHAR(50),DATEDIFF(DAY, ArrivalDate, ReturnDate))+' days'
	ELSE 'Canceled' END AS Duration
FROM AccountsTrips at
JOIN Accounts a ON at.AccountId = a.Id
JOIN Cities ac ON a.CityId = ac.Id
JOIN Trips t ON at.TripId = t.Id
JOIN Rooms r ON t.RoomId = r.Id
JOIN Hotels h ON r.HotelId = h.Id
JOIN Cities ht ON h.CityId = ht.Id
ORDER BY [Full Name],TripId ASC

--ZADACHA 11
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN
	DECLARE @RoomInfo VARCHAR(MAX) = (SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.Id) 
	+ ': ' + r.Type 
	+ ' ('+ CONVERT(VARCHAR, r.Beds) + ' beds) - $'+ CONVERT(VARCHAR, (BaseRate + Price) * @People)
	FROM Rooms r
	JOIN Hotels h ON r.HotelId = h.Id
	WHERE Beds >= @People AND HotelId = @HotelId AND 
		NOT EXISTS (SELECT * FROM Trips t WHERE t.RoomId = r.Id
					AND CancelDate IS NULL
					AND @Date BETWEEN ArrivalDate and ReturnDate)
	ORDER BY (BaseRate + Price) * @People  DESC)

	IF @RoomInfo IS NULL
		RETURN 'No rooms available';
	RETURN @RoomInfo
END
GO -- ZA JUDGE TOVA TRQBVA DA SE MAHNE! syshto taka ako ima CREATE OR ALTER samo create da ostane
-- i da vnimavam kak pisha imeto na funkciqta zashtoto 
--ako imas pravopisna gresha dava COMPILE TIME ERROR
SELECT  dbo.udf_GetAvailableRoom(112,'2011-12-17',2)

--ZADACHA 12
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
	AS
		DECLARE @TripHotelId INT  = (SELECT r.HotelId FROM Trips t 
									JOIN Rooms r ON t.RoomId = r.Id 
									WHERE t.Id = @TripId);
		DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId);
		IF (@TripHotelId != @TargetRoomHotelId)
			THROW 50001, 'Target room is in another hotel!',1

		DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId);
		DECLARE @TargetRoomBads INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId);
		IF(@TripAccounts > @TargetRoomBads)
			THROW 50002, 'Not enough beds in target room!',1

		UPDATE Trips SET RoomId = @TargetRoomId WHERE Id = @TripId;
GO