using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using OfficeOpenXml;

namespace TopTal.Expenses.ServiceLayer.Exporters
{
	public class ExcelWriter : BaseDocument
	{
		protected ExcelPackage _xlPkg;
		protected ExcelWorksheet _ws;
		protected FileInfo _template;
		public static int _year = DateTime.Today.Year;

		public ExcelWriter(params string[] folderNames)
			: base(folderNames)
		{
			_extension = ".xlsx";
		}

		public ExcelWriter(string template, int year, params string[] folderNames) : this(folderNames)
		{
			_template = new FileInfo(Path.Combine(_root + @"\Excel Templates\", template));
		}

		public virtual void CreateDocument()
		{
			FileInfo info = new FileInfo(FileFullName);
			if (info.Exists)
				info.Delete();
			string fileFullName = info.FullName;
			if (info.Extension != _extension)
				fileFullName += _extension;
			_xlPkg = new ExcelPackage(new FileInfo(FileFullName));
			_xlPkg.Workbook.Worksheets.Add("Sheet1");
			_ws = _xlPkg.Workbook.Worksheets[1];
		}

		public void Save()
		{
			_xlPkg.Save();
		}

		public void AddHeaderCell(int row, int col, string content)
		{
			var cell = _ws.Cells[row, col];
			cell.Value = content;
			cell.Style.Font.Bold = true;
		}

		protected void ActivateWorksheet(string name)
		{
			if (_xlPkg == null)
				return;
			_ws = _xlPkg.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == name);
			if (_ws == null)
				_ws = _xlPkg.Workbook.Worksheets.Add(name);
		}

		protected void CreateBorder(OfficeOpenXml.ExcelRangeBase range)
		{
			var border = range.Style.Border;
			border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
			border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
			border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
			border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
		}
	}
}
