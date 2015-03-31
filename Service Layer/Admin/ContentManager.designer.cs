using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Admin
{
	public partial class ContentManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.Content _content;

		public string SaveContent(Model.Content content)
		{
			var mgr = new DataAccessLayer.Admin.ContentManager();
			return mgr.SaveContent(content.ToModel());
		}

		public void DeleteContent(string soid)
		{
			var mgr = new DataAccessLayer.Admin.ContentManager();
			mgr.DeleteContent(soid);
		}

		public Model.Content GetContent(string soid)
		{
			var mgr = new DataAccessLayer.Admin.ContentManager();
			return new Model.Content(mgr.GetContent(soid));
		}

		public Model.Content GetContentFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Admin.ContentManager();
			var content = mgr.GetContentFromSqlId(id);
			if (content == null)
				return null;
			return new Model.Content(content);
		}

		public IEnumerable<Model.Content> GetContentList()
		{
			var mgr = new DataAccessLayer.Admin.ContentManager();
			foreach (var content in mgr.GetContentList())
				yield return new Model.Content(content);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Admin.ContentManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_content = GetContent(_fieldBits.Last());
			if (_content == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "Reference": _changed = _content.Reference != _data; _content.Reference = _data; break;
				case "HtmlContent": _changed = _content.HtmlContent != _data; _content.HtmlContent = _data; break;
				case "TextContent": _changed = _content.TextContent != _data; _content.TextContent = _data; break;
				case "ContentSelector": bool bContentSelector = false; if (bool.TryParse(_data, out bContentSelector)) {  _changed = _content.ContentSelector != bContentSelector; _content.ContentSelector = bContentSelector; }; break;
			}
			SaveContent(_content);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _content.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
