﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;
using System.Data.Common;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ClassLibraryDAL
{
	public class FaclDAL
	{
		public static int SaveFacl(FaclModel fm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveFacl", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FaclFirstName", fm.FaclFirstName);
			cmd.Parameters.AddWithValue("@FaclLastName", fm.FaclLastName);
			cmd.Parameters.AddWithValue("@FaclPhoneNo", fm.FaclPhoneNo);
			cmd.Parameters.AddWithValue("@FaclEmail", fm.FaclEmail);
			cmd.Parameters.AddWithValue("@FaclAddress", fm.FaclAddress);
			cmd.Parameters.AddWithValue("@PosID", fm.PosID);
			cmd.Parameters.AddWithValue("@ExpID", fm.ExpID);
			cmd.Parameters.AddWithValue("@QualID", fm.QualID);
			cmd.Parameters.AddWithValue("@DeptID", fm.DeptID);
			cmd.Parameters.AddWithValue("@OrgID", fm.OrgID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<FaclModel> GetFacl()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetFacl", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<FaclModel> Facllist = new List<FaclModel>();
			while (sdr.Read())
			{

				FaclModel facl = new FaclModel();
				facl.FaclID = int.Parse(sdr["FaclID"].ToString());
				facl.FaclFirstName = sdr["FaclFirstName"].ToString();
				facl.FaclLastName = sdr["FaclLastName"].ToString();
				facl.FaclPhoneNo = sdr["FaclPhoneNo"].ToString();
				facl.FaclEmail = sdr["FaclEmail"].ToString();
				facl.FaclAddress = sdr["FaclAddress"].ToString();
				facl.PosID = int.Parse(sdr["PosID"].ToString());
				facl.ExpID = int.Parse(sdr["ExpID"].ToString());
				facl.QualID = int.Parse(sdr["QualID"].ToString());
				facl.DeptID = int.Parse(sdr["DeptID"].ToString());
				facl.OrgID = int.Parse(sdr["OrgID"].ToString());
				Facllist.Add(facl);
			}

			con.Close();
			return Facllist;
		}
	}
}
