using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Membership
{
	public partial class MemberManager
	{
		public string SaveMember(Model.Member member)
		{
			var mgr = new ServiceLayer.Membership.MemberManager();
			return mgr.SaveMember(member.ToModel());
		}

		public void DeleteMember(string soid)
		{
			var mgr = new ServiceLayer.Membership.MemberManager();
			mgr.DeleteMember(soid);
		}

		public Model.Member GetMember(string soid)
		{
			var mgr = new ServiceLayer.Membership.MemberManager();
			return new Model.Member(mgr.GetMember(soid));
		}

		public IEnumerable<Model.Member> GetMemberList()
		{
			var mgr = new ServiceLayer.Membership.MemberManager();
			foreach (var member in mgr.GetMemberList())
				yield return new Model.Member(member);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Membership.MemberManager();
			return mgr.Update(fieldName, data);
		}
	}
}
