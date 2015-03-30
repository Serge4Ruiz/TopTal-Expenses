using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Membership
{
	[BsonIgnoreExtraElements]
	public partial class MemberReference : BaseObject
	{
		public MemberReference()
			: base()
		{
		}
	}
}
