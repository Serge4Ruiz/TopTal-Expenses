using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace TopTal.Expenses.Win32.Test
{
	class Exports : BaseTestSuite
	{
		public Exports()
			: base("Exports")
		{
			options.Add(ConsoleKey.A, "Members");
		}

		public override void RunOption(ConsoleKey key)
		{
			base.RunOption(key);
			switch (key)
			{
				case ConsoleKey.A: ExportMembers(); break;
			}
		}

		void ExportMembers()
		{
			var exporter = new ServiceLayer.Exporters.ExcelMembers();
			exporter.CreateDocument();
			System.Diagnostics.Process.Start(exporter.FileFullName);
		}
	}
}
