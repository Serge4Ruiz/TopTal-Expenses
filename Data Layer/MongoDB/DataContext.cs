using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace TopTal.Expenses.DataLayer.MongoDB
{
	public class DataContext
	{
		internal const string CONNECTION_STRING = "mongodb://localhost/TopTal/?safe=true";
		internal const string DATABASE_SCHEMA = "Expenses";

		internal static MongoDatabase Database;
		internal static List<TableProperty> TableProperties = new List<TableProperty>();

		static DataContext()
		{
			string connectionString = CONNECTION_STRING;
			if (ConfigurationManager.AppSettings["ConnectionString"] != null)
				connectionString = ConfigurationManager.AppSettings["ConnectionString"];
			string databaseSchema = DATABASE_SCHEMA;
			if (ConfigurationManager.AppSettings["DatabaseSchema"] != null)
				databaseSchema = ConfigurationManager.AppSettings["DatabaseSchema"];
			var server = MongoServer.Create(connectionString);
			Database = server.GetDatabase(databaseSchema);
		}

		public void ResetDB()
		{
			foreach (string name in Database.GetCollectionNames())
			{
				if (name == "system.indexes")
					continue;
				Database.DropCollection(name);
			}
		}
	}
}
