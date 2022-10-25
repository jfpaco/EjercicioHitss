using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using EjApi.Models;

namespace EjApi.Services
{
	public class ClienteService
	{
		private SqlConnection sqlCon = null;

		public ClienteService()
		{

		}

		public List<Cliente> obtener(int id = 0)
		{
			return GClientes(id);
		}


		private List<Cliente> GClientes(int id = 0)
		{
			using (sqlCon = new SqlConnection(Helper.GetConnectionString()))
			{
				sqlCon.Open();
				SqlCommand sql_cmnd = new SqlCommand("st_Get", sqlCon);
				sql_cmnd.CommandType = CommandType.StoredProcedure;
				sql_cmnd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
				sql_cmnd.ExecuteNonQuery();
				var adapter = new SqlDataAdapter(sql_cmnd);
				var datatable = new DataTable();
				adapter.Fill(datatable);
				sqlCon.Close();

				return Helper.DataTableToList<Cliente>(datatable);
			}
		}

	}

}
