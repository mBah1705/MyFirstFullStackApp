IF  NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = N'MyFirstFullStackApp_DEV')
    BEGIN
        CREATE DATABASE [MyFirstFullStackApp_DEV]
		PRINT 'Database MyFirstFullStackApp_DEV is succesfully created'
    END;
ELSE 
	BEGIN
		PRINT 'Database MyFirstFullStackApp_DEV already exists'
	END;