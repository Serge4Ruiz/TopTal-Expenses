using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.Win32.Test
{
	class Membership : BaseTestSuite
	{
		public Membership()
			: base("Membership")
		{
			options.Add(ConsoleKey.A, "List Members");
			options.Add(ConsoleKey.B, "Create Expense Data");
			options.Add(ConsoleKey.C, "Clear all");
		}

		public override void RunOption(ConsoleKey key)
		{
			base.RunOption(key);
			switch (key)
			{
				case ConsoleKey.A: List(); break;
				case ConsoleKey.B: CreateExpenseData(); break;
				case ConsoleKey.C: Clear(); break;
			}
		}

		void List()
		{
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			foreach (var member in mgrMembers.GetMemberList())
			{
				Console.WriteLine("{0} {1} {2} {3} {4}", member.Soid, member.EmailAddress, member.NameFirst, member.NameLast, member.UserName);
				foreach (var expense in member.Expenses)
				{
					Console.WriteLine("    {0} {1:#,##0.00} {2:MM/dd/yyyy HH:mm} {3} {4}", expense.Soid, expense.Amount, expense.CreatedOn, expense.Description, expense.Comment);
				}
			}
		}

		void CreateExpenseData()
		{
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			var rnd = new Random(DateTime.Now.Millisecond);
			int commentNbr = 1;
			foreach (var member in mgrMembers.GetMemberList())
			{
				for (int i = 0; i < rnd.Next(100); i++)
				{
					var expense = new BusinessLayer.Membership.Model.Expense();
					expense.Amount = (float)rnd.Next(10, 10000) / 100;
					expense.Comment = string.Format("Comment #{0:00000}", commentNbr++);
					expense.CreatedOn = DateTime.UtcNow;
					expense.Description = Guid.NewGuid().ToString();
					expense.ExpenseDate = DateTime.UtcNow;
					member.Expenses.Add(expense);
				}
				mgrMembers.SaveMember(member);
			}
		}

		void Clear()
		{
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			List<string> soids = mgrMembers.GetMemberList().Select(m => m.Soid).ToList();
			foreach (string soid in soids)
				mgrMembers.DeleteMember(soid);
		}
	}
}
