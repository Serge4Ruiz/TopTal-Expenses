using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Admin
{
	public partial class ReportDefinitionManager
	{
		public string SaveReportDefinition(Model.ReportDefinition reportDefinition)
		{
			var mgr = new ServiceLayer.Admin.ReportDefinitionManager();
			return mgr.SaveReportDefinition(reportDefinition.ToModel());
		}

		public void DeleteReportDefinition(string soid)
		{
			var mgr = new ServiceLayer.Admin.ReportDefinitionManager();
			mgr.DeleteReportDefinition(soid);
		}

		public Model.ReportDefinition GetReportDefinition(string soid)
		{
			var mgr = new ServiceLayer.Admin.ReportDefinitionManager();
			return new Model.ReportDefinition(mgr.GetReportDefinition(soid));
		}

		public IEnumerable<Model.ReportDefinition> GetReportDefinitionList()
		{
			var mgr = new ServiceLayer.Admin.ReportDefinitionManager();
			foreach (var reportDefinition in mgr.GetReportDefinitionList())
				yield return new Model.ReportDefinition(reportDefinition);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Admin.ReportDefinitionManager();
			return mgr.Update(fieldName, data);
		}
	}
}
