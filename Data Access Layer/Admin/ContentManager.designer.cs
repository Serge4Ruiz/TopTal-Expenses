using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin
{
	public partial class ContentManager
	{
		public string SaveContent(Model.Content content)
		{
			return ContentDB.SaveContent(content.ToModel());
		}

		public void DeleteContent(string soid)
		{
			var db = new ContentDB();
			db.Delete(soid);
		}

		public Model.Content GetContent(string soid)
		{
			return new Model.Content(ContentDB.GetContent(soid));
		}

		public Model.Content GetContentFromSqlId(int id)
		{
			var content = ContentDB.GetContentFromSqlId(id);
			if (content == null)
				return null;
			return new Model.Content(content);
		}

		public IEnumerable<Model.Content> GetContentList()
		{
			var db = new ContentDB();
			foreach (var content in db.GetDocuments())
				yield return new Model.Content(content);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Admin.ContentDB();
			mgr.Clear();
		}
	}
}
