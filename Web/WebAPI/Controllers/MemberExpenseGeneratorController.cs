﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TopTal.Expenses.WebAPI.Controllers
{
	public class MemberExpenseGeneratorController : ApiController
	{
		[EnableCors("http://localhost:54001", "*", "*")]
		public BusinessLayer.Membership.Model.Member Get(string id)
		{
			var mgrMembers = new BusinessLayer.Membership.MemberManager();
			var member = mgrMembers.GetMemberList().FirstOrDefault(m => m.UserName == id);
			if (member == null)
			{
				member = new BusinessLayer.Membership.Model.Member();
				member.UserName = id;
				member.Soid = mgrMembers.SaveMember(member);
			}
			member.AddRandomExpense();
			mgrMembers.SaveMember(member);
			return member;
		}

		public void Post(string userName, int count)
		{
		}
	}
}
