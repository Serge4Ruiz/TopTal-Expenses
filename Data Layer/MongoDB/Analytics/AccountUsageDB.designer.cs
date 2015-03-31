using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Analytics
{
	public partial class AccountUsageDB : DocumentList<AccountUsage>
	{
		public AccountUsageDB()
			: base(new AccountUsage())
		{
		}

		public static string SaveAccountUsage(AccountUsage accountUsage)
		{
			var db = new AccountUsageDB();
			db.Save(accountUsage);
			return accountUsage.Id.ToString();
		}

		public static AccountUsage GetAccountUsage(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetAccountUsage(oid);
			return null;
		}

		public static AccountUsage GetAccountUsageFromSqlId(int id)
		{
			var db = new AccountUsageDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static AccountUsage GetAccountUsage(ObjectId oid)
		{
			var db = new AccountUsageDB();
			return db.GetDocument(oid);
		}
	}
}
