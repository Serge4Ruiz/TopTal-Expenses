using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Admin
{
	public partial class TaskManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.Task _task;

		public string SaveTask(Model.Task task)
		{
			var mgr = new DataAccessLayer.Admin.TaskManager();
			return mgr.SaveTask(task.ToModel());
		}

		public void DeleteTask(string soid)
		{
			var mgr = new DataAccessLayer.Admin.TaskManager();
			mgr.DeleteTask(soid);
		}

		public Model.Task GetTask(string soid)
		{
			var mgr = new DataAccessLayer.Admin.TaskManager();
			return new Model.Task(mgr.GetTask(soid));
		}

		public Model.Task GetTaskFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Admin.TaskManager();
			var task = mgr.GetTaskFromSqlId(id);
			if (task == null)
				return null;
			return new Model.Task(task);
		}

		public IEnumerable<Model.Task> GetTaskList()
		{
			var mgr = new DataAccessLayer.Admin.TaskManager();
			foreach (var task in mgr.GetTaskList())
				yield return new Model.Task(task);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Admin.TaskManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_task = GetTask(_fieldBits.Last());
			if (_task == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "OriginatorSoid": _changed = _task.OriginatorSoid != _data; _task.OriginatorSoid = _data; break;
				case "OriginatorName": _changed = _task.OriginatorName != _data; _task.OriginatorName = _data; break;
				case "AssigneeSoid": _changed = _task.AssigneeSoid != _data; _task.AssigneeSoid = _data; break;
				case "AssigneeName": _changed = _task.AssigneeName != _data; _task.AssigneeName = _data; break;
				case "Status": _changed = _task.Status != _data; _task.Status = _data; break;
				case "Priority": int iPriority = 0; if (int.TryParse(_data, out iPriority)) { _changed = _task.Priority != iPriority; _task.Priority = iPriority; }; break;
				case "CreatedOn": DateTime dateCreatedOn = new DateTime(); if (DateTime.TryParse(_data, out dateCreatedOn)) { _changed = _task.CreatedOn != dateCreatedOn; _task.CreatedOn = dateCreatedOn; }; break;
				case "UpdatedOn": DateTime dateUpdatedOn = new DateTime(); if (DateTime.TryParse(_data, out dateUpdatedOn)) { _changed = _task.UpdatedOn != dateUpdatedOn; _task.UpdatedOn = dateUpdatedOn; }; break;
				case "DueOn": DateTime dateDueOn = new DateTime(); if (DateTime.TryParse(_data, out dateDueOn)) { _changed = _task.DueOn != dateDueOn; _task.DueOn = dateDueOn; }; break;
				case "Category": _changed = _task.Category != _data; _task.Category = _data; break;
				case "Tags": _changed = _task.Tags != _data; _task.Tags = _data; break;
				case "Subject": _changed = _task.Subject != _data; _task.Subject = _data; break;
				case "Description": _changed = _task.Description != _data; _task.Description = _data; break;
				case "Resolution": _changed = _task.Resolution != _data; _task.Resolution = _data; break;
				case "VersionFound": _changed = _task.VersionFound != _data; _task.VersionFound = _data; break;
				case "VersionFixed": _changed = _task.VersionFixed != _data; _task.VersionFixed = _data; break;
			}
			SaveTask(_task);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _task.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
