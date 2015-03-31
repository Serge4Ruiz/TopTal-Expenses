using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.DataAccessLayer.Admin;

namespace TopTal.Expenses.ServiceLayer.Admin.Model
{
	public partial class TaskComment : IModel
	{
		public const string FIELD_AUTHORSOID = "AuthorSoid";
		public const string FIELD_AUTHORNAME = "AuthorName";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_CONTENT = "Content";

		public enum Fields
		{
			Soid,
			SqlId,
			AuthorSoid,
			AuthorName,
			CreatedOn,
			Content,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string AuthorSoid { set; get; }
		public string AuthorName { set; get; }
		public DateTime CreatedOn { set; get; }
		public string Content { set; get; }

		public TaskComment()
		{
		}

		public TaskComment(DataAccessLayer.Admin.Model.TaskComment taskComment)
		{
			if (taskComment == null)
				return;
			Soid = taskComment.Soid;
			SqlId = taskComment.SqlId;
			AuthorSoid = taskComment.AuthorSoid;
			AuthorName = taskComment.AuthorName;
			CreatedOn = taskComment.CreatedOn;
			Content = taskComment.Content;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "AuthorSoid": return AuthorSoid;
				case "AuthorName": return AuthorName;
				case "CreatedOn": return CreatedOn;
				case "Content": return Content;

				default: return null;
			}
		}

		public DataAccessLayer.Admin.Model.TaskComment ToModel()
		{
			var taskComment = new DataAccessLayer.Admin.Model.TaskComment();
			taskComment.Soid = Soid;
			taskComment.SqlId = SqlId;
			taskComment.AuthorSoid = AuthorSoid;
			taskComment.AuthorName = AuthorName;
			taskComment.CreatedOn = CreatedOn;
			taskComment.Content = Content;

			return taskComment;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("AuthorSoid");
				fieldNames.Add("AuthorName");
				fieldNames.Add("CreatedOn");
				fieldNames.Add("Content");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 12;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("AuthorSoid ".PadRight(fieldNameMaxWidth, '.') + " " + AuthorSoid);
			sb.AppendLine("AuthorName ".PadRight(fieldNameMaxWidth, '.') + " " + AuthorName);
			sb.AppendLine("CreatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + CreatedOn.ToString());
			sb.AppendLine("Content ".PadRight(fieldNameMaxWidth, '.') + " " + Content);

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">AuthorSoid [" + AuthorSoid + "]< ");
			sb.Append(">AuthorName [" + AuthorName + "]< ");
			sb.Append(">CreatedOn [" + CreatedOn.ToString() + "]< ");
			sb.Append(">Content [" + Content + "]< ");

			return sb.ToString();
		}
	}
}
