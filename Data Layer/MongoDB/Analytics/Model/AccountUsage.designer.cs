using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Analytics
{
	[BsonIgnoreExtraElements]
	public partial class AccountUsage : BaseDocument
	{
		public const string FIELD_MEMBERNAME = "MemberName";
		public const string FIELD_MEMBERSOID = "MemberSoid";
		public const string FIELD_CALLEDON = "CalledOn";
		public const string FIELD_URL = "URL";

		public string MemberName { set; get; }
		public string MemberSoid { set; get; }
		public DateTime CalledOn { set; get; }
		public string URL { set; get; }

		public AccountUsage()
			: base()
		{
		}
	}
}
