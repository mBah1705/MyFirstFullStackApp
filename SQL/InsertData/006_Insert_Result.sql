USE MyFirstFullStackApp_DEV
GO

IF (SELECT COUNT(1) FROM Result) = 0
BEGIN
	INSERT INTO Result VALUES (1, 3)
	INSERT INTO Result VALUES (1, 10)
	INSERT INTO Result VALUES (1, 14)
	INSERT INTO Result VALUES (1, 18)
	INSERT INTO Result VALUES (1, 24)
	INSERT INTO Result VALUES (1, 25)
	INSERT INTO Result VALUES (1, 31)
	INSERT INTO Result VALUES (1, 33)
	INSERT INTO Result VALUES (1, 39)
	INSERT INTO Result VALUES (1, 42)

	INSERT INTO Result VALUES (2, 4)
	INSERT INTO Result VALUES (2, 11)
	INSERT INTO Result VALUES (2, 15)
	INSERT INTO Result VALUES (2, 20)
	INSERT INTO Result VALUES (2, 22)
	INSERT INTO Result VALUES (2, 26)
	INSERT INTO Result VALUES (2, 32)
	INSERT INTO Result VALUES (2, NULL)
	INSERT INTO Result VALUES (2, 41)
	INSERT INTO Result VALUES (2, 47)

	INSERT INTO Result VALUES (3, 5)
	INSERT INTO Result VALUES (3, 10)
	INSERT INTO Result VALUES (3, 15)
	INSERT INTO Result VALUES (3, 24)
	INSERT INTO Result VALUES (3, 25)
	INSERT INTO Result VALUES (3, 32)
	INSERT INTO Result VALUES (3, 33)
	INSERT INTO Result VALUES (3, 39)
	INSERT INTO Result VALUES (3, 42)
	INSERT INTO Result VALUES (3, 50)

	INSERT INTO Result VALUES (4, 4)
	INSERT INTO Result VALUES (4, 5)
	INSERT INTO Result VALUES (4, 10)
	INSERT INTO Result VALUES (4, 16)
	INSERT INTO Result VALUES (4, 18)
	INSERT INTO Result VALUES (4, 24)
	INSERT INTO Result VALUES (4, 30)
	INSERT INTO Result VALUES (4, 33)
	INSERT INTO Result VALUES (4, 39)
	INSERT INTO Result VALUES (4, 42)

	INSERT INTO Result VALUES (5, 3)
	INSERT INTO Result VALUES (5, 10)
	INSERT INTO Result VALUES (5, 13)
	INSERT INTO Result VALUES (5, 18)
	INSERT INTO Result VALUES (5, 23)
	INSERT INTO Result VALUES (5, 27)
	INSERT INTO Result VALUES (5, 32)
	INSERT INTO Result VALUES (5, 33)
	INSERT INTO Result VALUES (5, 44)
	INSERT INTO Result VALUES (5, 47)

	INSERT INTO Result VALUES (6, 8)
	INSERT INTO Result VALUES (6, 10)
	INSERT INTO Result VALUES (6, 14)
	INSERT INTO Result VALUES (6, 24)
	INSERT INTO Result VALUES (6, 26)
	INSERT INTO Result VALUES (6, 29)
	INSERT INTO Result VALUES (6, 34)
	INSERT INTO Result VALUES (6, 39)
	INSERT INTO Result VALUES (6, 43)
	INSERT INTO Result VALUES (6, 50)
END
GO