﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class PosDAL
	{
		public static int SavePos(PosModel pm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SavePos", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@PosTitle", pm.PosTitle);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<PosModel> GetPos()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetPos", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<PosModel> Poslist = new List<PosModel>();
			while (sdr.Read())
			{
				PosModel pos = new PosModel();
				pos.PosID = int.Parse(sdr["PosID"].ToString());
				pos.PosTitle = sdr["PosTitle"].ToString();
				Poslist.Add(pos);
			}
			con.Close();
			return Poslist;
		}

		public static int DeletePos(int PosID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeletePos", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@PosID", PosID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}
