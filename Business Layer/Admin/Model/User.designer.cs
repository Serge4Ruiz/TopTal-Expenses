using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.ServiceLayer.Admin;

namespace TopTal.Expenses.BusinessLayer.Admin.Model
{
	public partial class User : IModel
	{
		public const string FIELD_USERNAME = "UserName";
		public const string FIELD_PASSWORD = "Password";
		public const string FIELD_SCREENNAME = "ScreenName";
		public const string FIELD_EMAILADDRESS = "EmailAddress";

		public enum Fields
		{
			Soid,
			SqlId,
			UserName,
			Password,
			ScreenName,
			EmailAddress,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string UserName { set; get; }
		public string Password { set; get; }
		public string ScreenName { set; get; }
		public string EmailAddress { set; get; }

		public User() {}

		public User(ServiceLayer.Admin.Model.User user)
		{
			if (user == null)
				return;
			Soid = user.Soid;
			SqlId = user.SqlId;
			UserName = user.UserName;
			Password = user.Password;
			ScreenName = user.ScreenName;
			EmailAddress = user.EmailAddress;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "UserName": return UserName;
				case "Password": return Password;
				case "ScreenName": return ScreenName;
				case "EmailAddress": return EmailAddress;

				default: return null;
			}
		}

		public ServiceLayer.Admin.Model.User ToModel()
		{
			var user = new ServiceLayer.Admin.Model.User();
			user.Soid = Soid;
			user.SqlId = SqlId;
			user.UserName = UserName;
			user.Password = Password;
			user.ScreenName = ScreenName;
			user.EmailAddress = EmailAddress;

			return user;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("UserName");
				fieldNames.Add("Password");
				fieldNames.Add("ScreenName");
				fieldNames.Add("EmailAddress");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 14;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("UserName ".PadRight(fieldNameMaxWidth, '.') + " " + UserName);
			sb.AppendLine("Password ".PadRight(fieldNameMaxWidth, '.') + " " + Password);
			sb.AppendLine("ScreenName ".PadRight(fieldNameMaxWidth, '.') + " " + ScreenName);
			sb.AppendLine("EmailAddress ".PadRight(fieldNameMaxWidth, '.') + " " + EmailAddress);

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">UserName [" + UserName + "]< ");
			sb.Append(">Password [" + Password + "]< ");
			sb.Append(">ScreenName [" + ScreenName + "]< ");
			sb.Append(">EmailAddress [" + EmailAddress + "]< ");

			return sb.ToString();
		}
	}
}
