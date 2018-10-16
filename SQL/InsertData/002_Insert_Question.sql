USE MyFirstFullStackApp_DEV
GO

IF (SELECT COUNT(1) FROM Question) = 0
BEGIN
	INSERT INTO Question VALUES ('Combien y a-t-il de cas de figure d’utilisation au mot clef using ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>using (var p = new Product())
	{
		// Some stuff
	}</code><br />
		Quelle interface est censée implémenter Product en partant du principe que le mot clef using est correctement utilisé ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>public class A
	{
		public virtual string GetName()
		{
			return "A";
		}
	}

	public class B : A
	{
		public override string GetName()
		{
			return "B";
		}
	}

	A a = new B();
	var result = a.GetName();</code><br />
		Que vaut result ?')
	INSERT INTO Question VALUES ('Lequel de ces bindings n’existent pas ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>try
	{
		throw new Exception();
	}
	catch (Exception e)
	{
		throw e;
		UpdateData();
	}
	finally
	{
		DeleteData();
	}</code><br />
		Que se passe-t-il ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>public class A { /* Some stuff */ }

	public class B { /* Some stuff */ }

	public class C : A, B
	{
	}</code><br />
		Laquelle de ces affirmations est vraies ?')
	INSERT INTO Question VALUES ('Modificateur d’accès par défaut<br /><br />
	<code>public class A
	{
		string B { get; set; }
	}</code><br />
		Quelle est la portée de la propriété B ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>public static string DoSomething(Func&#60;bool, string&#62; doOtherThing)
	{
		return doOtherThing(true);
	}</code><br />
		Laquelle de ces lignes de code n’est pas correcte ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>public IEnumerable&#60;string&#62; GetList(IEnumerable&#60;int&#62; myList)
	{
		foreach (var elem in myList)
		{
			…
		}
	}</code><br />
		Laquelle de ces lignes de code peut remplacer … ?')
	INSERT INTO Question VALUES ('Que doit-on faire pour effectuer des opérations bit à bit avec le type enum ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>public void DoSomething(out int a)
	{
		a = 1;
	}

	int b = 10;
	DoSomething(out b);</code><br />
		Que vaut b à la fin de l’exécution du code ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>public static class A
	{
		public const Nb = 5;
	}</code><br />
		Si je change la valeur de Nb en 10 et que je recompile la DLL, que vaut A.Nb dans les autres DLL ?')
	INSERT INTO Question VALUES ('Soit le code suivant :<br /><br />
	<code>var a = new A();
	var c = a as C;</code><br />
		Que vaut c ?')
END
GO