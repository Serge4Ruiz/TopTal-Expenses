using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace TopTal.Expenses.DataLayer.MongoDB
{
	public class DocumentReference
	{
		private Dictionary<string, string> _properties;

		public ObjectId Oid { private set; get; }
		public string Name { private set; get; }
		public Dictionary<string, string> Properties
		{
			private set { _properties = value; }
			get
			{
				if (_properties == null)
					_properties = new Dictionary<string, string>();
				return _properties;
			}
		}

		public DocumentReference(ObjectId oid, string name)
		{
			Oid = oid;
			Name = name;
		}
	}
}
