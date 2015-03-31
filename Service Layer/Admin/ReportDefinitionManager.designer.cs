using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Admin
{
	public partial class ReportDefinitionManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.ReportDefinition _reportDefinition;

		public string SaveReportDefinition(Model.ReportDefinition reportDefinition)
		{
			var mgr = new DataAccessLayer.Admin.ReportDefinitionManager();
			return mgr.SaveReportDefinition(reportDefinition.ToModel());
		}

		public void DeleteReportDefinition(string soid)
		{
			var mgr = new DataAccessLayer.Admin.ReportDefinitionManager();
			mgr.DeleteReportDefinition(soid);
		}

		public Model.ReportDefinition GetReportDefinition(string soid)
		{
			var mgr = new DataAccessLayer.Admin.ReportDefinitionManager();
			return new Model.ReportDefinition(mgr.GetReportDefinition(soid));
		}

		public Model.ReportDefinition GetReportDefinitionFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Admin.ReportDefinitionManager();
			var reportDefinition = mgr.GetReportDefinitionFromSqlId(id);
			if (reportDefinition == null)
				return null;
			return new Model.ReportDefinition(reportDefinition);
		}

		public IEnumerable<Model.ReportDefinition> GetReportDefinitionList()
		{
			var mgr = new DataAccessLayer.Admin.ReportDefinitionManager();
			foreach (var reportDefinition in mgr.GetReportDefinitionList())
				yield return new Model.ReportDefinition(reportDefinition);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Admin.ReportDefinitionManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_reportDefinition = GetReportDefinition(_fieldBits.Last());
			if (_reportDefinition == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "Name": _changed = _reportDefinition.Name != _data; _reportDefinition.Name = _data; break;
				case "CreatedOn": DateTime dateCreatedOn = new DateTime(); if (DateTime.TryParse(_data, out dateCreatedOn)) { _changed = _reportDefinition.CreatedOn != dateCreatedOn; _reportDefinition.CreatedOn = dateCreatedOn; }; break;
				case "Path": _changed = _reportDefinition.Path != _data; _reportDefinition.Path = _data; break;
				case "LastRunOn": DateTime dateLastRunOn = new DateTime(); if (DateTime.TryParse(_data, out dateLastRunOn)) { _changed = _reportDefinition.LastRunOn != dateLastRunOn; _reportDefinition.LastRunOn = dateLastRunOn; }; break;
				case "NextRunOn": DateTime dateNextRunOn = new DateTime(); if (DateTime.TryParse(_data, out dateNextRunOn)) { _changed = _reportDefinition.NextRunOn != dateNextRunOn; _reportDefinition.NextRunOn = dateNextRunOn; }; break;
			}
			SaveReportDefinition(_reportDefinition);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _reportDefinition.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
