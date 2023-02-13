using System;
using System.Data;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class StudentDAL
	{
		public static int SaveStudent(StudentModel studentModel)
		{
			int result = 0;

			using (SqlConnection con = DBHelper.GetConnection())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand("spSaveStudent", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@StudentID", studentModel.StudentID);
				cmd.Parameters.AddWithValue("@StudentName", studentModel.StudentName);
				cmd.Parameters.AddWithValue("@FatherName", studentModel.FatherName);
				cmd.Parameters.AddWithValue("@MotherName", studentModel.MotherName);
				cmd.Parameters.AddWithValue("@Email", studentModel.Email);
				cmd.Parameters.AddWithValue("@ContactNo", studentModel.ContactNo);
				cmd.Parameters.AddWithValue("@Address", studentModel.Address);
				cmd.Parameters.AddWithValue("@Gender", studentModel.Gender);
				cmd.Parameters.AddWithValue("@DOB", studentModel.DOB);

				result = cmd.ExecuteNonQuery();

				con.Close();
			}

			return result;
		}

		public static DataTable GetStudents()
		{
			DataTable dt = new DataTable();

			using (SqlConnection con = DBHelper.GetConnection())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand("spGetStudents", con);
				cmd.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				con.Close();
			}

			return dt;
		}

		public static int DeleteStudent(int studentID)
		{
			int result = 0;

			using (SqlConnection con = DBHelper.GetConnection())
			{
				con.Open();

				SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@StudentID", studentID);

				result = cmd.ExecuteNonQuery();

				con.Close();
			}

			return result;
		}
	}
}
