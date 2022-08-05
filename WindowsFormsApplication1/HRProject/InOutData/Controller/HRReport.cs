using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.HRProject.InOutData.Model;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller
{

    public class HRReport
    {
        public string PathAttendanceDaily = Environment.CurrentDirectory + @"\Resources\AttendanceDaily.xlsx";
        public string PathAbsenceDaily = Environment.CurrentDirectory + @"\Resources\AbsenceForm_v1.xlsx";
        public string PathTimekeeping = Environment.CurrentDirectory + @"\Resources\TimekeepingForm.xlsx";
        public void ExportExcelHRAttendaceReport(string PathSave, List<AttendanceDept> attendanceDepts, DateTime date)
        {
            Class.ToolSupport toolSupport = new Class.ToolSupport();
            toolSupport.ExportAttendanceDaily(attendanceDepts, PathSave, PathAttendanceDaily, date);
        }

        public void ExportExcelAbsenceReport(string PathSave, List<EmployeeAbsence> employeeAbsences,DateTime date)
        {
            Class.ToolSupport toolSupport = new Class.ToolSupport();
            toolSupport.ExportAbsenceDaily(employeeAbsences, PathSave, PathAbsenceDaily, date);
        }
        public void ExportExcelTimekeepingReport(string PathSave, List<EmployeeTimekeeping> employeeTimekeepings, DateTime date)
        {
            Class.ToolSupport toolSupport = new Class.ToolSupport();
            toolSupport.ExportTimeKeepingDaily(employeeTimekeepings, PathSave, PathTimekeeping, date);
        }
    }
}
