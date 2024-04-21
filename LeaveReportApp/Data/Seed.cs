using LeaveReportApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveReportApp.Data
{
    public class Seed    //Seeds data to all the tables
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine("SeedData method is being executed.");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LeaveReportDbContext>();

                //if db is empty, fill tables
                context.Database.Migrate();

                ////Makes sure the tables are filled in the right order, due to their relationship keys
                SeedEmployees(context);
                SeedLeaveReports(context);
            }
        }

        //method to seed Employees to database
        private static void SeedEmployees(LeaveReportDbContext context)
        {
            //adds the employees only if the table is empty
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(new List<Employee>()
                {
                new Employee() { FirstName = "Emma", LastName = "Lind", Roles= Enum.Role.Rektor },
                new Employee() { FirstName = "Embert", LastName = "Lindbert", Roles=Enum.Role.Administratör },
                new Employee() { FirstName = "Emson", LastName = "Lindson", Roles=Enum.Role.Ämneslärare },
                new Employee() { FirstName = "Kurt", LastName = "Olsson", Roles=Enum.Role.Ämneslärare },
                new Employee() { FirstName = "Anna", LastName = "Persson", Roles=Enum.Role.Ämneslärare },
                new Employee() { FirstName = "Lorentz", LastName = "Lorentzon", Roles=Enum.Role.Skolsjuksköterska },
                new Employee() { FirstName = "Mowitz", LastName = "Lorentzdotter", Roles=Enum.Role.Vaktmästare },
                new Employee() { FirstName = "Bodil", LastName = "Bodilson", Roles=Enum.Role.Specialpedagog },
                new Employee() { FirstName = "Emma-Li", LastName = "Lison", Roles=Enum.Role.Vikarie },
            });
                context.SaveChanges();
            }
        }
        //method to seed leave reports to database
        private static void SeedLeaveReports(LeaveReportDbContext context)
        {
            if (!context.LeaveReports.Any())
            {
                var employee = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Emma"));
                var employee2 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Embert"));
                var employee3 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Emson"));
                var employee4 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Kurt"));
                var employee5 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Anna"));
                var employee6 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Lorentz"));
                var employee7 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Mowitz"));
                var employee8 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Bodil"));
                var employee9 = context.Employees.FirstOrDefault(t => t.FirstName.Contains("Emma-Li"));

                context.LeaveReports.AddRange(new List<LeaveReport>()
            {
                new LeaveReport() { StartDate = DateTime.Parse("2024-06-11"), EndDate = DateTime.Parse("2024-07-11"), LeaveReportDate= DateTime.Parse("2024-03-20"), LeaveType= Enum.LeaveType.Semester, FkEmployeeId =employee.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-04-20"), EndDate = DateTime.Parse("2024-04-20"), LeaveReportDate= DateTime.Parse("2024-04-19"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-07-15"), EndDate = DateTime.Parse("2024-08-20"), LeaveReportDate= DateTime.Parse("2024-03-22"), LeaveType= Enum.LeaveType.Semester, FkEmployeeId =employee2.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-01-20"), EndDate = DateTime.Parse("2024-01-22"), LeaveReportDate= DateTime.Parse("2024-01-20"), LeaveType= Enum.LeaveType.VAB, FkEmployeeId =employee3.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-05-01"), EndDate = DateTime.Parse("2024-01-05"), LeaveReportDate= DateTime.Parse("2023-02-01"), LeaveType= Enum.LeaveType.Föräldraledighet, FkEmployeeId =employee3.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-12-20"), EndDate = DateTime.Parse("2024-01-28"), LeaveReportDate= DateTime.Parse("2023-06-02"), LeaveType= Enum.LeaveType.Semester, FkEmployeeId =employee4.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-09-20"), EndDate = DateTime.Parse("2023-09-20"), LeaveReportDate= DateTime.Parse("2023-09-20"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee4.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-03-28"), EndDate = DateTime.Parse("2024-04-15"), LeaveReportDate= DateTime.Parse("2024-01-23"), LeaveType= Enum.LeaveType.Semester, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-10-05"), EndDate = DateTime.Parse("2023-10-07"), LeaveReportDate= DateTime.Parse("2023-10-05"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-11-05"), EndDate = DateTime.Parse("2023-11-07"), LeaveReportDate= DateTime.Parse("2023-11-05"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-08-20"), EndDate = DateTime.Parse("2023-08-25"), LeaveReportDate= DateTime.Parse("2023-08-25"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee6.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-05-02"), EndDate = DateTime.Parse("2023-05-04"), LeaveReportDate= DateTime.Parse("2023-05-05"), LeaveType= Enum.LeaveType.VAB, FkEmployeeId =employee5.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-05-05"), EndDate = DateTime.Parse("2025-08-07"), LeaveReportDate= DateTime.Parse("2024-02-28"), LeaveType= Enum.LeaveType.Föräldraledighet, FkEmployeeId =employee7.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-04-17"), EndDate = DateTime.Parse("2024-05-07"), LeaveReportDate= DateTime.Parse("2024-02-15"), LeaveType= Enum.LeaveType.Föräldraledighet, FkEmployeeId =employee8.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-10-04"), EndDate = DateTime.Parse("2023-10-04"), LeaveReportDate= DateTime.Parse("2023-10-04"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee9.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2024-02-05"), EndDate = DateTime.Parse("2024-02-05"), LeaveReportDate= DateTime.Parse("2024-02-05"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee9.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-11-24"), EndDate = DateTime.Parse("2023-11-24"), LeaveReportDate= DateTime.Parse("2023-11-24"), LeaveType= Enum.LeaveType.Sjukdom, FkEmployeeId =employee9.EmpId },
                new LeaveReport() { StartDate = DateTime.Parse("2023-06-05"), EndDate = DateTime.Parse("2023-07-07"), LeaveReportDate= DateTime.Parse("2023-03-11"), LeaveType= Enum.LeaveType.Semester, FkEmployeeId =employee5.EmpId },
            });
                context.SaveChanges();
            }
        }
    }
}

