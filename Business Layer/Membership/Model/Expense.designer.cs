using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.ServiceLayer.Membership;

namespace TopTal.Expenses.BusinessLayer.Membership.Model
{
	public partial class Expense : IModel
	{
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_EXPENSEDATE = "ExpenseDate";
		public const string FIELD_DESCRIPTION = "Description";
		public const string FIELD_AMOUNT	 = "Amount	";
		public const string FIELD_COMMENT = "Comment";

		public enum Fields
		{
			Soid,
			SqlId,
			CreatedOn,
			ExpenseDate,
			Description,
			Amount	,
			Comment,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public DateTime CreatedOn { set; get; }
		public DateTime ExpenseDate { set; get; }
		public string Description { set; get; }
		public float Amount	 { set; get; }
		public string Comment { set; get; }

		public Expense() {}

		public Expense(ServiceLayer.Membership.Model.Expense expense)
		{
			if (expense == null)
				return;
			Soid = expense.Soid;
			SqlId = expense.SqlId;
			CreatedOn = expense.CreatedOn;
			ExpenseDate = expense.ExpenseDate;
			Description = expense.Description;
			Amount	 = expense.Amount	;
			Comment = expense.Comment;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "CreatedOn": return CreatedOn;
				case "ExpenseDate": return ExpenseDate;
				case "Description": return Description;
				case "Amount	": return Amount	;
				case "Comment": return Comment;

				default: return null;
			}
		}

		public ServiceLayer.Membership.Model.Expense ToModel()
		{
			var expense = new ServiceLayer.Membership.Model.Expense();
			expense.Soid = Soid;
			expense.SqlId = SqlId;
			expense.CreatedOn = CreatedOn;
			expense.ExpenseDate = ExpenseDate;
			expense.Description = Description;
			expense.Amount	 = Amount	;
			expense.Comment = Comment;

			return expense;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("CreatedOn");
				fieldNames.Add("ExpenseDate");
				fieldNames.Add("Description");
				fieldNames.Add("Amount	");
				fieldNames.Add("Comment");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 13;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("CreatedOn ".PadRight(fieldNameMaxWidth, '.') + " " + CreatedOn.ToString());
			sb.AppendLine("ExpenseDate ".PadRight(fieldNameMaxWidth, '.') + " " + ExpenseDate.ToString());
			sb.AppendLine("Description ".PadRight(fieldNameMaxWidth, '.') + " " + Description);
			sb.AppendLine("Amount	 ".PadRight(fieldNameMaxWidth, '.') + " " + Amount	.ToString());
			sb.AppendLine("Comment ".PadRight(fieldNameMaxWidth, '.') + " " + Comment);

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">CreatedOn [" + CreatedOn.ToString() + "]< ");
			sb.Append(">ExpenseDate [" + ExpenseDate.ToString() + "]< ");
			sb.Append(">Description [" + Description + "]< ");
			sb.Append(">Amount	 [" + Amount	.ToString() + "]< ");
			sb.Append(">Comment [" + Comment + "]< ");

			return sb.ToString();
		}
	}
}
