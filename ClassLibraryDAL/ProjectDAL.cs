using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class ProjectDAL
    {
        private readonly string connectionString;

        public ProjectDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int AddProject(ProjectModel facl)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO FacultyProject (ProjectName,FacultyName, ProjectDetails, StartDate, EndDate) VALUES (@ProjectName, @ProjectDetails, @StartDate, @EndDate)", connection);

                cmd.Parameters.AddWithValue("@ProjectName", facl.ProjectName);
                cmd.Parameters.AddWithValue("@FacultyName", facl.FacultyName);
                cmd.Parameters.AddWithValue("@ProjectName", facl.ProjectName);
				cmd.Parameters.AddWithValue("@ProjectDetails", facl.ProjectDetails);
                cmd.Parameters.AddWithValue("@StartDate", facl.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", facl.EndDate);

                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int DeleteProject(int faclID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("DELETE FROM FacultyProject WHERE ProjectID = @ProjectID", connection);
                cmd.Parameters.AddWithValue("@ProjectID", faclID);

                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int EditProject(int faclID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("Edit FROM FacultyProject WHERE ProjectID = @ProjectID", connection);
                cmd.Parameters.AddWithValue("@ProjectID", faclID);

                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int ProjectRequest(int faclID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("Response FROM FacultyProject WHERE ProjectID = @ProjectID", connection);
                cmd.Parameters.AddWithValue("@ProjectID", faclID);

                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int RequestResponse (int faclID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("RequestResponse FROM FacultyProject WHERE ProjectID = @ProjectID", connection);
                cmd.Parameters.AddWithValue("@ProjectID", faclID);

                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static List<ProjectModel> GetProjects()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetProjects", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<ProjectModel> Projectlist = new List<ProjectModel>();
            while (sdr.Read())
            {
                ProjectModel projects = new ProjectModel();
                projects.ProjectID = int.Parse(sdr["ProjectID"].ToString());
                projects.FacultyName = sdr["FacultyName"].ToString();
                projects.ProjectName = sdr["ProjectName"].ToString();
                projects.ProjectDetails = sdr["ProjectDetails"].ToString();
                projects.StartDate = Convert.ToDateTime(sdr["StartDate"].ToString());
                projects.EndDate = Convert.ToDateTime(sdr["EndDate"].ToString());
                Projectlist.Add(projects);
            }

            con.Close();
            return Projectlist;
        }

        /* public DataTable GetProjects()
         {
             using (var connection = new SqlConnection(connectionString))
             {
                 var cmd = new SqlCommand("SELECT * FROM Projects", connection);
                 var adapter = new SqlDataAdapter(cmd);
                 var table = new DataTable();

                 connection.Open();
                 adapter.Fill(table);

                 return table;
             }
         }*/
    }
}

 
