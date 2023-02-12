using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
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
