using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Analytics
{
	public partial class AccountLoginManager
	{
		public string SaveAccountLogin(Model.AccountLogin accountLogin)
		{
			var mgr = new ServiceLayer.Analytics.AccountLoginManager();
			return mgr.SaveAccountLogin(accountLogin.ToModel());
		}

		public void DeleteAccountLogin(string soid)
		{
			var mgr = new ServiceLayer.Analytics.AccountLoginManager();
			mgr.DeleteAccountLogin(soid);
		}

		public Model.AccountLogin GetAccountLogin(string soid)
		{
			var mgr = new ServiceLayer.Analytics.AccountLoginManager();
			return new Model.AccountLogin(mgr.GetAccountLogin(soid));
		}

		public IEnumerable<Model.AccountLogin> GetAccountLoginList()
		{
			var mgr = new ServiceLayer.Analytics.AccountLoginManager();
			foreach (var accountLogin in mgr.GetAccountLoginList())
				yield return new Model.AccountLogin(accountLogin);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Analytics.AccountLoginManager();
			return mgr.Update(fieldName, data);
		}
	}
}
