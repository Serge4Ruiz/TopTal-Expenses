using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class User : BaseDocument
	{
		public const string FIELD_USERNAME = "UserName";
		public const string FIELD_PASSWORD = "Password";
		public const string FIELD_SCREENNAME = "ScreenName";
		public const string FIELD_EMAILADDRESS = "EmailAddress";

		public string UserName { set; get; }
		public string Password { set; get; }
		public string ScreenName { set; get; }
		public string EmailAddress { set; get; }

		public User()
			: base()
		{
		}
	}
}
