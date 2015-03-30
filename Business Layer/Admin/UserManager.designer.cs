using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Admin
{
	public partial class UserManager
	{
		public string SaveUser(Model.User user)
		{
			var mgr = new ServiceLayer.Admin.UserManager();
			return mgr.SaveUser(user.ToModel());
		}

		public void DeleteUser(string soid)
		{
			var mgr = new ServiceLayer.Admin.UserManager();
			mgr.DeleteUser(soid);
		}

		public Model.User GetUser(string soid)
		{
			var mgr = new ServiceLayer.Admin.UserManager();
			return new Model.User(mgr.GetUser(soid));
		}

		public IEnumerable<Model.User> GetUserList()
		{
			var mgr = new ServiceLayer.Admin.UserManager();
			foreach (var user in mgr.GetUserList())
				yield return new Model.User(user);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Admin.UserManager();
			return mgr.Update(fieldName, data);
		}
	}
}
