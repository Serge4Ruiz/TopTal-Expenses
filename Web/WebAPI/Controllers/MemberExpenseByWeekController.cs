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
	public class MemberExpenseByWeekController : ApiController
	{
		public Models.MemberExpenseReportByWeekResponse Get([FromUri] Models.MemberExpenseReportByWeekRequest expenseModel)
		{
			if (expenseModel == null)
				return null;
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			var member = mgrMembers.GetMemberList().FirstOrDefault(m => m.UserName == expenseModel.UserName);
			var expenseWeeklyReport = new Models.MemberExpenseReportByWeekResponse();
			DateTime start = DateTime.Now;
			var expenses = member.GetExpenseForWeek(DateTime.Parse(expenseModel.Date), out start);
			expenseWeeklyReport.Start = start;
			expenseWeeklyReport.End = start.AddDays(7);
			expenseWeeklyReport.Expenses = expenses.ToList();
			expenseWeeklyReport.Total = expenses.Sum(e => e.Amount);
			if (expenseWeeklyReport.Expenses.Count() > 0)
				expenseWeeklyReport.Average = expenses.Average(e => e.Amount);
			return expenseWeeklyReport;
		}
	}
}
