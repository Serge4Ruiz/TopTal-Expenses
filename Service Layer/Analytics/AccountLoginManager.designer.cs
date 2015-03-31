using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Analytics
{
	public partial class AccountLoginManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.AccountLogin _accountLogin;

		public string SaveAccountLogin(Model.AccountLogin accountLogin)
		{
			var mgr = new DataAccessLayer.Analytics.AccountLoginManager();
			return mgr.SaveAccountLogin(accountLogin.ToModel());
		}

		public void DeleteAccountLogin(string soid)
		{
			var mgr = new DataAccessLayer.Analytics.AccountLoginManager();
			mgr.DeleteAccountLogin(soid);
		}

		public Model.AccountLogin GetAccountLogin(string soid)
		{
			var mgr = new DataAccessLayer.Analytics.AccountLoginManager();
			return new Model.AccountLogin(mgr.GetAccountLogin(soid));
		}

		public Model.AccountLogin GetAccountLoginFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Analytics.AccountLoginManager();
			var accountLogin = mgr.GetAccountLoginFromSqlId(id);
			if (accountLogin == null)
				return null;
			return new Model.AccountLogin(accountLogin);
		}

		public IEnumerable<Model.AccountLogin> GetAccountLoginList()
		{
			var mgr = new DataAccessLayer.Analytics.AccountLoginManager();
			foreach (var accountLogin in mgr.GetAccountLoginList())
				yield return new Model.AccountLogin(accountLogin);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Analytics.AccountLoginManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_accountLogin = GetAccountLogin(_fieldBits.Last());
			if (_accountLogin == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "MemberName": _changed = _accountLogin.MemberName != _data; _accountLogin.MemberName = _data; break;
				case "MemberSoid": _changed = _accountLogin.MemberSoid != _data; _accountLogin.MemberSoid = _data; break;
				case "LoggedInOn": DateTime dateLoggedInOn = new DateTime(); if (DateTime.TryParse(_data, out dateLoggedInOn)) { _changed = _accountLogin.LoggedInOn != dateLoggedInOn; _accountLogin.LoggedInOn = dateLoggedInOn; }; break;
				case "Browser": _changed = _accountLogin.Browser != _data; _accountLogin.Browser = _data; break;
				case "LoggedOffOn": DateTime dateLoggedOffOn = new DateTime(); if (DateTime.TryParse(_data, out dateLoggedOffOn)) { _changed = _accountLogin.LoggedOffOn != dateLoggedOffOn; _accountLogin.LoggedOffOn = dateLoggedOffOn; }; break;
			}
			SaveAccountLogin(_accountLogin);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _accountLogin.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
