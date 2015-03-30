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
	public partial class ReportDefinition : IModel
	{
		public const string FIELD_NAME = "Name";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_PATH = "Path";
		public const string FIELD_LASTRUNON = "LastRunOn";
		public const string FIELD_NEXTRUNON = "NextRunOn";

		public enum Fields
		{
			Soid,
			SqlId,
			Name,
			CreatedOn,
			Path,
			LastRunOn,
			NextRunOn,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string Name { set; get; }
		public DateTime CreatedOn { set; get; }
		public string Path { set; get; }
		public DateTime? LastRunOn { set; get; }
		public DateTime? NextRunOn { set; get; }

		public ReportDefinition() { }

		public ReportDefinition(DataLayer.MongoDB.Admin.ReportDefinition reportDefinition)
		{
			if (reportDefinition == null)
				return;
			Soid = reportDefinition.Id.ToString();
			SqlId = reportDefinition.SqlId;
			Name = reportDefinition.Name;
			CreatedOn = reportDefinition.CreatedOn;
			Path = reportDefinition.Path;
			LastRunOn = reportDefinition.LastRunOn;
			NextRunOn = reportDefinition.NextRunOn;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "Name": return Name;
				case "CreatedOn": return CreatedOn;
				case "Path": return Path;
				case "LastRunOn": return LastRunOn;
				case "NextRunOn": return NextRunOn;

				default: return null;
			}
		}

		public DataLayer.MongoDB.Admin.ReportDefinition ToModel()
		{
			var reportDefinition = new DataLayer.MongoDB.Admin.ReportDefinition();
			if (!Soid.IsNullOrEmpty())
				reportDefinition.ResetId(Soid);
			reportDefinition.SqlId = SqlId;
			reportDefinition.Name = Name;
			reportDefinition.CreatedOn = CreatedOn;
			reportDefinition.Path = Path;
			reportDefinition.LastRunOn = LastRunOn;
			reportDefinition.NextRunOn = NextRunOn;

			return reportDefinition;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("Name");
				fieldNames.Add("CreatedOn");
				fieldNames.Add("Path");
				fieldNames.Add("LastRunOn");
				fieldNames.Add("NextRunOn");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 11;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("Name ".PadRight(fieldNameMaxWidth, '.') + " " + Name);
			sb.AppendLine("CreatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + CreatedOn.ToString());
			sb.AppendLine("Path ".PadRight(fieldNameMaxWidth, '.') + " " + Path);
			sb.AppendLine("LastRunOn ".PadRight(fieldNameMaxWidth, '.') + " " + LastRunOn.ToString());
			sb.AppendLine("NextRunOn ".PadRight(fieldNameMaxWidth, '.') + " " + NextRunOn.ToString());

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">Name [" + Name + "]< ");
			sb.Append(">CreatedOn [" + CreatedOn.ToString() + "]< ");
			sb.Append(">Path [" + Path + "]< ");
			sb.Append(">LastRunOn [" + LastRunOn.ToString() + "]< ");
			sb.Append(">NextRunOn [" + NextRunOn.ToString() + "]< ");

			return sb.ToString();
		}
	}
}
