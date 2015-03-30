using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.DataAccessLayer.Analytics;

namespace TopTal.Expenses.ServiceLayer.Analytics.Model
{
	public partial class AccountLogin : IModel
	{
		public const string FIELD_MEMBERNAME = "MemberName";
		public const string FIELD_MEMBERSOID = "MemberSoid";
		public const string FIELD_LOGGEDINON = "LoggedInOn";
		public const string FIELD_BROWSER = "Browser";
		public const string FIELD_LOGGEDOFFON = "LoggedOffOn";

		public enum Fields
		{
			Soid,
			SqlId,
			MemberName,
			MemberSoid,
			LoggedInOn,
			Browser,
			LoggedOffOn,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string MemberName { set; get; }
		public string MemberSoid { set; get; }
		public DateTime LoggedInOn { set; get; }
		public string Browser { set; get; }
		public DateTime? LoggedOffOn { set; get; }

		public AccountLogin()
		{
		}

		public AccountLogin(DataAccessLayer.Analytics.Model.AccountLogin accountLogin)
		{
			if (accountLogin == null)
				return;
			Soid = accountLogin.Soid;
			SqlId = accountLogin.SqlId;
			MemberName = accountLogin.MemberName;
			MemberSoid = accountLogin.MemberSoid;
			LoggedInOn = accountLogin.LoggedInOn;
			Browser = accountLogin.Browser;
			LoggedOffOn = accountLogin.LoggedOffOn;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "MemberName": return MemberName;
				case "MemberSoid": return MemberSoid;
				case "LoggedInOn": return LoggedInOn;
				case "Browser": return Browser;
				case "LoggedOffOn": return LoggedOffOn;

				default: return null;
			}
		}

		public DataAccessLayer.Analytics.Model.AccountLogin ToModel()
		{
			var accountLogin = new DataAccessLayer.Analytics.Model.AccountLogin();
			accountLogin.Soid = Soid;
			accountLogin.SqlId = SqlId;
			accountLogin.MemberName = MemberName;
			accountLogin.MemberSoid = MemberSoid;
			accountLogin.LoggedInOn = LoggedInOn;
			accountLogin.Browser = Browser;
			accountLogin.LoggedOffOn = LoggedOffOn;

			return accountLogin;
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
				fieldNames.Add("LoggedInOn");
				fieldNames.Add("Browser");
				fieldNames.Add("LoggedOffOn");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 13;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("MemberName ".PadRight(fieldNameMaxWidth, '.') + " " + MemberName);
			sb.AppendLine("MemberSoid ".PadRight(fieldNameMaxWidth, '.') + " " + MemberSoid);
			sb.AppendLine("LoggedInOn ".PadRight(fieldNameMaxWidth, '.') + " " + LoggedInOn.ToString());
			sb.AppendLine("Browser ".PadRight(fieldNameMaxWidth, '.') + " " + Browser);
			sb.AppendLine("LoggedOffOn ".PadRight(fieldNameMaxWidth, '.') + " " + LoggedOffOn.ToString());

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">MemberName [" + MemberName + "]< ");
			sb.Append(">MemberSoid [" + MemberSoid + "]< ");
			sb.Append(">LoggedInOn [" + LoggedInOn.ToString() + "]< ");
			sb.Append(">Browser [" + Browser + "]< ");
			sb.Append(">LoggedOffOn [" + LoggedOffOn.ToString() + "]< ");

			return sb.ToString();
		}
	}
}
