using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin
{
	public partial class FileUploadManager
	{
		public string SaveFileUpload(Model.FileUpload fileUpload)
		{
			return FileUploadDB.SaveFileUpload(fileUpload.ToModel());
		}

		public void DeleteFileUpload(string soid)
		{
			var db = new FileUploadDB();
			db.Delete(soid);
		}

		public Model.FileUpload GetFileUpload(string soid)
		{
			return new Model.FileUpload(FileUploadDB.GetFileUpload(soid));
		}

		public Model.FileUpload GetFileUploadFromSqlId(int id)
		{
			var fileUpload = FileUploadDB.GetFileUploadFromSqlId(id);
			if (fileUpload == null)
				return null;
			return new Model.FileUpload(fileUpload);
		}

		public IEnumerable<Model.FileUpload> GetFileUploadList()
		{
			var db = new FileUploadDB();
			foreach (var fileUpload in db.GetDocuments())
				yield return new Model.FileUpload(fileUpload);
		}

		public void Clear()
		{
			var mgr = new DataLayer.MongoDB.Admin.FileUploadDB();
			mgr.Clear();
		}
	}
}
