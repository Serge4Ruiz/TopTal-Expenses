using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class ReportDefinition : BaseDocument
	{
		public const string FIELD_NAME = "Name";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_PATH = "Path";
		public const string FIELD_LASTRUNON = "LastRunOn";
		public const string FIELD_NEXTRUNON = "NextRunOn";

		public string Name { set; get; }
		public DateTime CreatedOn { set; get; }
		public string Path { set; get; }
		public DateTime? LastRunOn { set; get; }
		public DateTime? NextRunOn { set; get; }

		public ReportDefinition()
			: base()
		{
		}
	}
}
