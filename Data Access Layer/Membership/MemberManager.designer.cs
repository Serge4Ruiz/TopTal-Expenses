using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Membership;

namespace TopTal.Expenses.DataAccessLayer.Membership
{
	public partial class MemberManager
	{
		public string SaveMember(Model.Member member)
		{
			return MemberDB.SaveMember(member.ToModel());
		}

		public void DeleteMember(string soid)
		{
			var db = new MemberDB();
			db.Delete(soid);
		}

		public Model.Member GetMember(string soid)
		{
			return new Model.Member(MemberDB.GetMember(soid));
		}

		public Model.Member GetMemberFromSqlId(int id)
		{
			var member = MemberDB.GetMemberFromSqlId(id);
			if (member == null)
				return null;
			return new Model.Member(member);
		}

		public IEnumerable<Model.Member> GetMemberList()
		{
			var db = new MemberDB();
			foreach (var member in db.GetDocuments())
				yield return new Model.Member(member);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Membership.MemberDB();
			mgr.Clear();
		}
	}
}
