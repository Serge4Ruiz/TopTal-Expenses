using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TopTal.Expenses.ServiceLayer.Exporters
{
	public class BaseDocument
	{
		/// <summary>
		/// This is the root for all files
		/// </summary>
		protected static string _root;
		/// <summary>
		/// This is a path under the root where the file will be saved
		/// </summary>
		private string _path;
		/// <summary>
		/// The relative converted path under the root for web use
		/// </summary>
		private string _webPath;
		/// <summary>
		/// Holds the destination folder
		/// </summary>
		private DirectoryInfo _folder;
		/// <summary>
		/// Name of the File, without extension
		/// </summary>
		private string _fileName;
		/// <summary>
		/// Extension that will be added but not repeated
		/// </summary>
		protected string _extension;

		static BaseDocument()
		{
			_root = ConfigurationManager.AppSettings["DocRoot"];
		}

		/// <summary>
		/// Sets the root folder for the document(s)
		/// </summary>
		/// <param name="root"></param>
		internal BaseDocument(params string[] folderNames)
		{
			if (_root == null)
				_root = ConfigurationManager.AppSettings["DocRoot"];
			_folder = new DirectoryInfo(_root);
			if (_root.IndexOf("Documents") < 0)
				_folder = _folder.CreateSubdirectory("Documents");
			foreach (string folderName in folderNames)
				_folder = _folder.CreateSubdirectory(folderName);
		}

		internal void RerouteFolder(string oldPath, string newPath)
		{
			_folder = new DirectoryInfo(FolderFullName.Replace(oldPath, newPath));
			if (!_folder.Exists)
				_folder.Create();
		}

		/// <summary>
		/// Sets the folder under the path
		/// </summary>
		public string FolderName
		{
			set
			{
				_path = value;
				_folder = _folder.CreateSubdirectory(value);
				_webPath = value.Replace("\\", "/");
			}
		}

		/// <summary>
		/// Gets the Folder where the file is saved
		/// </summary>
		public DirectoryInfo Folder
		{
			get
			{
				return _folder;
			}
		}

		/// <summary>
		/// Gets the full name of the path to the folder where the file is saved
		/// </summary>
		public string FolderFullName
		{
			get
			{
				return _folder.FullName;
			}
		}

		/// <summary>
		/// This should be the file's name, without extension
		/// </summary>
		public string FileName
		{
			set { _fileName = value; }
			get
			{
				string fileName = _fileName + _extension;
				fileName = fileName.Replace(_extension + _extension, _extension);
				return fileName;
			}
		}

		/// <summary>
		/// Gets the full name of the (to be) saved file
		/// </summary>
		public string FileFullName
		{
			get
			{
				string fileFullName = Path.Combine(FolderFullName, FileName);
				FileInfo info = new FileInfo(fileFullName);
				if (info.Extension != _extension)
					fileFullName += _extension;
				return fileFullName;
			}
		}

		/// <summary>
		/// Gets the (to be) saved fie
		/// </summary>
		public FileInfo File
		{
			get
			{
				return new FileInfo(FileFullName);
			}
		}

		public string WebPath
		{
			get
			{
				return _folder.FullName.Replace(_root, "").Replace("\\", "/") + "/" + FileName;
			}
		}
	}
}
