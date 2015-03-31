using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Admin
{
	public partial class ContentManager
	{
		public string SaveContent(Model.Content content)
		{
			var mgr = new ServiceLayer.Admin.ContentManager();
			return mgr.SaveContent(content.ToModel());
		}

		public void DeleteContent(string soid)
		{
			var mgr = new ServiceLayer.Admin.ContentManager();
			mgr.DeleteContent(soid);
		}

		public Model.Content GetContent(string soid)
		{
			var mgr = new ServiceLayer.Admin.ContentManager();
			return new Model.Content(mgr.GetContent(soid));
		}

		public IEnumerable<Model.Content> GetContentList()
		{
			var mgr = new ServiceLayer.Admin.ContentManager();
			foreach (var content in mgr.GetContentList())
				yield return new Model.Content(content);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Admin.ContentManager();
			return mgr.Update(fieldName, data);
		}
	}
}
