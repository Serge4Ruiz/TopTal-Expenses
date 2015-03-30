using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class FileUpload : BaseDocument
	{
		public const string FIELD_FILENAME = "FileName";
		public const string FIELD_SIZE = "Size";
		public const string FIELD_DESTINATION = "Destination";
		public const string FIELD_TARGETNAME = "TargetName";

		public string FileName { set; get; }
		public int Size { set; get; }
		public string Destination { set; get; }
		public string TargetName { set; get; }

		public FileUpload()
			: base()
		{
		}
	}
}
