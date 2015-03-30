using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	public partial class TaskDB : DocumentList<Task>
	{
		public TaskDB()
			: base(new Task())
		{
		}

		public static string SaveTask(Task task)
		{
			var db = new TaskDB();
			db.Save(task);
			return task.Id.ToString();
		}

		public static Task GetTask(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetTask(oid);
			return null;
		}

		public static Task GetTaskFromSqlId(int id)
		{
			var db = new TaskDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static Task GetTask(ObjectId oid)
		{
			var db = new TaskDB();
			return db.GetDocument(oid);
		}
	}
}
