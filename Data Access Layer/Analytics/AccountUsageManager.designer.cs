using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Analytics;

namespace TopTal.Expenses.DataAccessLayer.Analytics
{
	public partial class AccountUsageManager
	{
		public string SaveAccountUsage(Model.AccountUsage accountUsage)
		{
			return AccountUsageDB.SaveAccountUsage(accountUsage.ToModel());
		}

		public void DeleteAccountUsage(string soid)
		{
			var db = new AccountUsageDB();
			db.Delete(soid);
		}

		public Model.AccountUsage GetAccountUsage(string soid)
		{
			return new Model.AccountUsage(AccountUsageDB.GetAccountUsage(soid));
		}

		public Model.AccountUsage GetAccountUsageFromSqlId(int id)
		{
			var accountUsage = AccountUsageDB.GetAccountUsageFromSqlId(id);
			if (accountUsage == null)
				return null;
			return new Model.AccountUsage(accountUsage);
		}

		public IEnumerable<Model.AccountUsage> GetAccountUsageList()
		{
			var db = new AccountUsageDB();
			foreach (var accountUsage in db.GetDocuments())
				yield return new Model.AccountUsage(accountUsage);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Analytics.AccountUsageDB();
			mgr.Clear();
		}
	}
}
