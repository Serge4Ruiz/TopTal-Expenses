using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LC.Core.Engine.Extensions;

namespace TopTal.Expenses.ServiceLayer.Exporters
{
	public class ExcelMembers : ExcelWriter
	{
		public ExcelMembers() : base()
		{
			FileName = string.Format("Members-{0:MM-dd-yyyy-HH-mm}.xlsx", DateTime.Now);
		}

		public override void CreateDocument()
		{
			base.CreateDocument();
			_ws.Name = "Members";
			var expensesSheet = _ws.Workbook.Worksheets.Add("Expenses");
			int colIndex = 1;
			_ws.Cells[1, colIndex++].Value = "Soid";
			_ws.Cells[1, colIndex++].Value = "Screen Name";
			_ws.Cells[1, colIndex++].Value = "Email Address";
			_ws.Cells[1, colIndex++].Value = "First Name";
			_ws.Cells[1, colIndex++].Value = "Last Name";
			_ws.Cells[1, colIndex++].Value = "Full Name";
			_ws.Cells[1, colIndex++].Value = "User Name";
			_ws.Cells[1, colIndex++].Value = "Password";
			_ws.Cells[1, colIndex++].Value = "Created On";
			_ws.Cells[1, colIndex++].Value = "Verified";
			colIndex = 1;
			expensesSheet.Cells[1, colIndex++].Value = "Soid";
			expensesSheet.Cells[1, colIndex++].Value = "MemberSoid";
			expensesSheet.Cells[1, colIndex++].Value = "Created On";
			expensesSheet.Cells[1, colIndex++].Value = "Expense Date";
			expensesSheet.Cells[1, colIndex++].Value = "Description";
			expensesSheet.Cells[1, colIndex++].Value = "Amount";
			expensesSheet.Cells[1, colIndex++].Value = "Comment";
			var mgrMembers = new DataAccessLayer.Membership.MemberManager();
			int rowIndex = 2;
			int rowIndexExpenses = 2;
			foreach (var member in mgrMembers.GetMemberList())
			{
				colIndex = 1;
				_ws.Cells[rowIndex, colIndex++].Value = member.Soid;
				_ws.Cells[rowIndex, colIndex++].Value = member.ScreenName;
				_ws.Cells[rowIndex, colIndex++].Value = member.EmailAddress;
				_ws.Cells[rowIndex, colIndex++].Value = member.NameFirst;
				_ws.Cells[rowIndex, colIndex++].Value = member.NameLast;
				_ws.Cells[rowIndex, colIndex++].Value = member.NameFull;
				_ws.Cells[rowIndex, colIndex++].Value = member.UserName;
				_ws.Cells[rowIndex, colIndex++].Value = member.Password.Base64Decode();
				_ws.Cells[rowIndex, colIndex++].Value = member.CreatedOn.ToString("MM/dd/yyyy HH:mm:ss");
				_ws.Cells[rowIndex, colIndex++].Value = member.Verified.ToString().ToUpper();
				rowIndex++;
				foreach (var expense in member.Expenses)
				{
					colIndex = 1;
					expensesSheet.Cells[rowIndexExpenses, colIndex++].Value = expense.Soid;
					expensesSheet.Cells[rowIndexExpenses, colIndex++].Value = member.Soid;
					expensesSheet.Cells[rowIndexExpenses, colIndex++].Value = expense.CreatedOn.ToString("MM/dd/yyyy HH:mm:ss");
					expensesSheet.Cells[rowIndexExpenses, colIndex++].Value = expense.ExpenseDate.ToString("MM/dd/yyyy HH:mm:ss");
					expensesSheet.Cells[rowIndexExpenses, colIndex++].Value = expense.Description;
					expensesSheet.Cells[rowIndexExpenses, colIndex++].Value = expense.Amount;
					expensesSheet.Cells[rowIndexExpenses, colIndex++].Value = expense.Comment;
					rowIndexExpenses++;
				}
			}
			Save();
		}
	}
}
