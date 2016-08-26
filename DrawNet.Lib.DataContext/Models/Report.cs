using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawNet.Lib.DataContext.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }

    public enum ReportStatus
    {
        Created = 0,
        InProcess = 10,
        Rework = 15,
        Submitted = 20,
        Approved = 30,
        Canceled = -10,
        Rejected = -20
    }
}
