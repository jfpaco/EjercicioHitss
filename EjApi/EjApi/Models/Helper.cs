using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EjApi.Models
{
	public class Helper
	{
		public static string GetConnectionString()
		{
			var configurationBuilder = new ConfigurationBuilder();
			string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
			configurationBuilder.AddJsonFile(path, false);
			return configurationBuilder.Build().GetSection("ConnectionString:DB").Value;
		}

		public static List<T> DataTableToList<T>(DataTable dt)
		{
			List<T> data = new List<T>();
			foreach (DataRow row in dt.Rows)
			{
				T item = GetItem<T>(row);
				data.Add(item);
			}
			return data;
		}
		private static T GetItem<T>(DataRow dr)
		{
			Type temp = typeof(T);
			T obj = Activator.CreateInstance<T>();

			foreach (DataColumn column in dr.Table.Columns)
			{
				foreach (PropertyInfo pro in temp.GetProperties())
				{
					if (pro.Name == column.ColumnName)
						pro.SetValue(obj, dr[column.ColumnName], null);
					else
						continue;
				}
			}
			return obj;
		}
	}
}
