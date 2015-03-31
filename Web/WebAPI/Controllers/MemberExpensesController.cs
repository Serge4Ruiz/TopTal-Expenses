using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TopTal.Expenses.WebAPI.Controllers
{
	[EnableCors("http://localhost:54001", "*", "*")]
	public class MemberExpensesController : ApiController
	{
		/// <summary>
		/// Get a list of all the Members
		/// </summary>
		/// <returns></returns>
		public IEnumerable<BusinessLayer.Membership.Model.Member> Get()
		{
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			var qry = mgrMembers.GetMemberList();
			return qry;
		}

		/// <summary>
		/// Get a lit of all the Expenses for a given Member, by User Name
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public IEnumerable<BusinessLayer.Membership.Model.Expense> Get(string id)
		{
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			var member = mgrMembers.GetMemberList().FirstOrDefault(m => m.UserName == id);
			return member.Expenses;
		}

		/// <summary>
		/// Adds an Expense to a Member
		/// </summary>
		/// <param name="expenseModel"></param>
		/// <returns></returns>
		public void AddExpense(Models.AddMemberExpenseModel expenseModel)
		{
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			var member = mgrMembers.GetMemberList().FirstOrDefault(m => m.UserName == expenseModel.UserName);
			if (member == null)
			{
				member = new BusinessLayer.Membership.Model.Member();
				member.UserName = expenseModel.UserName;
				mgrMembers.SaveMember(member);
			}
			var expense = new BusinessLayer.Membership.Model.Expense();
			expense.Amount = expenseModel.Amount;
			expense.Comment = expenseModel.Comment;
			expense.CreatedOn = DateTime.UtcNow;
			expense.Description = expenseModel.Description;
			// we assume the Date is in a parsable format, TimeHours and TimeMinutes are parsable integers
				expense.ExpenseDate = DateTime.Parse(expenseModel.Date).AddHours(int.Parse(expenseModel.TimeHours)).AddMinutes(int.Parse(expenseModel.TimeMinutes));
			if (expenseModel.TimeTT == "PM")
				expense.ExpenseDate = expense.ExpenseDate.AddHours(12);
			member.Expenses.Add(expense);
			mgrMembers.SaveMember(member);
		}
	}
}
