using System.Data.Entity.ModelConfiguration;

namespace DrawNet.Lib.DataContext.Tables
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

    public class ReportConfiguration : EntityTypeConfiguration<Report>
    {
        public ReportConfiguration()
        {
            Property(r => r.ReportName).HasMaxLength(120).IsRequired();
        }

    }
}
