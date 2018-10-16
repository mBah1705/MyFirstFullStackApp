USE MyFirstFullStackApp_DEV;

IF  NOT EXISTS (SELECT 1 FROM sys.tables WHERE NAME = N'TestQuestion'  AND TYPE = 'U')
    BEGIN
        CREATE TABLE [TestQuestion]
		(
			Id INT PRIMARY KEY IDENTITY(1,1),
			TestId INT FOREIGN KEY REFERENCES Test(Id) NOT NULL,
			QuestionId INT FOREIGN KEY REFERENCES Question(Id) NOT NULL
		) 
		PRINT 'Table TestQuestion is succesfully created'
    END;
ELSE 
	BEGIN
		PRINT 'Table TestQuestion already exists'
	END;