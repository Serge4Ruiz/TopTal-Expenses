using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TopTal.Expenses.DataLayer.MongoDB
{
	public class BaseObject
	{
		[BsonId]
		public ObjectId Id { internal set; get; }
		public int SqlId { set; get; }

		public BaseObject()
		{
			Id = ObjectId.GenerateNewId(DateTime.UtcNow);
		}

		public void CreateId()
		{
			Id = ObjectId.GenerateNewId();
		}

		public void ResetId(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
			{
				if (oid == ObjectId.Empty)
					throw new Exception("Empty Id");
				Id = oid;
			}
			else
				throw new Exception("Invalid Id");
		}
	}
}
