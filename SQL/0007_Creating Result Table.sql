USE MyFirstFullStackApp_DEV;

IF  NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'Result'  AND type = 'U')
    BEGIN
        CREATE TABLE [Result]
		(
			Id INT PRIMARY KEY IDENTITY(1,1),
			CandidateId INT FOREIGN KEY REFERENCES Candidate(Id) NOT NULL,
			AnswerId INT FOREIGN KEY REFERENCES Answer(Id)
		) 
		PRINT 'Table Result is succesfully created'
    END;
ELSE 
	BEGIN
		PRINT 'Table Result already exists'
	END;