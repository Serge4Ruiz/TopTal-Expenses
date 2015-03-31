using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class TaskHistory : BaseObject
	{
		public const string FIELD_FIELDNAME = "FieldName";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_OLDVALUE = "OldValue";
		public const string FIELD_NEWVALUE = "NewValue";
		public const string FIELD_CHANGEBYSOID = "ChangeBySoid";
		public const string FIELD_CHANGEBYNAME = "ChangeByName";

		public string FieldName { set; get; }
		public DateTime CreatedOn { set; get; }
		public string OldValue { set; get; }
		public string NewValue { set; get; }
		public string ChangeBySoid { set; get; }
		public string ChangeByName { set; get; }

		public TaskHistory()
			: base()
		{
		}
	}
}
