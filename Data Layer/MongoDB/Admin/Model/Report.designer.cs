using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class Report : BaseDocument
	{
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_REPORTTYPE = "ReportType";
		public const string FIELD_REPORTSOID = "ReportSoid";
		public const string FIELD_ORIGINATORNAME = "OriginatorName";
		public const string FIELD_ORIGINATORSOID = "OriginatorSoid";
		public const string FIELD_REPORTFULLNAME = "ReportFullName";
		public const string FIELD_RECORDCOUNT = "RecordCount";

		public DateTime CreatedOn { set; get; }
		public string ReportType { set; get; }
		public string ReportSoid { set; get; }
		public string OriginatorName { set; get; }
		public string OriginatorSoid { set; get; }
		public string ReportFullName { set; get; }
		public int RecordCount { set; get; }

		public Report()
			: base()
		{
		}
	}
}
