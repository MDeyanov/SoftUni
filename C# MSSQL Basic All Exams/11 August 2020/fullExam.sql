--ZAD 1
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK(GENDER = 'M' OR GENDER = 'F'),
	Age INT,
	PhoneNumber VARCHAR(10) CHECK(LEN(PhoneNumber) = 10),
	CountryId INT REFERENCES Countries(Id)

)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	Description NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price DECIMAL (15,2) CHECK(Price >=0)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(250),
	Rate DECIMAL (15,2) CHECK(Rate BETWEEN 0 AND 10),
	ProductId INT REFERENCES Products(Id),
	CustomerId INT REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT REFERENCES Countries(Id)
)

CREATE  TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30),
	Description NVARCHAR(200),
	OriginCountryId INT REFERENCES Countries(Id),
	DistributorId INT REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT REFERENCES Products(Id),
	IngredientId INT REFERENCES Ingredients(Id)

	PRIMARY KEY(ProductId, IngredientId)
)

--ZAD 2

INSERT INTO Distributors (Name,CountryId,AddressText,Summary) VALUES
('Deloitte & Touche',	2,	'6 Arch St #9757',	'Customizable neutral traveling'),
('Congress Title',	13,	'58 Hancock St', 'Customer loyalty'),
('Kitchen People',	1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName,Age,Gender,PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399',	5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom',	'Loeza', 31, 'M', '0144876096', 23),
('Queenie',	'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu',	'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43,	'F', '0197887645', 17)

--ZAD 3
UPDATE Ingredients
SET DistributorId = 35
WHERE Name = 'Bay Leaf' or Name = 'Paprika' or Name = 'Poppy'

UPDATE Ingredients 
SET OriginCountryId = 14
WHERE OriginCountryId =8

--ZAD 4
DELETE 
FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--ZAD 5
SELECT Name,Price,Description 
FROM Products
ORDER BY Price DESC, Name ASC

--ZAD 6
SELECT f.ProductId,f.Rate,f.Description,f.CustomerId,c.Age,c.Gender 
FROM Feedbacks f
JOIN Customers c ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY ProductId DESC,Rate ASC

--ZAD 7
SELECT CONCAT(c.FirstName, ' ',c.LastName), c.PhoneNumber, c.Gender 
FROM Customers c
LEFT JOIN Feedbacks f ON c.Id = f.CustomerId
WHERE f.CustomerId IS NULL
ORDER BY c.Id ASC

--ZAD 8
SELECT cm.FirstName,cm.Age,cm.PhoneNumber 
FROM Customers cm
JOIN Countries ct ON cm.CountryId = ct.Id
WHERE 
ct.Name != 'Greece'
AND cm.Age >= 21 
AND (cm.FirstName LIKE '%an%' 
or RIGHT(cm.PhoneNumber,2) LIKE 38)
ORDER BY cm.FirstName ASC, cm.Age DESC

--ZAD 9

SELECT d.Name,i.Name,p.Name,AVG(f.Rate)
FROM ProductsIngredients pn
JOIN Ingredients i ON pn.IngredientId = i.Id
JOIN Distributors d on i.DistributorId = d.Id
JOIN Products p ON pn.ProductId = p.Id
JOIN Feedbacks f ON p.Id = f.ProductId
GROUP BY d.Name,i.Name,p.Name
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name,i.Name,p.Name

--ZAD 10
SELECT
k.CountryName,
k.DistributorName
FROM(
SELECT
c.[Name] AS CountryName,
d.[Name] AS DistributorName,
COUNT(i.Id) AS [Counter],
DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS [Rank]
FROM Distributors d
LEFT JOIN Ingredients i ON i.DistributorId = d.Id
JOIN Countries c ON c.Id = d.CountryId
GROUP BY c.[Name], d.[Name]
) AS k
WHERE k.[Rank] = 1
ORDER BY k.CountryName, k.DistributorName
 
