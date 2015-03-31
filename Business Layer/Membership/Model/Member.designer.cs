using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.ServiceLayer.Membership;

namespace TopTal.Expenses.BusinessLayer.Membership.Model
{
	public partial class Member : IModel
	{
		public const string FIELD_SCREENNAME = "ScreenName";
		public const string FIELD_EMAILADDRESS = "EmailAddress";
		public const string FIELD_NAMEFIRST = "NameFirst";
		public const string FIELD_NAMELAST = "NameLast";
		public const string FIELD_NAMEFULL = "NameFull";
		public const string FIELD_USERNAME = "UserName";
		public const string FIELD_PASSWORD = "Password";
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_REFERENCE = "Reference";
		public const string FIELD_VERIFIED = "Verified";
		public const string FIELD_EXPENSES = "Expenses";

		public enum Fields
		{
			Soid,
			SqlId,
			ScreenName,
			EmailAddress,
			NameFirst,
			NameLast,
			NameFull,
			UserName,
			Password,
			CreatedOn,
			Reference,
			Verified,
			Expenses,
		}

		private List<Expense> _Expenses;

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string ScreenName { set; get; }
		public string EmailAddress { set; get; }
		public string NameFirst { set; get; }
		public string NameLast { set; get; }
		public string NameFull { set; get; }
		public string UserName { set; get; }
		public string Password { set; get; }
		public DateTime CreatedOn { set; get; }
		public Guid Reference { set; get; }
		public bool Verified { set; get; }
		public List<Expense> Expenses { set { _Expenses = value; } get { return _Expenses ?? (_Expenses = new List<Expense>()); } }

		public Member() {
			Reference = Guid.NewGuid();
		}

		public Member(ServiceLayer.Membership.Model.Member member)
		{
			if (member == null)
				return;
			Soid = member.Soid;
			SqlId = member.SqlId;
			ScreenName = member.ScreenName;
			EmailAddress = member.EmailAddress;
			NameFirst = member.NameFirst;
			NameLast = member.NameLast;
			NameFull = member.NameFull;
			UserName = member.UserName;
			Password = member.Password;
			CreatedOn = member.CreatedOn;
			Reference = member.Reference;
			Verified = member.Verified;
			foreach (var expense in member.Expenses)
				Expenses.Add(new Expense(expense));
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "ScreenName": return ScreenName;
				case "EmailAddress": return EmailAddress;
				case "NameFirst": return NameFirst;
				case "NameLast": return NameLast;
				case "NameFull": return NameFull;
				case "UserName": return UserName;
				case "Password": return Password;
				case "CreatedOn": return CreatedOn;
				case "Reference": return Reference;
				case "Verified": return Verified;
				case "Expenses": return Expenses;

				default: return null;
			}
		}

		public ServiceLayer.Membership.Model.Member ToModel()
		{
			var member = new ServiceLayer.Membership.Model.Member();
			member.Soid = Soid;
			member.SqlId = SqlId;
			member.ScreenName = ScreenName;
			member.EmailAddress = EmailAddress;
			member.NameFirst = NameFirst;
			member.NameLast = NameLast;
			member.NameFull = NameFull;
			member.UserName = UserName;
			member.Password = Password;
			member.CreatedOn = CreatedOn;
			member.Reference = Reference;
			member.Verified = Verified;
			foreach (var expense in Expenses)
				member.Expenses.Add(expense.ToModel());

			return member;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("ScreenName");
				fieldNames.Add("EmailAddress");
				fieldNames.Add("NameFirst");
				fieldNames.Add("NameLast");
				fieldNames.Add("NameFull");
				fieldNames.Add("UserName");
				fieldNames.Add("Password");
				fieldNames.Add("CreatedOn");
				fieldNames.Add("Reference");
				fieldNames.Add("Verified");
				fieldNames.Add("Expenses");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 14;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("ScreenName ".PadRight(fieldNameMaxWidth, '.') + " " + ScreenName);
			sb.AppendLine("EmailAddress ".PadRight(fieldNameMaxWidth, '.') + " " + EmailAddress);
			sb.AppendLine("NameFirst ".PadRight(fieldNameMaxWidth, '.') + " " + NameFirst);
			sb.AppendLine("NameLast ".PadRight(fieldNameMaxWidth, '.') + " " + NameLast);
			sb.AppendLine("NameFull ".PadRight(fieldNameMaxWidth, '.') + " " + NameFull);
			sb.AppendLine("UserName ".PadRight(fieldNameMaxWidth, '.') + " " + UserName);
			sb.AppendLine("Password ".PadRight(fieldNameMaxWidth, '.') + " " + Password);
			sb.AppendLine("CreatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + CreatedOn.ToString());
			sb.AppendLine("Reference ".PadRight(fieldNameMaxWidth, '.') + " " + Reference.ToString());
			sb.AppendLine("Verified ".PadRight(fieldNameMaxWidth, '.') + " " + Verified.ToString());
			sb.AppendLine("Expenses ".PadRight(fieldNameMaxWidth, '.') + " " + Expenses.Count() + " items");

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">ScreenName [" + ScreenName + "]< ");
			sb.Append(">EmailAddress [" + EmailAddress + "]< ");
			sb.Append(">NameFirst [" + NameFirst + "]< ");
			sb.Append(">NameLast [" + NameLast + "]< ");
			sb.Append(">NameFull [" + NameFull + "]< ");
			sb.Append(">UserName [" + UserName + "]< ");
			sb.Append(">Password [" + Password + "]< ");
			sb.Append(">CreatedOn [" + CreatedOn.ToString() + "]< ");
			sb.Append(">Reference [" + Reference.ToString() + "]< ");
			sb.Append(">Verified [" + Verified.ToString() + "]< ");
			sb.Append(">Expenses [" + Expenses.Count() + " items]< ");

			return sb.ToString();
		}
	}
}
