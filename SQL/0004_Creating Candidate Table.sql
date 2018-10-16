USE MyFirstFullStackApp_DEV;

IF  NOT EXISTS (SELECT 1 FROM sys.tables WHERE NAME = N'Candidate'  AND TYPE = 'U')
    BEGIN
        CREATE TABLE [Candidate]
		(
			Id INT PRIMARY KEY IDENTITY(1, 1),
			FirstName VARCHAR(50) NOT NULL,
			LastName VARCHAR(50) NOT NULL,
			TestId INT FOREIGN KEY REFERENCES Test(Id) NOT NULL
		) 
		PRINT 'Table Candidate is succesfully created'
    END;
ELSE 
	BEGIN
		PRINT 'Table Candidate already exists'
	END;