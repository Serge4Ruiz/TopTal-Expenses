using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Analytics
{
	public partial class AccountLoginDB : DocumentList<AccountLogin>
	{
		public AccountLoginDB()
			: base(new AccountLogin())
		{
		}

		public static string SaveAccountLogin(AccountLogin accountLogin)
		{
			var db = new AccountLoginDB();
			db.Save(accountLogin);
			return accountLogin.Id.ToString();
		}

		public static AccountLogin GetAccountLogin(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetAccountLogin(oid);
			return null;
		}

		public static AccountLogin GetAccountLoginFromSqlId(int id)
		{
			var db = new AccountLoginDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static AccountLogin GetAccountLogin(ObjectId oid)
		{
			var db = new AccountLoginDB();
			return db.GetDocument(oid);
		}
	}
}
