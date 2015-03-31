using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Admin
{
	public partial class TaskManager
	{
		public string SaveTask(Model.Task task)
		{
			var mgr = new ServiceLayer.Admin.TaskManager();
			return mgr.SaveTask(task.ToModel());
		}

		public void DeleteTask(string soid)
		{
			var mgr = new ServiceLayer.Admin.TaskManager();
			mgr.DeleteTask(soid);
		}

		public Model.Task GetTask(string soid)
		{
			var mgr = new ServiceLayer.Admin.TaskManager();
			return new Model.Task(mgr.GetTask(soid));
		}

		public IEnumerable<Model.Task> GetTaskList()
		{
			var mgr = new ServiceLayer.Admin.TaskManager();
			foreach (var task in mgr.GetTaskList())
				yield return new Model.Task(task);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Admin.TaskManager();
			return mgr.Update(fieldName, data);
		}
	}
}
