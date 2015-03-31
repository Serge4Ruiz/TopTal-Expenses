using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin
{
	public partial class TaskManager
	{
		public string SaveTask(Model.Task task)
		{
			return TaskDB.SaveTask(task.ToModel());
		}

		public void DeleteTask(string soid)
		{
			var db = new TaskDB();
			db.Delete(soid);
		}

		public Model.Task GetTask(string soid)
		{
			return new Model.Task(TaskDB.GetTask(soid));
		}

		public Model.Task GetTaskFromSqlId(int id)
		{
			var task = TaskDB.GetTaskFromSqlId(id);
			if (task == null)
				return null;
			return new Model.Task(task);
		}

		public IEnumerable<Model.Task> GetTaskList()
		{
			var db = new TaskDB();
			foreach (var task in db.GetDocuments())
				yield return new Model.Task(task);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Admin.TaskDB();
			mgr.Clear();
		}
	}
}
