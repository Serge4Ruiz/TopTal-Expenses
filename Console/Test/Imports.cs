using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace TopTal.Expenses.Win32.Test
{
	class Imports : BaseTestSuite
	{
		public Imports()
			: base("Imports")
		{
			options.Add(ConsoleKey.A, "Members");
		}

		public override void RunOption(ConsoleKey key)
		{
			base.RunOption(key);
			switch (key)
			{
				case ConsoleKey.A: ImportMembers(); break;
			}
		}

		void ImportMembers()
		{
			var importer = new ServiceLayer.Importers.ExcelMembers("Members.xlsx");
			importer.ReadDocument();
		}
	}
}
