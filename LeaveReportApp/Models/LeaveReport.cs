using LeaveReportApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveReportApp.Models
{
    public class LeaveReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveReportId { get; set; }

        [Required(ErrorMessage = "Var vänlig välj ett startdatum")]
        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Var vänlig välj ett slutdatum")]
        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Ansöksdatum")]
        [DataType(DataType.Date)]
        public DateTime LeaveReportDate { get; set; }
        [Required]

        [EnumDataType(typeof(LeaveType))]
        [Display(Name = "Anledning")]
        public LeaveType LeaveType { get; set; }
        [ForeignKey(name: "Employee")]
        [Display(Name = "Anställd")]
        public int FkEmployeeId { get; set; }
        [Display(Name = "Anställd")]
        public Employee? Employee { get; set; }



        public LeaveReport()
        {
            LeaveReportDate = DateTime.Now; //sets the leave report date automatically when report is created 
        }
    }

}
