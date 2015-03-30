using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Admin
{
	public partial class ReportManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.Report _report;

		public string SaveReport(Model.Report report)
		{
			var mgr = new DataAccessLayer.Admin.ReportManager();
			return mgr.SaveReport(report.ToModel());
		}

		public void DeleteReport(string soid)
		{
			var mgr = new DataAccessLayer.Admin.ReportManager();
			mgr.DeleteReport(soid);
		}

		public Model.Report GetReport(string soid)
		{
			var mgr = new DataAccessLayer.Admin.ReportManager();
			return new Model.Report(mgr.GetReport(soid));
		}

		public Model.Report GetReportFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Admin.ReportManager();
			var report = mgr.GetReportFromSqlId(id);
			if (report == null)
				return null;
			return new Model.Report(report);
		}

		public IEnumerable<Model.Report> GetReportList()
		{
			var mgr = new DataAccessLayer.Admin.ReportManager();
			foreach (var report in mgr.GetReportList())
				yield return new Model.Report(report);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Admin.ReportManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_report = GetReport(_fieldBits.Last());
			if (_report == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "CreatedOn": DateTime dateCreatedOn = new DateTime(); if (DateTime.TryParse(_data, out dateCreatedOn)) { _changed = _report.CreatedOn != dateCreatedOn; _report.CreatedOn = dateCreatedOn; }; break;
				case "ReportType": _changed = _report.ReportType != _data; _report.ReportType = _data; break;
				case "ReportSoid": _changed = _report.ReportSoid != _data; _report.ReportSoid = _data; break;
				case "OriginatorName": _changed = _report.OriginatorName != _data; _report.OriginatorName = _data; break;
				case "OriginatorSoid": _changed = _report.OriginatorSoid != _data; _report.OriginatorSoid = _data; break;
				case "ReportFullName": _changed = _report.ReportFullName != _data; _report.ReportFullName = _data; break;
				case "RecordCount": int iRecordCount = 0; if (int.TryParse(_data, out iRecordCount)) { _changed = _report.RecordCount != iRecordCount; _report.RecordCount = iRecordCount; }; break;
			}
			SaveReport(_report);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _report.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
