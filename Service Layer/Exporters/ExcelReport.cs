using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Exporters
{
	public class ExcelReport : ExcelWriter
	{
		protected DataSet _ds;

		public ExcelReport(DataSet ds, string fileName, params string[] folderNames)
			: base(folderNames)
		{
			_ds = ds;
			FileName = fileName;
		}

		public override void CreateDocument()
		{
			base.CreateDocument();
			_xlPkg.Workbook.Worksheets.Delete(1);
			foreach (DataTable tbl in _ds.Tables)
			{
				_ws = _xlPkg.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == tbl.TableName);
				if (_ws == null)
					_ws = _xlPkg.Workbook.Worksheets.Add(tbl.TableName);
				int colIndex = 1;
				foreach (DataColumn col in tbl.Columns)
				{
					_ws.Cells[1, colIndex++].Value = col.ColumnName;
				}
				colIndex = 1;
				int rowIndex = 2;
				foreach (DataRow row in tbl.Rows)
				{
					foreach (DataColumn col in tbl.Columns)
					{
						_ws.Cells[rowIndex, colIndex++].Value = row[col];
					}
					rowIndex++;
					colIndex = 1;
				}
			}
			Save();
		}
	}
}
