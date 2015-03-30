using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	public partial class FileUploadDB : DocumentList<FileUpload>
	{
		public FileUploadDB()
			: base(new FileUpload())
		{
		}

		public static string SaveFileUpload(FileUpload fileUpload)
		{
			var db = new FileUploadDB();
			db.Save(fileUpload);
			return fileUpload.Id.ToString();
		}

		public static FileUpload GetFileUpload(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				return GetFileUpload(oid);
			return null;
		}

		public static FileUpload GetFileUploadFromSqlId(int id)
		{
			var db = new FileUploadDB();
			return db.GetDocuments().SingleOrDefault(d => d.SqlId == id);
		}

		public static FileUpload GetFileUpload(ObjectId oid)
		{
			var db = new FileUploadDB();
			return db.GetDocument(oid);
		}
	}
}
