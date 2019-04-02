using System;

namespace Serialize
{
	[Serializable]
	internal class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}
	}

	internal class Program
	{
		private static void Main(string[] args)
		{
			LINQ_Test.MyMain();

			/////qqweqweqweqw
			//Person person1 = new Person("Tom", 29);
			//Person person2 = new Person("Bill", 25);
			//// массив для сериализации
			//Person[] people = new Person[] { person1, person2 };

			//var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

			//using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
			//{
			//	// сериализуем весь массив people
			//	formatter.Serialize(fs, people);

			//	Console.WriteLine("Объект сериализован");
			//}

			//// десериализация
			//using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
			//{
			//	Person[] deserilizePeople = (Person[])formatter.Deserialize(fs);

			//	foreach (Person p in deserilizePeople)
			//	{
			//		Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
			//	}
			//}
			//Console.ReadLine();
		}
	}
}