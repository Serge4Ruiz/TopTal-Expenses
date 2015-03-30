using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.ServiceLayer.Admin
{
	public partial class FileUploadManager
	{
		string _fieldName;
		string[] _fieldBits;
		string _data;
		string _display;
		bool _changed;
		Model.FileUpload _fileUpload;

		public string SaveFileUpload(Model.FileUpload fileUpload)
		{
			var mgr = new DataAccessLayer.Admin.FileUploadManager();
			return mgr.SaveFileUpload(fileUpload.ToModel());
		}

		public void DeleteFileUpload(string soid)
		{
			var mgr = new DataAccessLayer.Admin.FileUploadManager();
			mgr.DeleteFileUpload(soid);
		}

		public Model.FileUpload GetFileUpload(string soid)
		{
			var mgr = new DataAccessLayer.Admin.FileUploadManager();
			return new Model.FileUpload(mgr.GetFileUpload(soid));
		}

		public Model.FileUpload GetFileUploadFromSqlId(int id)
		{
			var mgr = new DataAccessLayer.Admin.FileUploadManager();
			var fileUpload = mgr.GetFileUploadFromSqlId(id);
			if (fileUpload == null)
				return null;
			return new Model.FileUpload(fileUpload);
		}

		public IEnumerable<Model.FileUpload> GetFileUploadList()
		{
			var mgr = new DataAccessLayer.Admin.FileUploadManager();
			foreach (var fileUpload in mgr.GetFileUploadList())
				yield return new Model.FileUpload(fileUpload);
		}

		public void Clear()
		{
			var mgr = new DataAccessLayer.Admin.FileUploadManager();
			mgr.Clear();
		}

		public LC.Core.Engine.Utility.UpdateResult Update(string fieldName, string data)
		{
			_fieldBits = fieldName.Split('-');
			_fieldName = _fieldBits.First();
			_data = data;
			_display = data;
			_fileUpload = GetFileUpload(_fieldBits.Last());
			if (_fileUpload == null)
				return null;
			TransformData();
			switch (_fieldBits.First())
			{
				case "FileName": _changed = _fileUpload.FileName != _data; _fileUpload.FileName = _data; break;
				case "Size": int iSize = 0; if (int.TryParse(_data, out iSize)) { _changed = _fileUpload.Size != iSize; _fileUpload.Size = iSize; }; break;
				case "Destination": _changed = _fileUpload.Destination != _data; _fileUpload.Destination = _data; break;
				case "TargetName": _changed = _fileUpload.TargetName != _data; _fileUpload.TargetName = _data; break;
			}
			SaveFileUpload(_fileUpload);
			return new LC.Core.Engine.Utility.UpdateResult() { FieldName = _fieldName, Soid = _fileUpload.Soid, Data = _data, Display = _display, Changed = _changed };
		}

		partial void TransformData();
	}
}
