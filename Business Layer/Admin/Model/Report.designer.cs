using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.ServiceLayer.Admin;

namespace TopTal.Expenses.BusinessLayer.Admin.Model
{
	public partial class Report : IModel
	{
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_REPORTTYPE = "ReportType";
		public const string FIELD_REPORTSOID = "ReportSoid";
		public const string FIELD_ORIGINATORNAME = "OriginatorName";
		public const string FIELD_ORIGINATORSOID = "OriginatorSoid";
		public const string FIELD_REPORTFULLNAME = "ReportFullName";
		public const string FIELD_RECORDCOUNT = "RecordCount";

		public enum Fields
		{
			Soid,
			SqlId,
			CreatedOn,
			ReportType,
			ReportSoid,
			OriginatorName,
			OriginatorSoid,
			ReportFullName,
			RecordCount,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public DateTime CreatedOn { set; get; }
		public string ReportType { set; get; }
		public string ReportSoid { set; get; }
		public string OriginatorName { set; get; }
		public string OriginatorSoid { set; get; }
		public string ReportFullName { set; get; }
		public int RecordCount { set; get; }

		public Report() {}

		public Report(ServiceLayer.Admin.Model.Report report)
		{
			if (report == null)
				return;
			Soid = report.Soid;
			SqlId = report.SqlId;
			CreatedOn = report.CreatedOn;
			ReportType = report.ReportType;
			ReportSoid = report.ReportSoid;
			OriginatorName = report.OriginatorName;
			OriginatorSoid = report.OriginatorSoid;
			ReportFullName = report.ReportFullName;
			RecordCount = report.RecordCount;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "CreatedOn": return CreatedOn;
				case "ReportType": return ReportType;
				case "ReportSoid": return ReportSoid;
				case "OriginatorName": return OriginatorName;
				case "OriginatorSoid": return OriginatorSoid;
				case "ReportFullName": return ReportFullName;
				case "RecordCount": return RecordCount;

				default: return null;
			}
		}

		public ServiceLayer.Admin.Model.Report ToModel()
		{
			var report = new ServiceLayer.Admin.Model.Report();
			report.Soid = Soid;
			report.SqlId = SqlId;
			report.CreatedOn = CreatedOn;
			report.ReportType = ReportType;
			report.ReportSoid = ReportSoid;
			report.OriginatorName = OriginatorName;
			report.OriginatorSoid = OriginatorSoid;
			report.ReportFullName = ReportFullName;
			report.RecordCount = RecordCount;

			return report;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("CreatedOn");
				fieldNames.Add("ReportType");
				fieldNames.Add("ReportSoid");
				fieldNames.Add("OriginatorName");
				fieldNames.Add("OriginatorSoid");
				fieldNames.Add("ReportFullName");
				fieldNames.Add("RecordCount");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 16;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("CreatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + CreatedOn.ToString());
			sb.AppendLine("ReportType ".PadRight(fieldNameMaxWidth, '.') + " " + ReportType);
			sb.AppendLine("ReportSoid ".PadRight(fieldNameMaxWidth, '.') + " " + ReportSoid);
			sb.AppendLine("OriginatorName ".PadRight(fieldNameMaxWidth, '.') + " " + OriginatorName);
			sb.AppendLine("OriginatorSoid ".PadRight(fieldNameMaxWidth, '.') + " " + OriginatorSoid);
			sb.AppendLine("ReportFullName ".PadRight(fieldNameMaxWidth, '.') + " " + ReportFullName);
			sb.AppendLine("RecordCount ".PadRight(fieldNameMaxWidth, '.') + " " + RecordCount.ToString());

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">CreatedOn [" + CreatedOn.ToString() + "]< ");
			sb.Append(">ReportType [" + ReportType + "]< ");
			sb.Append(">ReportSoid [" + ReportSoid + "]< ");
			sb.Append(">OriginatorName [" + OriginatorName + "]< ");
			sb.Append(">OriginatorSoid [" + OriginatorSoid + "]< ");
			sb.Append(">ReportFullName [" + ReportFullName + "]< ");
			sb.Append(">RecordCount [" + RecordCount.ToString() + "]< ");

			return sb.ToString();
		}
	}
}
