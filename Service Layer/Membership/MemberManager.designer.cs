using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Membership
{
	public partial class MemberManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.Member _member;

		public string SaveMember(Model.Member member)
		{
			var mgr = new DataAccessLayer.Membership.MemberManager();
			return mgr.SaveMember(member.ToModel());
		}

		public void DeleteMember(string soid)
		{
			var mgr = new DataAccessLayer.Membership.MemberManager();
			mgr.DeleteMember(soid);
		}

		public Model.Member GetMember(string soid)
		{
			var mgr = new DataAccessLayer.Membership.MemberManager();
			return new Model.Member(mgr.GetMember(soid));
		}

		public Model.Member GetMemberFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Membership.MemberManager();
			var member = mgr.GetMemberFromSqlId(id);
			if (member == null)
				return null;
			return new Model.Member(member);
		}

		public IEnumerable<Model.Member> GetMemberList()
		{
			var mgr = new DataAccessLayer.Membership.MemberManager();
			foreach (var member in mgr.GetMemberList())
				yield return new Model.Member(member);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Membership.MemberManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_member = GetMember(_fieldBits.Last());
			if (_member == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "ScreenName": _changed = _member.ScreenName != _data; _member.ScreenName = _data; break;
				case "EmailAddress": _changed = _member.EmailAddress != _data; _member.EmailAddress = _data; break;
				case "NameFirst": _changed = _member.NameFirst != _data; _member.NameFirst = _data; break;
				case "NameLast": _changed = _member.NameLast != _data; _member.NameLast = _data; break;
				case "NameFull": _changed = _member.NameFull != _data; _member.NameFull = _data; break;
				case "UserName": _changed = _member.UserName != _data; _member.UserName = _data; break;
				case "Password": _changed = _member.Password != _data; _member.Password = _data; break;
				case "CreatedOn": DateTime dateCreatedOn = new DateTime(); if (DateTime.TryParse(_data, out dateCreatedOn)) { _changed = _member.CreatedOn != dateCreatedOn; _member.CreatedOn = dateCreatedOn; }; break;

				case "Verified": bool bVerified = false; if (bool.TryParse(_data, out bVerified)) {  _changed = _member.Verified != bVerified; _member.Verified = bVerified; }; break;
			}
			SaveMember(_member);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _member.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
