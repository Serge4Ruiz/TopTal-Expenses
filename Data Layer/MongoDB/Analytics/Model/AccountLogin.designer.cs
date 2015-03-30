using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Analytics
{
	[BsonIgnoreExtraElements]
	public partial class AccountLogin : BaseDocument
	{
		public const string FIELD_MEMBERNAME = "MemberName";
		public const string FIELD_MEMBERSOID = "MemberSoid";
		public const string FIELD_LOGGEDINON = "LoggedInOn";
		public const string FIELD_BROWSER = "Browser";
		public const string FIELD_LOGGEDOFFON = "LoggedOffOn";

		public string MemberName { set; get; }
		public string MemberSoid { set; get; }
		public DateTime LoggedInOn { set; get; }
		public string Browser { set; get; }
		public DateTime? LoggedOffOn { set; get; }

		public AccountLogin()
			: base()
		{
		}
	}
}
