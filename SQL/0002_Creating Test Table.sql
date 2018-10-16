USE MyFirstFullStackApp_DEV;

IF  NOT EXISTS (SELECT 1 FROM sys.tables WHERE NAME = N'Test'  AND TYPE = 'U')
    BEGIN
        CREATE TABLE [Test]
		(
			Id INT PRIMARY KEY IDENTITY(1, 1),
			Title VARCHAR(50) NOT NULL
		) 
		PRINT 'Table Test is succesfully created'
    END;
ELSE 
	BEGIN
		PRINT 'Table Test already exists'
	END;