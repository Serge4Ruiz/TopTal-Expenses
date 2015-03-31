using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using LC.Core.Engine.Extensions;
using MongoDB.Bson;
using TopTal.Expenses.DataLayer.MongoDB.Membership;

namespace TopTal.Expenses.DataAccessLayer.Analytics.Model
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

		public MemberReference() { }

		public MemberReference(DataLayer.MongoDB.Membership.MemberReference memberReference)
		{
			if (memberReference == null)
				return;
			Soid = memberReference.Id.ToString();
			SqlId = memberReference.SqlId;
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

		public DataLayer.MongoDB.Membership.MemberReference ToModel()
		{
			var memberReference = new DataLayer.MongoDB.Membership.MemberReference();
			if (!Soid.IsNullOrEmpty())
				memberReference.ResetId(Soid);
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
	}
}
