USE MyFirstFullStackApp_DEV
GO

IF (SELECT COUNT(1) FROM Test) = 0
BEGIN
	INSERT INTO Test VALUES ('Test C# easy')
	INSERT INTO Test VALUES ('Test C# medium')
	INSERT INTO Test VALUES ('Test C# hard')
	INSERT INTO Test VALUES ('Test C# very hard')
END
GO