using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class TaskComment : BaseObject
	{
		public const string FIELD_AUTHORSOID = "AuthorSoid";
		public const string FIELD_AUTHORNAME = "AuthorName";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_CONTENT = "Content";

		public string AuthorSoid { set; get; }
		public string AuthorName { set; get; }
		public DateTime CreatedOn { set; get; }
		public string Content { set; get; }

		public TaskComment()
			: base()
		{
		}
	}
}
