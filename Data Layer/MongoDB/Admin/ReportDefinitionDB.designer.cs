using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	public partial class ReportDefinitionDB : DocumentList<ReportDefinition>
	{
		public ReportDefinitionDB()
			: base(new ReportDefinition())
		{
		}

		public static string SaveReportDefinition(ReportDefinition reportDefinition)
		{
			var db = new ReportDefinitionDB();
			db.Save(reportDefinition);
			return reportDefinition.Id.ToString();
		}

		public static ReportDefinition GetReportDefinition(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetReportDefinition(oid);
			return null;
		}

		public static ReportDefinition GetReportDefinitionFromSqlId(int id)
		{
			var db = new ReportDefinitionDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static ReportDefinition GetReportDefinition(ObjectId oid)
		{
			var db = new ReportDefinitionDB();
			return db.GetDocument(oid);
		}
	}
}
