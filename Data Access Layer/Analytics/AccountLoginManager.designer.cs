using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Analytics;

namespace TopTal.Expenses.DataAccessLayer.Analytics
{
	public partial class AccountLoginManager
	{
		public string SaveAccountLogin(Model.AccountLogin accountLogin)
		{
			return AccountLoginDB.SaveAccountLogin(accountLogin.ToModel());
		}

		public void DeleteAccountLogin(string soid)
		{
			var db = new AccountLoginDB();
			db.Delete(soid);
		}

		public Model.AccountLogin GetAccountLogin(string soid)
		{
			return new Model.AccountLogin(AccountLoginDB.GetAccountLogin(soid));
		}

		public Model.AccountLogin GetAccountLoginFromSqlId(int id)
		{
			var accountLogin = AccountLoginDB.GetAccountLoginFromSqlId(id);
			if (accountLogin == null)
				return null;
			return new Model.AccountLogin(accountLogin);
		}

		public IEnumerable<Model.AccountLogin> GetAccountLoginList()
		{
			var db = new AccountLoginDB();
			foreach (var accountLogin in db.GetDocuments())
				yield return new Model.AccountLogin(accountLogin);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Analytics.AccountLoginDB();
			mgr.Clear();
		}
	}
}
