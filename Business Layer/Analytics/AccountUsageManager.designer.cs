using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Analytics
{
	public partial class AccountUsageManager
	{
		public string SaveAccountUsage(Model.AccountUsage accountUsage)
		{
			var mgr = new ServiceLayer.Analytics.AccountUsageManager();
			return mgr.SaveAccountUsage(accountUsage.ToModel());
		}

		public void DeleteAccountUsage(string soid)
		{
			var mgr = new ServiceLayer.Analytics.AccountUsageManager();
			mgr.DeleteAccountUsage(soid);
		}

		public Model.AccountUsage GetAccountUsage(string soid)
		{
			var mgr = new ServiceLayer.Analytics.AccountUsageManager();
			return new Model.AccountUsage(mgr.GetAccountUsage(soid));
		}

		public IEnumerable<Model.AccountUsage> GetAccountUsageList()
		{
			var mgr = new ServiceLayer.Analytics.AccountUsageManager();
			foreach (var accountUsage in mgr.GetAccountUsageList())
				yield return new Model.AccountUsage(accountUsage);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Analytics.AccountUsageManager();
			return mgr.Update(fieldName, data);
		}
	}
}
