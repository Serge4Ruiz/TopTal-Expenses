using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	public partial class UserDB : DocumentList<User>
	{
		public UserDB()
			: base(new User())
		{
		}

		public static string SaveUser(User user)
		{
			var db = new UserDB();
			db.Save(user);
			return user.Id.ToString();
		}

		public static User GetUser(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetUser(oid);
			return null;
		}

		public static User GetUserFromSqlId(int id)
		{
			var db = new UserDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static User GetUser(ObjectId oid)
		{
			var db = new UserDB();
			return db.GetDocument(oid);
		}
	}
}
