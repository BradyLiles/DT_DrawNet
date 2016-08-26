using System.Data.Entity.ModelConfiguration;
using DrawNet.Lib.DataContext.Models;

namespace DrawNet.Lib.DataContext.DataLayer
{
    public class ReportConfiguration : EntityTypeConfiguration<Report>
    {
        public ReportConfiguration()
        {
            Property(r => r.ReportName).HasMaxLength(120).IsRequired();
        }
         
    }
}