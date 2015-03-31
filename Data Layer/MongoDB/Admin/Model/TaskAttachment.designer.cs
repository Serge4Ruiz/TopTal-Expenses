using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class TaskAttachment : BaseObject
	{
		public const string FIELD_FILENAME = "FileName";
		public const string FIELD_SIZE = "Size";
		public const string FIELD_REFERENCE = "Reference";
		public const string FIELD_POSTEDBYSOID = "PostedBySoid";
		public const string FIELD_POSTEDBYNAME = "PostedByName";

		public string FileName { set; get; }
		public int Size { set; get; }
		public Guid Reference { set; get; }
		public string PostedBySoid { set; get; }
		public string PostedByName { set; get; }

		public TaskAttachment()
			: base()
		{
		}
	}
}
