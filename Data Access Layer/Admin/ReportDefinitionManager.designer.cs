using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin
{
	public partial class ReportDefinitionManager
	{
		public string SaveReportDefinition(Model.ReportDefinition reportDefinition)
		{
			return ReportDefinitionDB.SaveReportDefinition(reportDefinition.ToModel());
		}

		public void DeleteReportDefinition(string soid)
		{
			var db = new ReportDefinitionDB();
			db.Delete(soid);
		}

		public Model.ReportDefinition GetReportDefinition(string soid)
		{
			return new Model.ReportDefinition(ReportDefinitionDB.GetReportDefinition(soid));
		}

		public Model.ReportDefinition GetReportDefinitionFromSqlId(int id)
		{
			var reportDefinition = ReportDefinitionDB.GetReportDefinitionFromSqlId(id);
			if (reportDefinition == null)
				return null;
			return new Model.ReportDefinition(reportDefinition);
		}

		public IEnumerable<Model.ReportDefinition> GetReportDefinitionList()
		{
			var db = new ReportDefinitionDB();
			foreach (var reportDefinition in db.GetDocuments())
				yield return new Model.ReportDefinition(reportDefinition);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Admin.ReportDefinitionDB();
			mgr.Clear();
		}
	}
}
