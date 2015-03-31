using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.ServiceLayer.Admin;

namespace TopTal.Expenses.BusinessLayer.Admin.Model
{
	public partial class Task : IModel
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

		public enum Fields
		{
			Soid,
			SqlId,
			OriginatorSoid,
			OriginatorName,
			AssigneeSoid,
			AssigneeName,
			Status,
			Priority,
			CreatedOn,
			UpdatedOn,
			DueOn,
			Category,
			Tags,
			Subject,
			Description,
			Resolution,
			VersionFound,
			VersionFixed,
			Comments,
			History,
			Attchments,
		}

		private List<TaskComment> _Comments;
		private List<TaskHistory> _History;
		private List<TaskAttachment> _Attchments;

		public string Soid { set; get; }
		public int SqlId { set; get; }
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

		public Task() {}

		public Task(ServiceLayer.Admin.Model.Task task)
		{
			if (task == null)
				return;
			Soid = task.Soid;
			SqlId = task.SqlId;
			OriginatorSoid = task.OriginatorSoid;
			OriginatorName = task.OriginatorName;
			AssigneeSoid = task.AssigneeSoid;
			AssigneeName = task.AssigneeName;
			Status = task.Status;
			Priority = task.Priority;
			CreatedOn = task.CreatedOn;
			UpdatedOn = task.UpdatedOn;
			DueOn = task.DueOn;
			Category = task.Category;
			Tags = task.Tags;
			Subject = task.Subject;
			Description = task.Description;
			Resolution = task.Resolution;
			VersionFound = task.VersionFound;
			VersionFixed = task.VersionFixed;
			foreach (var taskComment in task.Comments)
				Comments.Add(new TaskComment(taskComment));
			foreach (var taskHistory in task.History)
				History.Add(new TaskHistory(taskHistory));
			foreach (var taskAttachment in task.Attchments)
				Attchments.Add(new TaskAttachment(taskAttachment));
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "OriginatorSoid": return OriginatorSoid;
				case "OriginatorName": return OriginatorName;
				case "AssigneeSoid": return AssigneeSoid;
				case "AssigneeName": return AssigneeName;
				case "Status": return Status;
				case "Priority": return Priority;
				case "CreatedOn": return CreatedOn;
				case "UpdatedOn": return UpdatedOn;
				case "DueOn": return DueOn;
				case "Category": return Category;
				case "Tags": return Tags;
				case "Subject": return Subject;
				case "Description": return Description;
				case "Resolution": return Resolution;
				case "VersionFound": return VersionFound;
				case "VersionFixed": return VersionFixed;
				case "Comments": return Comments;
				case "History": return History;
				case "Attchments": return Attchments;

				default: return null;
			}
		}

		public ServiceLayer.Admin.Model.Task ToModel()
		{
			var task = new ServiceLayer.Admin.Model.Task();
			task.Soid = Soid;
			task.SqlId = SqlId;
			task.OriginatorSoid = OriginatorSoid;
			task.OriginatorName = OriginatorName;
			task.AssigneeSoid = AssigneeSoid;
			task.AssigneeName = AssigneeName;
			task.Status = Status;
			task.Priority = Priority;
			task.CreatedOn = CreatedOn;
			task.UpdatedOn = UpdatedOn;
			task.DueOn = DueOn;
			task.Category = Category;
			task.Tags = Tags;
			task.Subject = Subject;
			task.Description = Description;
			task.Resolution = Resolution;
			task.VersionFound = VersionFound;
			task.VersionFixed = VersionFixed;
			foreach (var taskComment in Comments)
				task.Comments.Add(taskComment.ToModel());
			foreach (var taskHistory in History)
				task.History.Add(taskHistory.ToModel());
			foreach (var taskAttachment in Attchments)
				task.Attchments.Add(taskAttachment.ToModel());

			return task;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("OriginatorSoid");
				fieldNames.Add("OriginatorName");
				fieldNames.Add("AssigneeSoid");
				fieldNames.Add("AssigneeName");
				fieldNames.Add("Status");
				fieldNames.Add("Priority");
				fieldNames.Add("CreatedOn");
				fieldNames.Add("UpdatedOn");
				fieldNames.Add("DueOn");
				fieldNames.Add("Category");
				fieldNames.Add("Tags");
				fieldNames.Add("Subject");
				fieldNames.Add("Description");
				fieldNames.Add("Resolution");
				fieldNames.Add("VersionFound");
				fieldNames.Add("VersionFixed");
				fieldNames.Add("Comments");
				fieldNames.Add("History");
				fieldNames.Add("Attchments");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 16;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("OriginatorSoid ".PadRight(fieldNameMaxWidth, '.') + " " + OriginatorSoid);
			sb.AppendLine("OriginatorName ".PadRight(fieldNameMaxWidth, '.') + " " + OriginatorName);
			sb.AppendLine("AssigneeSoid ".PadRight(fieldNameMaxWidth, '.') + " " + AssigneeSoid);
			sb.AppendLine("AssigneeName ".PadRight(fieldNameMaxWidth, '.') + " " + AssigneeName);
			sb.AppendLine("Status ".PadRight(fieldNameMaxWidth, '.') + " " + Status);
			sb.AppendLine("Priority ".PadRight(fieldNameMaxWidth, '.') + " " + Priority.ToString());
			sb.AppendLine("CreatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + CreatedOn.ToString());
			sb.AppendLine("UpdatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + UpdatedOn.ToString());
			sb.AppendLine("DueOn ".PadRight(fieldNameMaxWidth, '.') + " " + DueOn.ToString());
			sb.AppendLine("Category ".PadRight(fieldNameMaxWidth, '.') + " " + Category);
			sb.AppendLine("Tags ".PadRight(fieldNameMaxWidth, '.') + " " + Tags);
			sb.AppendLine("Subject ".PadRight(fieldNameMaxWidth, '.') + " " + Subject);
			sb.AppendLine("Description ".PadRight(fieldNameMaxWidth, '.') + " " + Description);
			sb.AppendLine("Resolution ".PadRight(fieldNameMaxWidth, '.') + " " + Resolution);
			sb.AppendLine("VersionFound ".PadRight(fieldNameMaxWidth, '.') + " " + VersionFound);
			sb.AppendLine("VersionFixed ".PadRight(fieldNameMaxWidth, '.') + " " + VersionFixed);
			sb.AppendLine("Comments ".PadRight(fieldNameMaxWidth, '.') + " " + Comments.Count() + " items");
			sb.AppendLine("History ".PadRight(fieldNameMaxWidth, '.') + " " + History.Count() + " items");
			sb.AppendLine("Attchments ".PadRight(fieldNameMaxWidth, '.') + " " + Attchments.Count() + " items");

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">OriginatorSoid [" + OriginatorSoid + "]< ");
			sb.Append(">OriginatorName [" + OriginatorName + "]< ");
			sb.Append(">AssigneeSoid [" + AssigneeSoid + "]< ");
			sb.Append(">AssigneeName [" + AssigneeName + "]< ");
			sb.Append(">Status [" + Status + "]< ");
			sb.Append(">Priority [" + Priority.ToString() + "]< ");
			sb.Append(">CreatedOn [" + CreatedOn.ToString() + "]< ");
			sb.Append(">UpdatedOn [" + UpdatedOn.ToString() + "]< ");
			sb.Append(">DueOn [" + DueOn.ToString() + "]< ");
			sb.Append(">Category [" + Category + "]< ");
			sb.Append(">Tags [" + Tags + "]< ");
			sb.Append(">Subject [" + Subject + "]< ");
			sb.Append(">Description [" + Description + "]< ");
			sb.Append(">Resolution [" + Resolution + "]< ");
			sb.Append(">VersionFound [" + VersionFound + "]< ");
			sb.Append(">VersionFixed [" + VersionFixed + "]< ");
			sb.Append(">Comments [" + Comments.Count() + " items]< ");
			sb.Append(">History [" + History.Count() + " items]< ");
			sb.Append(">Attchments [" + Attchments.Count() + " items]< ");

			return sb.ToString();
		}
	}
}
