using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Repository_Cached_Services.Models
{
    public class JobModel
    {
        public int Job_id { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string TechniciansAssigned { get; set; }
        public decimal Estimate { get; set; }
    }
    public class JobModelList
    {
        public List<JobModel> Jml { get; set; }
    }
}