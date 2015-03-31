using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB
{
	public class TableProperty
	{
		public ObjectId Id { set; get; }
		public string Name { set; get; }
		public string Caption { set; get; }
		public string Captions { set; get; }
		public string UrlTemplate { set; get; }
	}
}
