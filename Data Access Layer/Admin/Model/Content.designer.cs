using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using LC.Core.Engine.Extensions;
using MongoDB.Bson;
using TopTal.Expenses.DataLayer.MongoDB.Admin;

namespace TopTal.Expenses.DataAccessLayer.Admin.Model
{
	public partial class Content : IModel
	{
		public const string FIELD_REFERENCE = "Reference";
		public const string FIELD_HTMLCONTENT = "HtmlContent";
		public const string FIELD_TEXTCONTENT = "TextContent";
		public const string FIELD_CONTENTSELECTOR = "ContentSelector";

		public enum Fields
		{
			Soid,
			SqlId,
			Reference,
			HtmlContent,
			TextContent,
			ContentSelector,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string Reference { set; get; }
		public string HtmlContent { set; get; }
		public string TextContent { set; get; }
		public bool ContentSelector { set; get; }

		public Content() { }

		public Content(DataLayer.MongoDB.Admin.Content content)
		{
			if (content == null)
				return;
			Soid = content.Id.ToString();
			SqlId = content.SqlId;
			Reference = content.Reference;
			HtmlContent = content.HtmlContent;
			TextContent = content.TextContent;
			ContentSelector = content.ContentSelector;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "Reference": return Reference;
				case "HtmlContent": return HtmlContent;
				case "TextContent": return TextContent;
				case "ContentSelector": return ContentSelector;

				default: return null;
			}
		}

		public DataLayer.MongoDB.Admin.Content ToModel()
		{
			var content = new DataLayer.MongoDB.Admin.Content();
			if (!Soid.IsNullOrEmpty())
				content.ResetId(Soid);
			content.SqlId = SqlId;
			content.Reference = Reference;
			content.HtmlContent = HtmlContent;
			content.TextContent = TextContent;
			content.ContentSelector = ContentSelector;

			return content;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("Reference");
				fieldNames.Add("HtmlContent");
				fieldNames.Add("TextContent");
				fieldNames.Add("ContentSelector");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 17;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("Reference ".PadRight(fieldNameMaxWidth, '.') + " " + Reference);
			sb.AppendLine("HtmlContent ".PadRight(fieldNameMaxWidth, '.') + " " + HtmlContent);
			sb.AppendLine("TextContent ".PadRight(fieldNameMaxWidth, '.') + " " + TextContent);
			sb.AppendLine("ContentSelector ".PadRight(fieldNameMaxWidth, '.') + " " + ContentSelector.ToString());

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">Reference [" + Reference + "]< ");
			sb.Append(">HtmlContent [" + HtmlContent + "]< ");
			sb.Append(">TextContent [" + TextContent + "]< ");
			sb.Append(">ContentSelector [" + ContentSelector.ToString() + "]< ");

			return sb.ToString();
		}
	}
}
