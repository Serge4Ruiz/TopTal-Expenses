using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine.Extensions;

namespace TopTal.Expenses.ServiceLayer.Importers
{
	public class ExcelMembers : ExcelReader
	{
		public ExcelMembers(string fileName, params string[] folders) : base(fileName, folders)
		{
		}

		public override void ReadDocument()
		{
			int rowIndex = 2;
			int colIndex = 1;
			var mgrMembers = new DataAccessLayer.Membership.MemberManager();
			do
			{
				colIndex = 1;
				string soid = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
				var member = mgrMembers.GetMemberList().FirstOrDefault(m => m.Soid == soid);
				if (member == null)
				{
					member = new DataAccessLayer.Membership.Model.Member();
					member.Soid = soid;
					member.ScreenName = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					member.EmailAddress = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					member.NameFirst = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					member.NameLast = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					member.NameFull = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					member.UserName = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					member.Password = GetString(_sheet.Cells[rowIndex, colIndex++].Value).Base64Encode();
					member.CreatedOn = GetDateTime(_sheet.Cells[rowIndex, colIndex++].Value);
					member.Reference = Guid.NewGuid();
					member.Verified = GetBool(_sheet.Cells[rowIndex, colIndex++].Value);
					member.Soid = mgrMembers.SaveMember(member);
				}
				rowIndex++;
			}
			while (rowIndex <= _lastRow);
			_sheet = _xlPkg.Workbook.Worksheets["Expenses"];
			rowIndex = 2;
			do
			{
				colIndex = 1;
				string expenseSoid = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
				string memberSoid = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
				var member = mgrMembers.GetMember(memberSoid);
				if (member != null && member.Soid != null)
				{
					var expense = member.Expenses.FirstOrDefault(e => e.Soid == expenseSoid);
					if (expense == null || expense.Soid == null)
					{
						expense = new DataAccessLayer.Membership.Model.Expense();
						expense.Soid = expenseSoid;
						member.Expenses.Add(expense);
					}
					expense.CreatedOn = GetDateTime(_sheet.Cells[rowIndex, colIndex++].Value);
					expense.ExpenseDate = GetDateTime(_sheet.Cells[rowIndex, colIndex++].Value);
					expense.Description = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					expense.Amount = GetFloat(_sheet.Cells[rowIndex, colIndex++]);
					expense.Comment = GetString(_sheet.Cells[rowIndex, colIndex++].Value);
					mgrMembers.SaveMember(member);
				}
				rowIndex++;
			}
			while (_sheet.Cells[rowIndex, 2].Value != null);
		}
	}
}
