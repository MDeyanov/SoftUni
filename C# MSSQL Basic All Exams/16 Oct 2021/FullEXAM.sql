--ZAD 1
CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL CHECK([Length] BETWEEN 10 AND 25),
	RingRange DECIMAL (15,2) NOT NULL CHECK(RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT NOT NULL REFERENCES Brands(Id),
	TastId INT NOT NULL REFERENCES Tastes(Id),
	SizeId INT NOT NULL REFERENCES Sizes(Id),
	PriceForSingleCigar DECIMAL (15,2) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
 
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL,

)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	AddressId INT NOT NULL REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars
(
	ClientId INT NOT NULL REFERENCES Clients(Id),
	CigarId INT NOT NULL REFERENCES Cigars(Id),
	PRIMARY KEY( ClientId,CigarId)
)

--ZAD 2
INSERT INTO Cigars(CigarName,BrandId,TastId,SizeId,PriceForSingleCigar,ImageURL) VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,Country,Streat,ZIP) VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)

--ZAD 3
UPDATE Cigars
SET PriceForSingleCigar *= 1.20
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--ZAD 4
--In table Addresses, delete every country which name starts 
--with 'C', keep in mind that could be foreign key constraint conflicts.

DELETE FROM Clients
WHERE AddressId IN (7,8,10,23)

DELETE FROM Addresses
WHERE Country LIKE 'C%'

--ZAD 5

SELECT CigarName,PriceForSingleCigar,ImageURL 
FROM Cigars
ORDER BY PriceForSingleCigar ASC,CigarName DESC

--ZAD 6

SELECT c.Id, CigarName, PriceForSingleCigar, TasteType, TasteStrength
FROM Cigars c
JOIN Tastes t ON c.TastId = t.Id
WHERE TasteType IN ('Earthy','Woody')
ORDER BY PriceForSingleCigar DESC

--ZAD 7
-- kak da proverim kogato client nqma cigara vzimam klientite i where go pravq s not In i select
SELECT Id, CONCAT(FirstName, ' ', LastName)ClientName, Email
FROM Clients
WHERE Id NOT IN(SELECT ClientId FROM ClientsCigars)
ORDER BY ClientName

--ZAD 8
SELECT TOP(5) CigarName, PriceForSingleCigar ,ImageURL 
FROM Cigars c
JOIN Sizes s ON c.SizeId = s.Id
WHERE  s.Length >= 12
	   AND (c.CigarName 
	   LIKE '%ci%' 
	   OR c.PriceForSingleCigar > 50) 
	   AND s.RingRange > 2.55
ORDER BY CigarName ASC, PriceForSingleCigar DESC
 
 --ZAD 9
SELECT CONCAT(c.FirstName,' ',c.LastName) AS FullName, 
	Country, 
	ZIP, 
	CONCAT('$', MAX(ci.PriceForSingleCigar))
FROM ClientsCigars cc
JOIN Clients c ON c.Id = cc.ClientId
JOIN Addresses a ON c.AddressId = a.Id
JOIN Cigars ci ON ci.Id = cc.CigarId
WHERE ISNUMERIC(ZIP) = 1
GROUP BY FirstName, LastName, a.Country, a.ZIP
ORDER BY FullName

--ZAD 10	

SELECT c.LastName, AVG(s.Length) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM ClientsCigars cc
JOIN Clients c ON cc.ClientId = c.Id
JOIN Cigars ci ON cc.CigarId = ci.Id
JOIN Sizes s ON ci.SizeId = s.Id
WHERE c.Id IN (SELECT cc.ClientId FROM ClientsCigars)
GROUP BY c.LastName -- DA OBRASHTAM VNIMANIE AKO IMAM POVECHE REZULTATI ILI PO MALKO DA GLEDAM GROUP BY-a
ORDER BY CiagrLength DESC

--ZAD 11

--DRUGO RESHENIE

--CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(MAX))
--RETURNS INT
--AS
--BEGIN
--	DECLARE @clientId INT = (SELECT Id 
--								FROM Clients 
--								WHERE FirstName = @name
--						)
--DECLARE @result INT = (SELECT COUNT(*) 
--						FROM ClientsCigars
--						WHERE ClientId = @clientId
--					  )
--	 RETURN @result
--END
GO
CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(MAX))
RETURNS INT
AS
BEGIN

DECLARE @result INT = (SELECT COUNT(*) 
						FROM ClientsCigars cc
						JOIN Clients c ON cc.ClientId = c.Id
						WHERE c.FirstName = @name
					  )
	 RETURN @result
END
GO
SELECT dbo.udf_ClientWithCigars('Jean')

--ZAD 12
GO
CREATE PROC usp_SearchByTaste(@taste VARCHAR(max))
AS
BEGIN

	SELECT c.CigarName, 
		CONCAT('$',c.PriceForSingleCigar) AS Price, 
		t.TasteType, 
		b.BrandName, 
		CONCAT(s.Length, ' cm') AS CigarLength, 
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Cigars c
			JOIN Sizes s ON c.SizeId = s.Id
			JOIN Tastes t ON c.TastId = t.Id
			JOIN Brands b ON c.BrandId = b.Id
			WHERE t.TasteType LIKE @taste
			ORDER BY s.Length ASC, s.RingRange DESC
			
END
GO

EXEC usp_SearchByTaste 'Woody'
