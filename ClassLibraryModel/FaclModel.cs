using System;
using System.ComponentModel.DataAnnotations;

namespace FacultyProject.Models
{
    public class ProjectModel
    {  
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public string ProjectDetails { get; set; }
        public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set; }
    }
}