using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.DataAccessLayer.Admin;

namespace TopTal.Expenses.ServiceLayer.Admin.Model
{
	public partial class TaskHistory : IModel
	{
		public const string FIELD_FIELDNAME = "FieldName";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_OLDVALUE = "OldValue";
		public const string FIELD_NEWVALUE = "NewValue";
		public const string FIELD_CHANGEBYSOID = "ChangeBySoid";
		public const string FIELD_CHANGEBYNAME = "ChangeByName";

		public enum Fields
		{
			Soid,
			SqlId,
			FieldName,
			CreatedOn,
			OldValue,
			NewValue,
			ChangeBySoid,
			ChangeByName,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string FieldName { set; get; }
		public DateTime CreatedOn { set; get; }
		public string OldValue { set; get; }
		public string NewValue { set; get; }
		public string ChangeBySoid { set; get; }
		public string ChangeByName { set; get; }

		public TaskHistory()
		{
		}

		public TaskHistory(DataAccessLayer.Admin.Model.TaskHistory taskHistory)
		{
			if (taskHistory == null)
				return;
			Soid = taskHistory.Soid;
			SqlId = taskHistory.SqlId;
			FieldName = taskHistory.FieldName;
			CreatedOn = taskHistory.CreatedOn;
			OldValue = taskHistory.OldValue;
			NewValue = taskHistory.NewValue;
			ChangeBySoid = taskHistory.ChangeBySoid;
			ChangeByName = taskHistory.ChangeByName;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "FieldName": return FieldName;
				case "CreatedOn": return CreatedOn;
				case "OldValue": return OldValue;
				case "NewValue": return NewValue;
				case "ChangeBySoid": return ChangeBySoid;
				case "ChangeByName": return ChangeByName;

				default: return null;
			}
		}

		public DataAccessLayer.Admin.Model.TaskHistory ToModel()
		{
			var taskHistory = new DataAccessLayer.Admin.Model.TaskHistory();
			taskHistory.Soid = Soid;
			taskHistory.SqlId = SqlId;
			taskHistory.FieldName = FieldName;
			taskHistory.CreatedOn = CreatedOn;
			taskHistory.OldValue = OldValue;
			taskHistory.NewValue = NewValue;
			taskHistory.ChangeBySoid = ChangeBySoid;
			taskHistory.ChangeByName = ChangeByName;

			return taskHistory;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("FieldName");
				fieldNames.Add("CreatedOn");
				fieldNames.Add("OldValue");
				fieldNames.Add("NewValue");
				fieldNames.Add("ChangeBySoid");
				fieldNames.Add("ChangeByName");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 14;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("FieldName ".PadRight(fieldNameMaxWidth, '.') + " " + FieldName);
			sb.AppendLine("CreatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + CreatedOn.ToString());
			sb.AppendLine("OldValue ".PadRight(fieldNameMaxWidth, '.') + " " + OldValue);
			sb.AppendLine("NewValue ".PadRight(fieldNameMaxWidth, '.') + " " + NewValue);
			sb.AppendLine("ChangeBySoid ".PadRight(fieldNameMaxWidth, '.') + " " + ChangeBySoid);
			sb.AppendLine("ChangeByName ".PadRight(fieldNameMaxWidth, '.') + " " + ChangeByName);

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">FieldName [" + FieldName + "]< ");
			sb.Append(">CreatedOn [" + CreatedOn.ToString() + "]< ");
			sb.Append(">OldValue [" + OldValue + "]< ");
			sb.Append(">NewValue [" + NewValue + "]< ");
			sb.Append(">ChangeBySoid [" + ChangeBySoid + "]< ");
			sb.Append(">ChangeByName [" + ChangeByName + "]< ");

			return sb.ToString();
		}
	}
}
