using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Membership
{
	[BsonIgnoreExtraElements]
	public partial class Expense : BaseObject
	{
		public const string FIELD_CREATEDON = "CreatedOn";
		public const string FIELD_EXPENSEDATE = "ExpenseDate";
		public const string FIELD_DESCRIPTION = "Description";
		public const string FIELD_AMOUNT	 = "Amount	";
		public const string FIELD_COMMENT = "Comment";

		public DateTime CreatedOn { set; get; }
		public DateTime ExpenseDate { set; get; }
		public string Description { set; get; }
		public float Amount	 { set; get; }
		public string Comment { set; get; }

		public Expense()
			: base()
		{
		}
	}
}
