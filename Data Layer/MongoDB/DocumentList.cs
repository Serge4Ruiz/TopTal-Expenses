using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace TopTal.Expenses.DataLayer.MongoDB
{
	public class DocumentList<T>
	{
		private static string _collectionName;

		public void Clear()
		{
			DataContext.Database.GetCollection<T>(_collectionName).Drop();
		}

		private DocumentList()
		{
		}

		internal DocumentList(BaseDocument collection)
		{
			_collectionName = collection.GetType().FullName;
		}

		public void Insert(T document)
		{
			var collection = GetCollection();
			collection.Insert(document);
			collection.Save(document);
		}

		protected MongoCollection<T> GetCollection()
		{
			return DataContext.Database.GetCollection<T>(_collectionName);
		}

		public T GetDocument(ObjectId oid)
		{
			var collection = GetCollection();
			var a = collection.AsQueryable<T>().First();
			return collection.FindOne(Query.EQ("_id", oid));
		}

		public IQueryable<T> GetDocuments()
		{
			return GetCollection().AsQueryable<T>();
		}

		public void Save(T document)
		{
			var collection = GetCollection();
			collection.Save(document);
		}

		public void Delete(ObjectId oid)
		{
			var collection = GetCollection();
			var a = collection.Remove(Query.EQ("_id", oid));
		}

		public void Delete(string soid)
		{
			ObjectId oid = new ObjectId();
			if (ObjectId.TryParse(soid, out oid))
				Delete(oid);
		}

		public void Drop()
		{
			var collection = GetCollection();
			collection.Drop();
		}

		public void AddTableProperties(string tableName, string caption, string captions, string url)
		{
			var collection = DataContext.Database.GetCollection<TableProperty>("tableProperties");
			TableProperty tableProperty = new TableProperty()
			{
				Name = tableName,
				Caption = caption,
				Captions = captions,
				UrlTemplate = url
			};
			collection.Insert(tableProperty);
			collection.Save(tableProperty);
		}

		public TableProperty GetTableProperty(string tableName)
		{
			var collection = DataContext.Database.GetCollection<TableProperty>("tableProperties");
			var query = Query.EQ("Name", tableName);
			return collection.FindOne(query);
		}
	}
}
