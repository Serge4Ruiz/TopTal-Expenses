using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin
{
	public partial class UserManager
	{
		public string SaveUser(Model.User user)
		{
			return UserDB.SaveUser(user.ToModel());
		}

		public void DeleteUser(string soid)
		{
			var db = new UserDB();
			db.Delete(soid);
		}

		public Model.User GetUser(string soid)
		{
			return new Model.User(UserDB.GetUser(soid));
		}

		public Model.User GetUserFromSqlId(int id)
		{
			var user = UserDB.GetUserFromSqlId(id);
			if (user == null)
				return null;
			return new Model.User(user);
		}

		public IEnumerable<Model.User> GetUserList()
		{
			var db = new UserDB();
			foreach (var user in db.GetDocuments())
				yield return new Model.User(user);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Admin.UserDB();
			mgr.Clear();
		}
	}
}
