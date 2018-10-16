USE MyFirstFullStackApp_DEV
GO

IF (SELECT COUNT(1) FROM Answer) = 0
BEGIN
	INSERT INTO Answer VALUES (1, 'a', '1', 0)
	INSERT INTO Answer VALUES (1, 'b', '2', 0)
	INSERT INTO Answer VALUES (1, 'c', '3', 1)
	INSERT INTO Answer VALUES (1, 'd', '4', 0)

	INSERT INTO Answer VALUES (2, 'a', 'IDisposable', 1)
	INSERT INTO Answer VALUES (2, 'b', 'IProduct', 0)
	INSERT INTO Answer VALUES (2, 'c', 'IProducts', 0)
	INSERT INTO Answer VALUES (2, 'd', 'On ne peut pas le savoir', 0)

	INSERT INTO Answer VALUES (3, 'a', 'A', 0)
	INSERT INTO Answer VALUES (3, 'b', 'B', 1)
	INSERT INTO Answer VALUES (3, 'c', 'result', 0)
	INSERT INTO Answer VALUES (3, 'd', 'Ce code ne compile pas', 0)

	INSERT INTO Answer VALUES (4, 'a', 'BasicHttpBinding', 0)
	INSERT INTO Answer VALUES (4, 'b', 'WSHttpBinding', 0)
	INSERT INTO Answer VALUES (4, 'c', 'SecurityHttpBinding', 1)
	INSERT INTO Answer VALUES (4, 'd', 'NetTcpBinding', 0)

	INSERT INTO Answer VALUES (5, 'a', 'Les données sont mises à jours', 0)
	INSERT INTO Answer VALUES (5, 'b', 'Les données sont effacées', 1)
	INSERT INTO Answer VALUES (5, 'c', 'Les données sont mises à jours puis effacées', 0)
	INSERT INTO Answer VALUES (5, 'd', 'Ce code ne compile pas', 0)

	INSERT INTO Answer VALUES (6, 'a', 'C hérite de A et B', 0)
	INSERT INTO Answer VALUES (6, 'b', 'C implémente A et B', 0)
	INSERT INTO Answer VALUES (6, 'c', 'Ce code plante à l’exécution', 0)
	INSERT INTO Answer VALUES (6, 'd', 'Ce code ne compile pas', 1)

	INSERT INTO Answer VALUES (7, 'a', 'private', 1)
	INSERT INTO Answer VALUES (7, 'b', 'protected', 0)
	INSERT INTO Answer VALUES (7, 'c', 'internal', 0)
	INSERT INTO Answer VALUES (7, 'd', 'public', 0)

	INSERT INTO Answer VALUES (8, 'a', 'DoSomething(b => string.Empty);', 0)
	INSERT INTO Answer VALUES (8, 'b', 'DoSomething(DoSomeStuff);', 0)
	INSERT INTO Answer VALUES (8, 'c', 'DoSomething(delegate(bool b) { return string.Empty; });', 0)
	INSERT INTO Answer VALUES (8, 'd', 'DoSomething(doOtherThing());', 1)

	INSERT INTO Answer VALUES (9, 'a', 'yield return elem.ToString();', 1)
	INSERT INTO Answer VALUES (9, 'b', 'return elem;', 0)
	INSERT INTO Answer VALUES (9, 'c', 'return new List<string> { elem.ToString() };', 0)
	INSERT INTO Answer VALUES (9, 'd', 'return new Enumerable<string> { elem.ToString() };', 0)

	INSERT INTO Answer VALUES (10, 'a', 'Convertir chaque enum en type bit', 0)
	INSERT INTO Answer VALUES (10, 'b', 'Utiliser le type enumBit', 0)
	INSERT INTO Answer VALUES (10, 'c', 'Utiliser l’attribut Flags', 1)
	INSERT INTO Answer VALUES (10, 'd', 'Donner une valeur en octet à chaque enum', 0)

	INSERT INTO Answer VALUES (11, 'a', '0', 0)
	INSERT INTO Answer VALUES (11, 'b', '1', 1)
	INSERT INTO Answer VALUES (11, 'c', '10', 0)
	INSERT INTO Answer VALUES (11, 'd', 'out', 0)

	INSERT INTO Answer VALUES (12, 'a', '5', 0)
	INSERT INTO Answer VALUES (12, 'b', '10', 1)
	INSERT INTO Answer VALUES (12, 'c', 'Cela dépend de la clause using dans la DLL appelante', 0)
	INSERT INTO Answer VALUES (12, 'd', 'On ne peut pas le savoir', 0)

	INSERT INTO Answer VALUES (13, 'a', 'a', 0)
	INSERT INTO Answer VALUES (13, 'b', 'null', 1)
	INSERT INTO Answer VALUES (13, 'c', 'Ce code lève une exception', 0)
	INSERT INTO Answer VALUES (13, 'd', 'Ce code ne compile pas', 0)
END
GO