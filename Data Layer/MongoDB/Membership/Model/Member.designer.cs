using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Membership
{
	[BsonIgnoreExtraElements]
	public partial class Member : BaseDocument
	{
		public const string FIELD_SCREENNAME = "ScreenName";
		public const string FIELD_EMAILADDRESS = "EmailAddress";
		public const string FIELD_NAMEFIRST = "NameFirst";
		public const string FIELD_NAMELAST = "NameLast";
		public const string FIELD_NAMEFULL = "NameFull";
		public const string FIELD_USERNAME = "UserName";
		public const string FIELD_PASSWORD = "Password";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_REFERENCE = "Reference";
		public const string FIELD_VERIFIED = "Verified";
		public const string FIELD_EXPENSES = "Expenses";

		private List<Expense> _Expenses;

		public string ScreenName { set; get; }
		public string EmailAddress { set; get; }
		public string NameFirst { set; get; }
		public string NameLast { set; get; }
		public string NameFull { set; get; }
		public string UserName { set; get; }
		public string Password { set; get; }
		public DateTime CreatedOn { set; get; }
		public Guid Reference { set; get; }
		public bool Verified { set; get; }
		public List<Expense> Expenses { set { _Expenses = value; } get { return _Expenses ?? (_Expenses = new List<Expense>()); } }

		public Member()
			: base()
		{
		}
	}
}
