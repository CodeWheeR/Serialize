using System;
using System.Collections.Generic;
using System.Linq;

namespace Serialize
{
	internal class Student
	{
		public string Name { get; set; }
		public int Course { get; set; }

		public Student(string name, int course)
		{
			Name = name;
			Course = course;
		}
	}

	internal class Player
	{
		public string Name { get; set; }
		public string Team { get; set; }
	}

	internal class Team
	{
		public string Name { get; set; }
		public string Country { get; set; }
	}

	internal class LINQ_Test
	{
		public static void MyMain()
		{
			var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 100 };

			var squareOfNumbers = from x in numbers
								  where x % 2 == 1
								  select (x * x);

			foreach (var i in squareOfNumbers)
			{
				Console.Write(i.ToString("# "));
			}

			Console.WriteLine();

			var squareOfNumbers2 = numbers.Where(x => x % 2 == 1)
				.Select(x => (x * x));

			var etnyeChisla = numbers.Where(x => x % 2 == 0);

			foreach (var i in squareOfNumbers2)
			{
				Console.Write(i.ToString("# "));
			}

			Console.WriteLine();
			Console.WriteLine();

			///////////////////////////////////////

			foreach (var i in from n in numbers
							  orderby n ascending //descending
							  select n)
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();
			foreach (var i in numbers.OrderByDescending(x => x))
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();
			Console.WriteLine();

			////////////////////////////////////////

			var students = new List<Student>
			{
				new Student("Малахов", 3),
				new Student("Кришкин", 4),
				new Student("Кротов",1),
				new Student("Чистяков", 2),
				new Student("Мухтаровa", 2),
				new Student("Григорьев", 3),
				new Student("Капустин",4),
				new Student("Коновалов", 1)
			};

			foreach (var i in students.OrderBy(s => s.Course).ThenBy(s => s.Name))
			{
				Console.WriteLine($"{i.Name} - {i.Course} курс");
			}

			Console.WriteLine();

			foreach (var i in from s in students
							  orderby s.Course, s.Name
							  select s)
			{
				Console.WriteLine($"{i.Name} - {i.Course} курс");
			}

			Console.WriteLine();

			//////////////////////////////////////

			var selectedStudents = from s in students
								   where s.Course > 2
								   let name = s.Name.Substring(1)
								   where name.Length <= 7
								   orderby name
								   select "Cтудент " + name;

			//foreach (var i in selectedStudents)
			//	Console.WriteLine(i);
			//Console.WriteLine();

			var selectedStudents2 = students.Where(x => x.Course > 2 && x.Name.Substring(1).Length <= 7)
											.OrderBy(x => x.Name.Substring(1))
											.Select(x => "Cтудент " + x.Name.Substring(1));
			var selectedStudents3 = students.Where(x => x.Course > 2)
											.Select(x => x.Name.Substring(1)).Where(x => x.Length <= 7)
											.OrderBy(x => x)
											.Select(x => "Cтудент " + x); ;

			foreach (var i in selectedStudents2)
			{
				Console.WriteLine(i);
			}

			Console.WriteLine();

			//////////////////////////////////////

			string[] one = { "Яблоко", "Морковь", "Помидор" };
			string[] two = { "Морковь", "Абрикос", "Яблоко" };

			foreach (var i in one.Except(two))
			{
				Console.WriteLine(i);
			}

			Console.WriteLine();

			foreach (var i in one.Intersect(two))
			{
				Console.WriteLine(i);
			}

			Console.WriteLine();

			foreach (var i in one.Union(two))
			{
				Console.WriteLine(i);
			}

			Console.WriteLine();
			//Или
			foreach (var i in one.Concat(two).Distinct())
			{
				Console.WriteLine(i);
			}

			Console.WriteLine();

			/////////////////////////////////////

			int composition = numbers.Skip(1).Aggregate((x, y) => x * y);
			Console.WriteLine(composition);

			int sum = numbers.Sum();
			Console.WriteLine(sum);

			int max = numbers.Max();
			Console.WriteLine(max);


			Console.WriteLine();

			/////////////////////////////////////

			var skippedNumbers = numbers.Skip(4);
			foreach (var i in skippedNumbers)
			{
				Console.Write(i.ToString("####"));
			}

			Console.WriteLine();

			var takedNumbers = numbers.Take(4);
			foreach (var i in takedNumbers)
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();
			Console.WriteLine();

			////////////////////////////////////

			var grouping = from i in students
						   group i by i.Course;

			var grouping2 = students.GroupBy(x => x.Course);

			foreach (var i in grouping2)
			{
				Console.WriteLine(i.Key);
				foreach (var j in i)
				{
					Console.WriteLine(j.Name);
				}

				Console.WriteLine();
			}

			var groupsCount = students.GroupBy(x => x.Course)
									  .Select(x => x.Key + " курс - " + x.Count() + " студента");
			foreach (var i in groupsCount)
			{
				Console.WriteLine(i);
			}

			//////ВНИМАНИЕ, ФИЧА////////
			foreach (var i in students.GroupBy(x => x.Course)
									  .Select(x => x.Key + " курс - " +
									x.Aggregate((x1, y) => new Student(x1.Name + ", " + y.Name, y.Course)).Name))
			{
				Console.WriteLine(i);
			}

			Console.WriteLine();

			var groups = students.GroupBy(x => x.Course)
									  .Select(x => new { Name = x.Key + " курс :", Students = x.Select(y => y.Name) });
			foreach (var i in groups)
			{
				Console.WriteLine(i.Name);
				foreach (var j in i.Students)
				{
					Console.WriteLine(j);
				}

				Console.WriteLine();
			}

			///////////////////////////////////////////////

			var teams = new List<Team>()
			{
			new Team { Name = "Бавария", Country ="Германия" },
			new Team { Name = "Барселона", Country ="Испания" }
			};
			List<Player> players = new List<Player>()
			{
			new Player {Name="Месси", Team="Барселона"},
			new Player {Name="Неймар", Team="Барселона"},
			new Player {Name="Роббен", Team="Бавария"}
			};

			var joining = players.Join(teams, x => x.Team, y => y.Name, (x, y) => (x.Name, x.Team, y.Country));
			foreach (var i in joining)
			{
				Console.WriteLine($"{i.Name} - {i.Team} ({i.Country})");
			}

			Console.WriteLine();

			var groupJoining = teams.GroupJoin(players, x => x.Name, y => y.Team, (x, Group/*!!!*/) => (x.Country, x.Name, Group));

			foreach (var i in groupJoining)
			{
				Console.WriteLine($"{i.Name} ({i.Country})");
				foreach (var j in i.Group)
				{
					Console.WriteLine(j.Name);
				}

				Console.WriteLine();
			}
			Console.WriteLine();

			////////////////////////////////////////////////////

			var counts = new int[5] { 1, 2, 3, 4, 5 };
			var strings = new string[5] { "a", "b", "c", "d", "e" };

			foreach (var i in counts.Zip(strings, (c, s) => Tuple.Create(c, s)))
			{
				Console.WriteLine(i.Item1 + " - " + i.Item2);
			}

			Console.WriteLine();

			////////////////////////////////////////////////////

			if (!students.All(x => x.Name.StartsWith("К")))
			{
				Console.WriteLine("У нас завелись студенты не на К...");
			}

			if (students.Any(x => x.Course == 3))
			{
				Console.WriteLine("Среди нас есть третекурсники");
			}

			Console.WriteLine();
			Console.ReadLine();
		}
	}
}