using LeaveReportApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveReportApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name ="Förnamn")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [Display(Name ="Efternamn")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EnumDataType(typeof(Role))]
        [Display(Name ="Roll")]
        public Role? Roles { get; set; }
        public IList<LeaveReport>? LeaveReports;
    }
}
