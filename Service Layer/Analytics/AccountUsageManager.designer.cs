using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Analytics
{
	public partial class AccountUsageManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.AccountUsage _accountUsage;

		public string SaveAccountUsage(Model.AccountUsage accountUsage)
		{
			var mgr = new DataAccessLayer.Analytics.AccountUsageManager();
			return mgr.SaveAccountUsage(accountUsage.ToModel());
		}

		public void DeleteAccountUsage(string soid)
		{
			var mgr = new DataAccessLayer.Analytics.AccountUsageManager();
			mgr.DeleteAccountUsage(soid);
		}

		public Model.AccountUsage GetAccountUsage(string soid)
		{
			var mgr = new DataAccessLayer.Analytics.AccountUsageManager();
			return new Model.AccountUsage(mgr.GetAccountUsage(soid));
		}

		public Model.AccountUsage GetAccountUsageFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Analytics.AccountUsageManager();
			var accountUsage = mgr.GetAccountUsageFromSqlId(id);
			if (accountUsage == null)
				return null;
			return new Model.AccountUsage(accountUsage);
		}

		public IEnumerable<Model.AccountUsage> GetAccountUsageList()
		{
			var mgr = new DataAccessLayer.Analytics.AccountUsageManager();
			foreach (var accountUsage in mgr.GetAccountUsageList())
				yield return new Model.AccountUsage(accountUsage);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Analytics.AccountUsageManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_accountUsage = GetAccountUsage(_fieldBits.Last());
			if (_accountUsage == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "MemberName": _changed = _accountUsage.MemberName != _data; _accountUsage.MemberName = _data; break;
				case "MemberSoid": _changed = _accountUsage.MemberSoid != _data; _accountUsage.MemberSoid = _data; break;
				case "CalledOn": DateTime dateCalledOn = new DateTime(); if (DateTime.TryParse(_data, out dateCalledOn)) { _changed = _accountUsage.CalledOn != dateCalledOn; _accountUsage.CalledOn = dateCalledOn; }; break;
				case "URL": _changed = _accountUsage.URL != _data; _accountUsage.URL = _data; break;
			}
			SaveAccountUsage(_accountUsage);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _accountUsage.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
