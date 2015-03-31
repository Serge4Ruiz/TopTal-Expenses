using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TopTal.Expenses.Win32.Test
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//}
		/// <summary>
		/// The path to the Documents _folder
		/// </summary>
		static internal string Root;
		static internal Random Rnd;

		static void Main(string[] args)
		{
			//DeleteStudents();
			Root = (new DirectoryInfo(Environment.CurrentDirectory)).Parent.Parent.CreateSubdirectory("Documents").FullName;
			Rnd = new Random(DateTime.Now.Second);
			ConsoleKey ck;
			do
			{
				Console.Clear();
				DisplayMenu();
				DateTime start = DateTime.Now;
				ck = Console.ReadKey().Key;
				BaseTestSuite testClass = null;
				switch (ck)
				{
					case ConsoleKey.A: testClass = new Admin(); break;
					case ConsoleKey.B: testClass = new Analytics(); break;
					case ConsoleKey.E: testClass = new Exports(); break;
					case ConsoleKey.I: testClass = new Imports(); break;
					case ConsoleKey.M: testClass = new Membership(); break;
				}
				Console.WriteLine();
				bool inSuite = false;
				if (testClass != null)
				{
					inSuite = true;
					testClass.DisplayOptions();
					ck = Console.ReadKey().Key;
					Console.WriteLine();
					Console.WriteLine();
					start = DateTime.Now;
					testClass.RunOption(ck);
				}
				if (inSuite) // this is here to avoid a double escape when the escape was clicked at the top level
				{
					Console.WriteLine();
					Console.WriteLine("Time elapsed : " + DateTime.Now.Subtract(start));
					Console.Write("Press any key to continue...");
					ck = Console.ReadKey().Key;
					if (ck == ConsoleKey.Escape)
						ck = ConsoleKey.Spacebar;
				}
			}
			while (ck != ConsoleKey.Escape);
		}

		static void DisplayMenu()
		{
			Console.WriteLine("A. Admin");
			Console.WriteLine("B. Analytics");
			Console.WriteLine("E. Exports");
			Console.WriteLine("I. Imports");
			Console.WriteLine("M. Membership");
			Console.WriteLine();
			Console.WriteLine("... select a Test Suite");
		}

		static int Index;
		internal static void ResetProgress()
		{
			Index = 0;
		}
		internal static void MarkProgress(char display = char.MinValue)
		{
			Index++;
			if (display == char.MinValue)
			{
				if (Index % 1000 == 0)
					Console.Write((Index / 1000) % 10);
				else if (Index % 100 == 0)
					Console.Write("|");
				else if (Index % 10 == 0)
					Console.Write("'");
				else
					Console.Write(".");
			}
			else
				Console.Write(display);
		}
	}
}
