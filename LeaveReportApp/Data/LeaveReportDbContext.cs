using Microsoft.EntityFrameworkCore;
using LeaveReportApp.Models;

namespace LeaveReportApp.Data
{
    public class LeaveReportDbContext: DbContext
    {
        public LeaveReportDbContext(DbContextOptions<LeaveReportDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveReport> LeaveReports { get; set; }
    }
}
