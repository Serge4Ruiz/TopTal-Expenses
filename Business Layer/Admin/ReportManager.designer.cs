using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Admin
{
	public partial class ReportManager
	{
		public string SaveReport(Model.Report report)
		{
			var mgr = new ServiceLayer.Admin.ReportManager();
			return mgr.SaveReport(report.ToModel());
		}

		public void DeleteReport(string soid)
		{
			var mgr = new ServiceLayer.Admin.ReportManager();
			mgr.DeleteReport(soid);
		}

		public Model.Report GetReport(string soid)
		{
			var mgr = new ServiceLayer.Admin.ReportManager();
			return new Model.Report(mgr.GetReport(soid));
		}

		public IEnumerable<Model.Report> GetReportList()
		{
			var mgr = new ServiceLayer.Admin.ReportManager();
			foreach (var report in mgr.GetReportList())
				yield return new Model.Report(report);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Admin.ReportManager();
			return mgr.Update(fieldName, data);
		}
	}
}
