--ZAD 1
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
--•	RepositoriesContributors – a many to many mapping table between the repositories and the users.

	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id),
	-- ako ima tova many to many mapping table zna4i slagame primarykey(....,...,...,..)
	PRIMARY KEY(RepositoryId, ContributorId)

	-- ako nqma primary key tazi tablica trqbva da se napishe tova primary key(...) 
	-- i ako e mapping table
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	Message VARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT NOT NULL REFERENCES Repositories(Id),
	ContributorId INT NOT NULL REFERENCES Users(Id)
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL (15,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT NOT NULL REFERENCES Commits(Id),	 
)

--ZAD 2

INSERT INTO Files (Name, Size, ParentId, CommitId) VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy',	1246.93, 3, 3),
('Controller.php', 7353.15,	4, 4),
('Find.java', 9957.86, 5,	5),
('Controller.json',	14034.87, 3, 6),
('Operate.xix',	7662.92, 7,	7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open',	1, 4),
('Typo fix in Judge.html',	'open',	4,	3),
('Implement documentation for UsersService.cs',	'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9,	8)

--ZAD 3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--ZAD 4
DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3
-- kato triq da obrashtam vnimanie na where kym kyde so4i 
--tuk bqh ubarkal kym ID a ne kym repoId na issues
DELETE FROM Issues
WHERE RepositoryId = 3
-- ako iskame da triem purvi triem tezi kym koito nqma klu4 koito referira kym tqh i ako ima takav
-- triem ot tazi koqto referira purvo

--ZAD 5
SELECT Id, Message, RepositoryId, ContributorId
FROM Commits
ORDER BY Id ASC, Message ASC, RepositoryId ASC

--ZAD 6

SELECT Id, Name, Size 
FROM Files
WHERE Name LIKE '%html%' AND SIZE > 1000
ORDER BY Size DESC, Id ASC, Name ASC

--ZAD 7

SELECT i.Id, u.Username+' '+':'+' '+i.Title AS IssueAssignee
FROM Issues i
JOIN Users u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee ASC

--ZAD 8
SELECT f1.Id, f1.[Name], CONCAT(f1.Size, 'KB') AS Size FROM Files AS f1
LEFT JOIN Files AS f2 ON f1.Id = f2.ParentId
WHERE f2.ParentId IS NULL
ORDER BY f1.Id, f1.[Name], f1.Size DESC

--drugo reshenie
SELECT fParent.Id, fParent.Name, CONCAT(fParent.Size, 'KB') 
FROM Files AS fChild
FULL OUTER JOIN Files AS fParent
ON fChild.ParentId = fParent.Id
WHERE fChild.Id IS NULL
ORDER BY fParent.Id,fParent.Name, fParent.Size

--ZAD 9

SELECT TOP(5) r.Id,r.Name, COUNT(*) as Commits
FROM Repositories r
JOIN Commits c ON r.Id = c.RepositoryId
JOIN RepositoriesContributors rc ON r.Id=rc.RepositoryId
WHERE c.RepositoryId = r.Id
GROUP BY r.Id,r.Name
ORDER BY Commits DESC, r.Id,r.Name

 --ZAD 10

 SELECT u.Username, AVG(f.Size)
 FROM Commits c
 JOIN Users u ON c.ContributorId = u.Id
 JOIN RepositoriesContributors rc ON u.Id=rc.ContributorId
 JOIN Files f ON c.Id = f.CommitId
 GROUP BY u.Username
 ORDER BY AVG(f.Size) DESC, u.Username

--ZAD 11
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
RETURNS INT
AS
BEGIN
 RETURN (SELECT COUNT(c.Id) FROM Commits AS c
JOIN Users AS u ON u.Id = c.ContributorId
WHERE u.Username = @username)

END
-- AMA BEZ GO za judge
GO
-- DRUGO RESHENIE
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
RETURNS INT
AS
BEGIN
 DECLARE @userId INT = (SELECT Id 
							FROM Users
							WHERE Username = @username
					   )
DECLARE @commitsCount INT = (SELECT COUNT(Id)
								FROM Commits
								WHERE ContributorId = @userId
							)
END
-- AMA BEZ GO za judge
GO
--ZAD 12
GO -- za da ne garmi s BATCH trqbva GO predi i sled usp
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(max))
AS
BEGIN
	SELECT Id,Name,CONCAT(Size, 'KB') AS Size
	FROM Files
	--WHERE Name LIKE '%'+ @fileExtension + '%'  moje i po dvata nachina s concat e po qko
	WHERE Name LIKE CONCAT('%',@fileExtension)
	ORDER BY Id ASC,Name ASC,Size DESC
END
GO

EXEC usp_SearchForFiles 'txt'
 
 

