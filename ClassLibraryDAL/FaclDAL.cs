using System;
using System.Data;
using System.Data.SqlClient;
using FacultyProject.Models;

namespace FacultyProject.DAL
{
    public class FaclDAL
    {
        private readonly string connectionString;

        public FaclDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int AddProject(FaclModel facl)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO FacultyProject (ProjectName, ProjectDetails, StartDate, EndDate) VALUES (@ProjectName, @ProjectDetails, @StartDate, @EndDate)", connection);

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

        public DataTable GetProjects()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM FacultyProject", connection);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();

                connection.Open();
                adapter.Fill(table);

                return table;
            }
        }
    }
}

