USE MyFirstFullStackApp_DEV
GO

IF (SELECT COUNT(1) FROM Candidate) = 0
BEGIN
	INSERT INTO Candidate VALUES ('Lionel', 'Messi', 1)
	INSERT INTO Candidate VALUES ('Cristiano', 'Ronaldo', 2)
	INSERT INTO Candidate VALUES ('Fabio', 'Cannavaro', 3)
	INSERT INTO Candidate VALUES ('Andriy', 'Chevtchenko', 4)
	INSERT INTO Candidate VALUES ('Pavel', 'Nedved', 2)
	INSERT INTO Candidate VALUES ('Michael', 'Owen', 3)
END
GO