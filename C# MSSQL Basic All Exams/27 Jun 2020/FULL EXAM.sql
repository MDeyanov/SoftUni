--ZAD 1 da cheta vnimatelno ako ima tova zna4i vsi4ki trqbva da sa NOT NULL
--Include the following fields in each table. Unless otherwise specified, all fields are required.
CREATE TABLE Clients
(
	ClientId INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL, -- kato pishe v uslovieto ASCII znachie VARCHAR
	LastName VARCHAR(50) NOT NULL, -- ako pishe UNICODE e NVARCHAR
	Phone CHAR(12) CHECK(LEN(Phone)=12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs
(
	JobId INT NOT NULL PRIMARY KEY IDENTITY,
	ModelId INT NOT NULL REFERENCES Models(ModelId),
	[Status] VARCHAR(11) NOT NULL DEFAULT'Pending' 
	CHECK(Status IN ('Pending', 'In Progress', 'Finished')),
	ClientId INT NOT NULL REFERENCES Clients(ClientId),
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT NOT NULL PRIMARY KEY IDENTITY,
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL

)

CREATE TABLE Vendors
(
	VendorId INT NOT NULL PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
	PartId INT NOT NULL PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	Description VARCHAR(255),
	Price DECIMAL (6,2)  CHECK(Price > 0 AND Price <= 9999.99) NOT NULL,
	VendorId INT NOT NULL REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL CHECK(StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL REFERENCES Orders(OrderId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity >0)
	--Relationship with table Parts;
    --Primary table identificator
	-- ako go ima tova na primerno (Parts i orders kakto e tuka) slagame tova CONSTRAINT ot dolu

	CONSTRAINT PK_OrdersParts PRIMARY KEY(OrderId,PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL REFERENCES Jobs(JobId),
	PartId INT NOT NULL REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity >0)

	CONSTRAINT PK_JobsParts PRIMARY KEY (JobId,PartId)
)


--ZAD 2 INSERT

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber,Description,Price,VendorId) VALUES
('WP8182119', 'Door Boot Seal',	117.86,	2),
('W10780048', 'Suspension Rod',	42.81, 1),
('W10841140', 'Silicone Adhesive', 	6.77, 4),
('WPY055980', 'High Temperature Adhesive',	13.94, 3)

--ZAD 3 update
 UPDATE Jobs
 SET MechanicId = 3, Status = 'In Progress'
 WHERE Status = 'Pending'

 --ZAD 4 DELETE
 DELETE  FROM OrderParts WHERE OrderId = 19
 DELETE  FROM Orders WHERE OrderId = 19
 -- pyrvo trqbva da iztriem ot vsi4ki drugi tablici kydeto e obvyrzan kato tuk to pishe da iztriem
 -- order no pyrvo trqbva a iztriem vsi4ki svyrzani demek tiq ot OrderParts pyrvo za da se iztrie ordera
 
 --ZAD 5 
 SELECT FirstName+' '+LastName,Status,IssueDate 
 FROM Jobs j
 JOIN Mechanics m ON j.MechanicId = m.MechanicId
 ORDER BY m.MechanicId ASC, j.IssueDate ASC, j.JobId ASC

 --ZAD 6
 DECLARE @CurrDate DATE = '2017-04-24'
 SELECT FirstName+' '+LastName, DATEDIFF(DAY, j.IssueDate, @CurrDate) AS [Days going], Status
 FROM Jobs j
 JOIN Clients c ON j.ClientId = c.ClientId
 WHERE Status != 'Finished'
 ORDER BY [Days going] DESC, j.ClientId ASC
 
  --ZAD 7
  SELECT m.FirstName +' '+ m.LastName AS Mechanic,
  AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) AS [Average Days]
  FROM Jobs j
  JOIN Mechanics m ON j.MechanicId = m.MechanicId
  WHERE j.FinishDate IS NOT NULL
  GROUP BY m.MechanicId, m.FirstName,m.LastName
  ORDER BY m.MechanicId ASC

  --ZAD 8
SELECT m.FirstName + ' ' + m.LastName
	FROM Mechanics m
LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
							FROM Jobs
							WHERE Status <> 'Finished' AND 
							MechanicId = m.MechanicId
							GROUP BY MechanicId, Status) IS NULL
GROUP BY m.MechanicId,(m.FirstName + ' ' + m.LastName)
-- drugo reshenie
SELECT FirstName + ' '+ LastName AS Avaiable
	FROM Mechanics m
LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
	WHERE j.JobId IS NULL
		  OR 'Finished' = ALL(SELECT j.[Status]
							  FROM Jobs j
							  WHERE j.MechanicId = m.MechanicId)
	GROUP BY FirstName,LastName,m.MechanicId
	ORDER BY m.MechanicId

-- ZAD 9

SELECT j.JobId, ISNULL(SUM(op.Quantity * p.Price), 0) AS Total FROM Orders AS o
JOIN OrderParts AS op ON op.OrderId = o.OrderId
JOIN Parts AS p ON p.PartId = op.PartId
FULL JOIN Jobs AS j ON o.JobId = j.JobId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--ZAD 10

 SELECT p.PartId,
		p.Description,
		pn.Quantity AS [Required],
		p.StockQty AS [InStock],
		IIF(o.Delivered = 0, op.Quantity,0) AS Ordered
	FROM Parts AS p
LEFT JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
 WHERE j.Status != 'Finished' AND p.StockQty + IIF(o.Delivered = 0,
  op.Quantity, 0) < pn.Quantity
 ORDER BY PartId

 --dr reshenie
  SELECT p.PartId,
       p.Description,
	   SUM(pn.Quantity) AS [Required],
	   SUM(p.StockQty) AS[In Stock],
	   ISNULL(SUM(op.Quantity), 0) AS Ordered
FROM Parts AS p
INNER JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
INNER JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE j.Status <> 'Finished'
GROUP BY p.PartId, p.Description
HAVING SUM(pn.Quantity) > SUM(p.StockQty) + ISNULL(SUM(op.Quantity), 0)
ORDER BY p.PartId

-- ZAD 11

 CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @partSN VARCHAR(50), @quantity INT) AS

IF @quantity <= 0
	THROW 50012, 'Part quantity must be more than zero!', 1

ELSE IF
(SELECT COUNT(*)
FROM Jobs
WHERE JobId = @jobId) <> 1
	THROW 50013, 'Job not found!', 1

ELSE IF
(SELECT Status
FROM Jobs
WHERE JobId = @jobId) = 'Finished'
	THROW 50011, 'This job is not active!', 1

ELSE IF
(SELECT COUNT(*)
FROM Parts
WHERE SerialNumber = @partSN) <> 1
	THROW 50014, 'Part not found!', 1

ELSE
BEGIN
	IF  (SELECT COUNT(*)
		FROM Orders
		WHERE JobId = @jobId AND IssueDate IS NULL) <> 1

	BEGIN
		INSERT INTO Orders (JobId, IssueDate) VALUES
		(@jobId, NULL)
	END

	DECLARE @orderId INT =
		(SELECT OrderId
		FROM Orders
		WHERE JobId = @jobId AND IssueDate IS NULL)

	DECLARE @partId INT =
		(SELECT PartId
		FROM Parts
		WHERE SerialNumber = @partSN)

	IF  (SELECT COUNT(*)
		FROM OrderParts
		WHERE OrderId = @orderId AND PartId = @partId) <> 1

		BEGIN
		INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
		(@orderId, @partId, @quantity)
		END

	ELSE BEGIN
		 UPDATE OrderParts
		 SET Quantity += @quantity
		 WHERE OrderId = @orderId AND PartId = @partId 
		 END
END

 --ZAD 12
  
CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS Decimal(15,2)
BEGIN
DECLARE @result DECIMAL (15,2)
SET @result =(SELECT SUM(p.Price * op.Quantity) AS totalSum
FROM Jobs j
JOIN Orders o ON o.JobId = j.JobId
JOIN OrderParts op ON op.OrderId = o.OrderId
JOIN Parts p ON p.PartId = op.PartId
WHERE j.JobId = @jobId
GROUP BY j.JobId)
IF(@result IS NULL)
SET @result =0;

RETURN @result	
END
GO
   





