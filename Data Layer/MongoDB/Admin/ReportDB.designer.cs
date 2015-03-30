using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	public partial class ReportDB : DocumentList<Report>
	{
		public ReportDB()
			: base(new Report())
		{
		}

		public static string SaveReport(Report report)
		{
			var db = new ReportDB();
			db.Save(report);
			return report.Id.ToString();
		}

		public static Report GetReport(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetReport(oid);
			return null;
		}

		public static Report GetReportFromSqlId(int id)
		{
			var db = new ReportDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static Report GetReport(ObjectId oid)
		{
			var db = new ReportDB();
			return db.GetDocument(oid);
		}
	}
}
