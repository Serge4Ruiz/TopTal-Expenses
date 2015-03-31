using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.Win32.Test
{
	class BaseTestSuite
	{
		private string _suiteName;
		protected Dictionary<ConsoleKey, string> options = new Dictionary<ConsoleKey, string>();

		protected BaseTestSuite(string suiteName)
		{
			_suiteName = suiteName;
		}

		public void DisplayOptions()
		{
			Console.WriteLine("".PadRight(20, '='));
			Console.WriteLine("SUITE : " + _suiteName);
			Console.WriteLine("".PadRight(20, '-'));
			foreach (ConsoleKey key in options.Keys)
			{
				Console.WriteLine("{0}. {1}", key, options[key]);
			}
			Console.WriteLine();
			Console.WriteLine("... select a Test");
		}

		public virtual void RunOption(ConsoleKey key)
		{
			if (key == ConsoleKey.Escape)
				return;
			if (!options.ContainsKey(key))
			{
				Console.WriteLine("Option not available - press any key to continue");
				Console.ReadKey();
				DisplayOptions();
			}
		}
	}
}
