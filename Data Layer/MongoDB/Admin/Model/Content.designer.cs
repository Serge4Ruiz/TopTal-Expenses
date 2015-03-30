using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB.Admin
{
	[BsonIgnoreExtraElements]
	public partial class Content : BaseDocument
	{
		public const string FIELD_REFERENCE = "Reference";
		public const string FIELD_HTMLCONTENT = "HtmlContent";
		public const string FIELD_TEXTCONTENT = "TextContent";
		public const string FIELD_CONTENTSELECTOR = "ContentSelector";

		public string Reference { set; get; }
		public string HtmlContent { set; get; }
		public string TextContent { set; get; }
		public bool ContentSelector { set; get; }

		public Content()
			: base()
		{
		}
	}
}
