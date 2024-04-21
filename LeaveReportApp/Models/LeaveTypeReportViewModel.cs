using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveReportApp.Models
{
    public class LeaveTypeReportViewModel
    {
        public List<LeaveReport>? LeaveReports { get; set; }
        public SelectList? LeaveTypes { get; set; }
        public string? ReportLeaveType { get; set; }
        public string? SearchString { get; set; }
        public SelectList? Months { get; set; }
        public int? ReportMonth { get; set; } // Ny egenskap för att hålla månaden


    }
}