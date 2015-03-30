using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Admin
{
	public partial class UserManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.User _user;

		public string SaveUser(Model.User user)
		{
			var mgr = new DataAccessLayer.Admin.UserManager();
			return mgr.SaveUser(user.ToModel());
		}

		public void DeleteUser(string soid)
		{
			var mgr = new DataAccessLayer.Admin.UserManager();
			mgr.DeleteUser(soid);
		}

		public Model.User GetUser(string soid)
		{
			var mgr = new DataAccessLayer.Admin.UserManager();
			return new Model.User(mgr.GetUser(soid));
		}

		public Model.User GetUserFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Admin.UserManager();
			var user = mgr.GetUserFromSqlId(id);
			if (user == null)
				return null;
			return new Model.User(user);
		}

		public IEnumerable<Model.User> GetUserList()
		{
			var mgr = new DataAccessLayer.Admin.UserManager();
			foreach (var user in mgr.GetUserList())
				yield return new Model.User(user);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Admin.UserManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_user = GetUser(_fieldBits.Last());
			if (_user == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "UserName": _changed = _user.UserName != _data; _user.UserName = _data; break;
				case "Password": _changed = _user.Password != _data; _user.Password = _data; break;
				case "ScreenName": _changed = _user.ScreenName != _data; _user.ScreenName = _data; break;
				case "EmailAddress": _changed = _user.EmailAddress != _data; _user.EmailAddress = _data; break;
			}
			SaveUser(_user);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _user.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
