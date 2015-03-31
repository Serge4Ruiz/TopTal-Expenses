using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin
{
	public partial class ReportManager
	{
		public string SaveReport(Model.Report report)
		{
			return ReportDB.SaveReport(report.ToModel());
		}

		public void DeleteReport(string soid)
		{
			var db = new ReportDB();
			db.Delete(soid);
		}

		public Model.Report GetReport(string soid)
		{
			return new Model.Report(ReportDB.GetReport(soid));
		}

		public Model.Report GetReportFromSqlId(int id)
		{
			var report = ReportDB.GetReportFromSqlId(id);
			if (report == null)
				return null;
			return new Model.Report(report);
		}

		public IEnumerable<Model.Report> GetReportList()
		{
			var db = new ReportDB();
			foreach (var report in db.GetDocuments())
				yield return new Model.Report(report);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Admin.ReportDB();
			mgr.Clear();
		}
	}
}
