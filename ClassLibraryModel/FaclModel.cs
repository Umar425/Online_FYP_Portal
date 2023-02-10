using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
	public class FaclModel
	{
		public int FaclID { get; set; }
		public string? FaclFirstName { get; set; }
		public string? FaclLastName { get; set; }
		public string? FaclPhoneNo { get; set; }
		public string? FaclEmail { get; set; }
		public string? FaclAddress { get; set; }
		public int PosID { get; set; }
		public int ExpID { get; set; }
		public int QualID { get; set; }
		public int DeptID { get; set; }
		public int OrgID { get; set; }

	}
	namespace ProjectManagement.Models
	{
		public class FacultyModel
		{
			public int ? ProjectId { get; set; }
			public string ? ProjectName { get; set; }
			public string ? ProjectDetails { get; set; }
		}

		namespace FaclDAL
		{
			public class ProjectDataAccessLayer
			{
				private readonly string _connectionString;

				public ProjectDataAccessLayer(string connectionString)
				{
					_connectionString = connectionString;
				}

				public int SaveProject(FacultyModel project)
				{
					using (SqlConnection con = new SqlConnection(_connectionString))
					{
						con.Open();
						SqlCommand cmd = new SqlCommand("Sp_SaveProject", con);
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@ProjectName", project.ProjectName);
						cmd.Parameters.AddWithValue("@ProjectDetails", project.ProjectDetails);
						int i = cmd.ExecuteNonQuery();
						con.Close();
						return i;
					}
				}

				public List<FacultyModel> GetProjects()
				{
					using (SqlConnection con = new SqlConnection(_connectionString))
					{
						con.Open();
						SqlCommand cmd = new SqlCommand("Sp_GetProjects", con);
						cmd.CommandType = CommandType.StoredProcedure;
						SqlDataReader sdr = cmd.ExecuteReader();
						List<FacultyModel> projectList = new List<FacultyModel>();
						while (sdr.Read())
						{
							FacultyModel project = new FacultyModel();
							project.ProjectId = int.Parse(sdr["ProjectId"].ToString());
							project.ProjectName = sdr["ProjectName"].ToString();
							project.ProjectDetails = sdr["ProjectDetails"].ToString();
							projectList.Add(project);
						}

						con.Close();
						return projectList;
					}
				}

				public int DeleteProject(int projectId)
				{
					using (SqlConnection con = new SqlConnection(_connectionString))
					{
						con.Open();
						SqlCommand cmd = new SqlCommand("Sp_DeleteProject", con);
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@ProjectId", projectId);
						int i = cmd.ExecuteNonQuery();
						con.Close();
						return i;
					}
				}
			}
		}
	}
}