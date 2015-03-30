using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LC.Core.Engine;
using TopTal.Expenses.ServiceLayer.Admin;

namespace TopTal.Expenses.BusinessLayer.Admin.Model
{
	public partial class FileUpload : IModel
	{
		public const string FIELD_FILENAME = "FileName";
		public const string FIELD_SIZE = "Size";
		public const string FIELD_DESTINATION = "Destination";
		public const string FIELD_TARGETNAME = "TargetName";

		public enum Fields
		{
			Soid,
			SqlId,
			FileName,
			Size,
			Destination,
			TargetName,
		}

		public string Soid { set; get; }
		public int SqlId { set; get; }
		public string FileName { set; get; }
		public int Size { set; get; }
		public string Destination { set; get; }
		public string TargetName { set; get; }

		public FileUpload() {}

		public FileUpload(ServiceLayer.Admin.Model.FileUpload fileUpload)
		{
			if (fileUpload == null)
				return;
			Soid = fileUpload.Soid;
			SqlId = fileUpload.SqlId;
			FileName = fileUpload.FileName;
			Size = fileUpload.Size;
			Destination = fileUpload.Destination;
			TargetName = fileUpload.TargetName;
		}

		public object GetValue(string fieldName)
		{
			switch (fieldName)
			{
				case "Soid": return Soid;
				case "SqlId": return SqlId;
				case "FileName": return FileName;
				case "Size": return Size;
				case "Destination": return Destination;
				case "TargetName": return TargetName;

				default: return null;
			}
		}

		public ServiceLayer.Admin.Model.FileUpload ToModel()
		{
			var fileUpload = new ServiceLayer.Admin.Model.FileUpload();
			fileUpload.Soid = Soid;
			fileUpload.SqlId = SqlId;
			fileUpload.FileName = FileName;
			fileUpload.Size = Size;
			fileUpload.Destination = Destination;
			fileUpload.TargetName = TargetName;

			return fileUpload;
		}

		public List<string> FieldNames
		{
			get
			{
				List<string> fieldNames = new List<string>();
				fieldNames.Add("Soid");
				fieldNames.Add("SqlId");
				fieldNames.Add("FileName");
				fieldNames.Add("Size");
				fieldNames.Add("Destination");
				fieldNames.Add("TargetName");

				return fieldNames;
			}
		}

		public string ToCardString()
		{
			int fieldNameMaxWidth = 13;
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Soid ".PadRight(fieldNameMaxWidth, '.') + " " + Soid);
			sb.AppendLine("SqlId ".PadRight(fieldNameMaxWidth, '.') + " " + SqlId.ToString());
			sb.AppendLine("FileName ".PadRight(fieldNameMaxWidth, '.') + " " + FileName);
			sb.AppendLine("Size ".PadRight(fieldNameMaxWidth, '.') + " " + Size.ToString());
			sb.AppendLine("Destination ".PadRight(fieldNameMaxWidth, '.') + " " + Destination);
			sb.AppendLine("TargetName ".PadRight(fieldNameMaxWidth, '.') + " " + TargetName);

			return sb.ToString();
		}

		public string ToRowString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(">Soid [" + Soid + "]< ");
			sb.Append(">SqlId [" + SqlId.ToString() + "]< ");
			sb.Append(">FileName [" + FileName + "]< ");
			sb.Append(">Size [" + Size.ToString() + "]< ");
			sb.Append(">Destination [" + Destination + "]< ");
			sb.Append(">TargetName [" + TargetName + "]< ");

			return sb.ToString();
		}
	}
}
