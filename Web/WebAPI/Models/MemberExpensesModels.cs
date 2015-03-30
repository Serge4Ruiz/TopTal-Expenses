using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TopTal.Expenses.WebAPI.Models
{
	public class AddMemberExpenseModel
	{
		[Required]
		public string UserName { set; get; }
		[Required]
		public string Date { set; get; }
		[Required]
		public string TimeHours { set; get; }
		[Required]
		public string TimeMinutes { set; get; }
		[Required]
		public string TimeTT { set; get; }
		[Required]
		public string Description { set; get; }
		[Required]
		public float Amount { set; get; }
		public string Comment { set; get; }
	}

	public class AddRandomExpenses
	{
		[Required]
		public string UserName { set; get; }
		[Required]
		public int Count { set; get; }
	}

	public class MemberExpenseModel
	{
		[Required]
		public string UserName { set; get; }
		[Required]
		public string Date { set; get; }
		[Required]
		public string Description { set; get; }
		[Required]
		public float Amount { set; get; }
		public string Comment { set; get; }
	}

	public class MemberExpenseReportByWeekRequest
	{
		[Required]
		public string UserName { set; get; }
		[Required]
		public string Date { set; get; }
	}

	public class MemberExpenseReportByWeekResponse
	{
		public float Total { set; get; }
		public float Average { set; get; }
		public DateTime Start { set; get; }
		public DateTime End { set; get; }
		public List<BusinessLayer.Membership.Model.Expense> Expenses = new List<BusinessLayer.Membership.Model.Expense>();
	}
}
