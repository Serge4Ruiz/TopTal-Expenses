using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Membership.Model
{
	public partial class Member
	{
		public IEnumerable<Expense> GetExpenseForWeek(DateTime date, out DateTime start)
		{
			start = new DateTime();
			while (date.DayOfWeek != DayOfWeek.Sunday)
				date= date.AddDays(-1);
			start = date;
			DateTime startDate = start; // can't use 'start' in Lambda expression
			DateTime endDate = start.AddDays(7);
			return Expenses.Where(e => e.ExpenseDate > startDate && e.ExpenseDate < endDate).OrderBy(e => e.ExpenseDate);
		}

		public void AddRandomExpense()
		{
			var rnd = new Random(DateTime.Now.Millisecond);
			var expense = new Expense();
			expense.Amount = (float)rnd.NextDouble() * 100.0f;
			expense.Comment = "Comment - " + Guid.NewGuid().ToString().Substring(0, 8);
			expense.CreatedOn = DateTime.UtcNow;
			expense.Description = "Description - " + Guid.NewGuid().ToString().Substring(0, 8);
			expense.ExpenseDate = new DateTime(2015, rnd.Next(1, 3), rnd.Next(1, 28), rnd.Next(0, 23), rnd.Next(0, 59), 0);
			Expenses.Add(expense);
		}
	}
}
