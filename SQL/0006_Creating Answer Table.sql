USE MyFirstFullStackApp_DEV;

IF  NOT EXISTS (SELECT 1 FROM sys.tables WHERE NAME = N'Answer'  AND TYPE = 'U')
    BEGIN
        CREATE TABLE [Answer]
		(
			Id INT PRIMARY KEY IDENTITY(1,1),
			QuestionId INT FOREIGN KEY REFERENCES Question(Id) NOT NULL,
			Code VARCHAR(1) NOT NULL,
			Label VARCHAR(500) NOT NULL,
			IsGood bit NOT NULL
		) 
		PRINT 'Table Answer is succesfully created'
    END;
ELSE 
	BEGIN
		PRINT 'Table Answer already exists'

	END;