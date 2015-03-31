using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.DataAccessLayer.Membership;

namespace TopTal.Expenses.ServiceLayer.Analytics.Model
{
	public partial class MemberReference : IModel
	{
		public enum Fields
		{
			Soid,
			SqlId,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }

		public MemberReference()
		{
		}

		public MemberReference(DataAccessLayer.Analytics.Model.MemberReference memberReference)
		{
			if (memberReference == null)
				return;
			Soid = memberReference.Soid;
			SqlId = memberReference.SqlId;
		}

		public MemberReference(DataAccessLayer.Membership.Model.Member source)
		{
			Soid = source.Soid;
			SqlId = source.SqlId;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;

				default: return null;
			}
		}

		public DataAccessLayer.Analytics.Model.MemberReference ToModel()
		{
			var memberReference = new DataAccessLayer.Analytics.Model.MemberReference();
			memberReference.Soid = Soid;
			memberReference.SqlId = SqlId;

			return memberReference;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 2;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");

			return sb.ToString();
		}

		public static IEnumerable<MemberReference> GetMemberReferencesFromMembership()
		{
			var mgr = new DataAccessLayer.Membership.MemberManager();
			foreach (var member in mgr.GetMemberList())
				yield return new Model.MemberReference(member);
		}
	}
}
