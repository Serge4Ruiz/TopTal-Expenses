using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using OfficeOpenXml;
using System.Configuration;

namespace TopTal.Expenses.ServiceLayer.Importers
{
	public abstract class ExcelReader
	{
		protected ExcelPackage _xlPkg;
		protected ExcelWorksheet _sheet;
		protected int _lastRow = 1;
		protected int _lastColumn = 1;
		protected Dictionary<string, bool> _properties = new Dictionary<string, bool>();

		protected ExcelReader(string fileName, params string[] folders)
		{
			string root = ConfigurationManager.AppSettings["DataRoot"];
			DirectoryInfo dirInfo = new DirectoryInfo(root);
			foreach (string folder in folders)
				dirInfo = dirInfo.CreateSubdirectory(folder);
			FileInfo workbook = new FileInfo(Path.Combine(dirInfo.FullName, fileName));
			if (!workbook.Exists)
				throw new FileNotFoundException("File Not Found", workbook.FullName);
			_xlPkg = new ExcelPackage(workbook);
			_sheet = _xlPkg.Workbook.Worksheets[1];
			FindBounds();
			Console.WriteLine(string.Format("{0} loaded. Sheets are: {1}", workbook.Name, string.Join(", ", GetSheetNames())));
		}

		protected IEnumerable<string> GetSheetNames()
		{
			if (_xlPkg == null)
				throw new FileNotFoundException("No file selected");
			foreach (var sheet in _xlPkg.Workbook.Worksheets)
			{
				yield return sheet.Name;
			}
		}

		protected string ActivateSheet(string name)
		{
			if (_xlPkg == null)
				throw new FileNotFoundException("No file selected");
			if (_xlPkg.Workbook.Worksheets.Any(s => s.Name == name))
			{
				_sheet = _xlPkg.Workbook.Worksheets[name];
				FindBounds();
			}
			else
				throw new MissingMemberException("Worksheet not found: " + name);
			return _sheet.Name;
		}

		protected void FindBounds()
		{
			if (_sheet.Dimension == null)
			{
				_lastRow = 1;
				_lastColumn = 1;
			}
			_lastRow = _sheet.Dimension.End.Row;
			_lastColumn = _sheet.Dimension.End.Column;
		}

		protected Dictionary<string, int> GetColumnIndexes(params string[] headers)
		{
			Dictionary<string, int> map = new Dictionary<string, int>();
			for (int col = 1; col <= _lastColumn; col++)
			{
				string header = _sheet.Cells[1, col].Value.ToString();
				if (headers.Contains(header))
				{
					if (map.ContainsKey(header))
						continue;
					map.Add(header, col);
				}
			}
			return map;
		}

		public abstract void ReadDocument();

		protected string GetString(object obj)
		{
			if (obj == null)
				return null;
			return obj.ToString();
		}

		protected int GetInt(object obj)
		{
			int i = 0;
			string s = GetString(obj);
			if (s == null)
				return 0;
			if (int.TryParse(s, out i))
				return i;
			return 0;
		}

		protected long GetLong(object obj)
		{
			long l = 0;
			string s = GetString(obj);
			if (s == null)
				return 0;
			if (long.TryParse(s, out l))
				return l;
			return 0;
		}

		protected float GetFloat(object obj)
		{
			float f = .0f;
			string s = GetString(obj);
			if (s == null)
				return .0f;
			if (float.TryParse(s, out f))
				return f;
			return .0f;
		}

		protected bool GetBool(object obj)
		{
			bool b = false;
			string s = GetString(obj);
			if (s == null)
				return false;
			if (bool.TryParse(s, out b))
				return b;
			return false;
		}

		protected DateTime GetDateTime(object obj)
		{
			DateTime d = new DateTime();
			string s = GetString(obj);
			if (s == null)
				return new DateTime();
			if (DateTime.TryParse(s, out d))
				return d;
			return new DateTime();
		}

		protected DateTime? GetDateTimeNull(object obj)
		{
			DateTime d = new DateTime();
			string s = GetString(obj);
			if (s == null)
				return null;
			if (DateTime.TryParse(s, out d))
				return d;
			return null;
		}
	}
}
