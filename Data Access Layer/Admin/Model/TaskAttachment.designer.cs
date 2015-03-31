using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using LC.Core.Engine.Extensions;
using MongoDB.Bson;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin.Model
{
	public partial class TaskAttachment : IModel
	{
		public const string FIELD_FILENAME = "FileName";
		public const string FIELD_SIZE = "Size";
		public const string FIELD_REFERENCE = "Reference";
		public const string FIELD_POSTEDBYSOID = "PostedBySoid";
		public const string FIELD_POSTEDBYNAME = "PostedByName";

		public enum Fields
		{
			Soid,
			SqlId,
			FileName,
			Size,
			Reference,
			PostedBySoid,
			PostedByName,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string FileName { set; get; }
		public int Size { set; get; }
		public Guid Reference { set; get; }
		public string PostedBySoid { set; get; }
		public string PostedByName { set; get; }

		public TaskAttachment() { }

		public TaskAttachment(DataLayer.MongoDB.Admin.TaskAttachment taskAttachment)
		{
			if (taskAttachment == null)
				return;
			Soid = taskAttachment.Id.ToString();
			SqlId = taskAttachment.SqlId;
			FileName = taskAttachment.FileName;
			Size = taskAttachment.Size;
			Reference = taskAttachment.Reference;
			PostedBySoid = taskAttachment.PostedBySoid;
			PostedByName = taskAttachment.PostedByName;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "FileName": return FileName;
				case "Size": return Size;
				case "Reference": return Reference;
				case "PostedBySoid": return PostedBySoid;
				case "PostedByName": return PostedByName;

				default: return null;
			}
		}

		public DataLayer.MongoDB.Admin.TaskAttachment ToModel()
		{
			var taskAttachment = new DataLayer.MongoDB.Admin.TaskAttachment();
			if (!Soid.IsNullOrEmpty())
				taskAttachment.ResetId(Soid);
			taskAttachment.SqlId = SqlId;
			taskAttachment.FileName = FileName;
			taskAttachment.Size = Size;
			taskAttachment.Reference = Reference;
			taskAttachment.PostedBySoid = PostedBySoid;
			taskAttachment.PostedByName = PostedByName;

			return taskAttachment;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("FileName");
				fieldNames.Add("Size");
				fieldNames.Add("Reference");
				fieldNames.Add("PostedBySoid");
				fieldNames.Add("PostedByName");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 14;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("FileName ".PadRight(fieldNameMaxWidth, '.') + " " + FileName);
			sb.AppendLine("Size ".PadRight(fieldNameMaxWidth, '.') + " " + Size.ToString());
			sb.AppendLine("Reference ".PadRight(fieldNameMaxWidth, '.') + " " + Reference.ToString());
			sb.AppendLine("PostedBySoid ".PadRight(fieldNameMaxWidth, '.') + " " + PostedBySoid);
			sb.AppendLine("PostedByName ".PadRight(fieldNameMaxWidth, '.') + " " + PostedByName);

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">FileName [" + FileName + "]< ");
			sb.Append(">Size [" + Size.ToString() + "]< ");
			sb.Append(">Reference [" + Reference.ToString() + "]< ");
			sb.Append(">PostedBySoid [" + PostedBySoid + "]< ");
			sb.Append(">PostedByName [" + PostedByName + "]< ");

			return sb.ToString();
		}
	}
}
