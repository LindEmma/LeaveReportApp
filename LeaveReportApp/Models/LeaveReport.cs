using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LeaveReportApp.Data.Enum;

namespace LeaveReportApp.Models
{
    public class LeaveReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveReportId { get; set; }

        [Required(ErrorMessage ="Var vänlig välj ett startdatum")]
        [Display(Name ="Startdatum")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Var vänlig välj ett slutdatum")]
        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name ="Ansöksdatum")]
        [DataType(DataType.Date)]
        public DateTime LeaveReportDate { get; set; }
        [Required]

        [EnumDataType(typeof(LeaveType))]
        [Display(Name ="Anledning")]
        public LeaveType LeaveType { get; set; }
        [ForeignKey(name:"Employee")]
        public int FkEmployeeId { get; set; }
        [Display(Name = "Anställd")]
        public Employee? Employee { get; set; }



        public LeaveReport()
        {
            LeaveReportDate = DateTime.Now;
        }
    }
   
}
