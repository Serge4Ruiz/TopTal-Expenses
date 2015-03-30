using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class Task : BaseDocument
	{
		public const string FIELD_ORIGINATORSOID = "OriginatorSoid";
		public const string FIELD_ORIGINATORNAME = "OriginatorName";
		public const string FIELD_ASSIGNEESOID = "AssigneeSoid";
		public const string FIELD_ASSIGNEENAME = "AssigneeName";
		public const string FIELD_STATUS = "Status";
		public const string FIELD_PRIORITY = "Priority";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_UPDATEDON = "UpdatedOn";
		public const string FIELD_DUEON = "DueOn";
		public const string FIELD_CATEGORY = "Category";
		public const string FIELD_TAGS = "Tags";
		public const string FIELD_SUBJECT = "Subject";
		public const string FIELD_DESCRIPTION = "Description";
		public const string FIELD_RESOLUTION = "Resolution";
		public const string FIELD_VERSIONFOUND = "VersionFound";
		public const string FIELD_VERSIONFIXED = "VersionFixed";
		public const string FIELD_COMMENTS = "Comments";
		public const string FIELD_HISTORY = "History";
		public const string FIELD_ATTCHMENTS = "Attchments";

		private List<TaskComment> _Comments;
		private List<TaskHistory> _History;
		private List<TaskAttachment> _Attchments;

		public string OriginatorSoid { set; get; }
		public string OriginatorName { set; get; }
		public string AssigneeSoid { set; get; }
		public string AssigneeName { set; get; }
		public string Status { set; get; }
		public int Priority { set; get; }
		public DateTime CreatedOn { set; get; }
		public DateTime UpdatedOn { set; get; }
		public DateTime? DueOn { set; get; }
		public string Category { set; get; }
		public string Tags { set; get; }
		public string Subject { set; get; }
		public string Description { set; get; }
		public string Resolution { set; get; }
		public string VersionFound { set; get; }
		public string VersionFixed { set; get; }
		public List<TaskComment> Comments { set { _Comments = value; } get { return _Comments ?? (_Comments = new List<TaskComment>()); } }
		public List<TaskHistory> History { set { _History = value; } get { return _History ?? (_History = new List<TaskHistory>()); } }
		public List<TaskAttachment> Attchments { set { _Attchments = value; } get { return _Attchments ?? (_Attchments = new List<TaskAttachment>()); } }

		public Task()
			: base()
		{
		}
	}
}
