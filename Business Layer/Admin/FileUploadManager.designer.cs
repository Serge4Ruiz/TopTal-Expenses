using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.BusinessLayer.Admin
{
	public partial class FileUploadManager
	{
		public string SaveFileUpload(Model.FileUpload fileUpload)
		{
			var mgr = new ServiceLayer.Admin.FileUploadManager();
			return mgr.SaveFileUpload(fileUpload.ToModel());
		}

		public void DeleteFileUpload(string soid)
		{
			var mgr = new ServiceLayer.Admin.FileUploadManager();
			mgr.DeleteFileUpload(soid);
		}

		public Model.FileUpload GetFileUpload(string soid)
		{
			var mgr = new ServiceLayer.Admin.FileUploadManager();
			return new Model.FileUpload(mgr.GetFileUpload(soid));
		}

		public IEnumerable<Model.FileUpload> GetFileUploadList()
		{
			var mgr = new ServiceLayer.Admin.FileUploadManager();
			foreach (var fileUpload in mgr.GetFileUploadList())
				yield return new Model.FileUpload(fileUpload);
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			var mgr = new ServiceLayer.Admin.FileUploadManager();
			return mgr.Update(fieldName, data);
		}
	}
}
