USE MyFirstFullStackApp_DEV;

IF  NOT EXISTS (SELECT 1 FROM sys.tables WHERE NAME = N'Question'  AND TYPE = 'U')
    BEGIN
        CREATE TABLE [Question]
		(
			Id INT PRIMARY KEY IDENTITY(1,1),
			Statement VARCHAR(500) NOT NULL
		) 
		PRINT 'Table Question is succesfully created'
    END;
ELSE 
	BEGIN
		PRINT 'Table Question already exists'
	END;