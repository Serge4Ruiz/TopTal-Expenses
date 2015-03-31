using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using LC.Core.Engine.Extensions;
using MongoDB.Bson;
using TopTal.Expenses.DataLayer.MongoDB.Analytics;

namespace TopTal.Expenses.DataAccessLayer.Analytics.Model
{
	public partial class AccountUsage : IModel
	{
		public const string FIELD_MEMBERNAME = "MemberName";
		public const string FIELD_MEMBERSOID = "MemberSoid";
		public const string FIELD_CALLEDON = "CalledOn";
		public const string FIELD_URL = "URL";

		public enum Fields
		{
			Soid,
			SqlId,
			MemberName,
			MemberSoid,
			CalledOn,
			URL,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string MemberName { set; get; }
		public string MemberSoid { set; get; }
		public DateTime CalledOn { set; get; }
		public string URL { set; get; }

		public AccountUsage() { }

		public AccountUsage(DataLayer.MongoDB.Analytics.AccountUsage accountUsage)
		{
			if (accountUsage == null)
				return;
			Soid = accountUsage.Id.ToString();
			SqlId = accountUsage.SqlId;
			MemberName = accountUsage.MemberName;
			MemberSoid = accountUsage.MemberSoid;
			CalledOn = accountUsage.CalledOn;
			URL = accountUsage.URL;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "MemberName": return MemberName;
				case "MemberSoid": return MemberSoid;
				case "CalledOn": return CalledOn;
				case "URL": return URL;

				default: return null;
			}
		}

		public DataLayer.MongoDB.Analytics.AccountUsage ToModel()
		{
			var accountUsage = new DataLayer.MongoDB.Analytics.AccountUsage();
			if (!Soid.IsNullOrEmpty())
				accountUsage.ResetId(Soid);
			accountUsage.SqlId = SqlId;
			accountUsage.MemberName = MemberName;
			accountUsage.MemberSoid = MemberSoid;
			accountUsage.CalledOn = CalledOn;
			accountUsage.URL = URL;

			return accountUsage;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("MemberName");
				fieldNames.Add("MemberSoid");
				fieldNames.Add("CalledOn");
				fieldNames.Add("URL");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 12;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("MemberName ".PadRight(fieldNameMaxWidth, '.') + " " + MemberName);
			sb.AppendLine("MemberSoid ".PadRight(fieldNameMaxWidth, '.') + " " + MemberSoid);
			sb.AppendLine("CalledOn ".PadRight(fieldNameMaxWidth, '.') + " " + CalledOn.ToString());
			sb.AppendLine("URL ".PadRight(fieldNameMaxWidth, '.') + " " + URL);

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">MemberName [" + MemberName + "]< ");
			sb.Append(">MemberSoid [" + MemberSoid + "]< ");
			sb.Append(">CalledOn [" + CalledOn.ToString() + "]< ");
			sb.Append(">URL [" + URL + "]< ");

			return sb.ToString();
		}
	}
}
