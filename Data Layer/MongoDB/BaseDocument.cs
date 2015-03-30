using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopTal.Expenses.DataLayer.MongoDB
{
	public class BaseDocument : BaseObject
	{
		/// <summary>
		/// Timestamp of object creation
		/// </summary>
		public DateTime Stamp { internal set; get; }

		protected BaseDocument()
		{
			Stamp = DateTime.UtcNow;
		}
	}
}
