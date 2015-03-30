using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Membership
{
	public partial class MemberDB : DocumentList<Member>
	{
		public MemberDB()
			: base(new Member())
		{
		}

		public static string SaveMember(Member member)
		{
			var db = new MemberDB();
			db.Save(member);
			return member.Id.ToString();
		}

		public static Member GetMember(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetMember(oid);
			return null;
		}

		public static Member GetMemberFromSqlId(int id)
		{
			var db = new MemberDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static Member GetMember(ObjectId oid)
		{
			var db = new MemberDB();
			return db.GetDocument(oid);
		}
	}
}
