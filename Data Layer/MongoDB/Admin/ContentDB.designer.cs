using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	public partial class ContentDB : DocumentList<Content>
	{
		public ContentDB()
			: base(new Content())
		{
		}

		public static string SaveContent(Content content)
		{
			var db = new ContentDB();
			db.Save(content);
			return content.Id.ToString();
		}

		public static Content GetContent(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetContent(oid);
			return null;
		}

		public static Content GetContentFromSqlId(int id)
		{
			var db = new ContentDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static Content GetContent(ObjectId oid)
		{
			var db = new ContentDB();
			return db.GetDocument(oid);
		}
	}
}
