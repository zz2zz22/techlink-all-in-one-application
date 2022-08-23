using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.HRProject.InOutData.Model;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking
{
  public  class GetdataInout
    {

        public DataTable GetDataTablelistAbsenceEmployee (DateTime date)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.emp_finger = s.CardNo
 where e.State = 0 and e.Dept not like '%999%'   and 
e.emp_finger not in (select CardNo from Kq_Source where 1=1 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' ) ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);


            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataTablelistAbsenceEmployee (DateTime date)", ex.Message);
            }
            return dt;
        }
        public List<EmployeeAbsence> GetEmployeeAbsences( DateTime date)
        {
            List<EmployeeAbsence> employeeAbsences = new List<EmployeeAbsence>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where  (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0' and
e.ID not in (select EmpID from Kq_Source where 1=1 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00'  and EmpID is not null ) ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAbsences.Add(new EmployeeAbsence
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString()

                    }) ;
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<EmployeeAbsence> GetEmployeeAbsences(DataTable dt, DateTime date)", ex.Message);
            }
            return employeeAbsences;
        }
        public List<EmployeeAttendance> GetEmployeeAttendances(DateTime date)
        {
            List<EmployeeAttendance> employeeAttendances = new List<EmployeeAttendance>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%') and e.State = '0' and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:59' and EmpID is not null ) ");
               // stringBuilder.Append("  and p.SessionID = (select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID) ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAttendances.Add(new EmployeeAttendance
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAttendances(DateTime date)", ex.Message);
            }
            return employeeAttendances;
        }

        public List<EmployeeAttendance> GetEmployeeAttendancesNightShift(DateTime date, int SessionID)
        {
            List<EmployeeAttendance> employeeAttendances = new List<EmployeeAttendance>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%') and e.State = '0'  and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1 ");
                stringBuilder.Append(" and ((cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00')   ");
                stringBuilder.Append(" or (cast(FDateTime as date)  = cast( '" + date.AddDays(1).ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append("  and convert(char(5), FDateTime, 108) >='00:01:00'  and convert(char(5), FDateTime, 108) < '12:00:00')) ");
                stringBuilder.Append(" and EmpID is not null ) ");

                stringBuilder.Append(" and p.B" + date.Day + "  in ('03','07') and p.SessionID = '"+ SessionID + "' ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAttendances.Add(new EmployeeAttendance
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Shift = "Night"
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAttendances(DateTime date)", ex.Message);
            }
            return employeeAttendances;
        }
        public List<EmployeeAttendance> GetEmployeeAttendancesDayShift(DateTime date, int SessionID)
        {
            List<EmployeeAttendance> employeeAttendances = new List<EmployeeAttendance>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%') and e.State = '0'  and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null ) ");
                stringBuilder.Append(" and p.B" + date.Day + " not  in ('03','07') and p.SessionID =  '"+ SessionID + "' " );
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAttendances.Add(new EmployeeAttendance
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Shift ="Day"
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAttendances(DateTime date)", ex.Message);
            }
            return employeeAttendances;
        }
        public List<EmployeeAttendance> GetEmployeeAttendancesSeasonalNight(DateTime date)
        {
            List<EmployeeAttendance> employeeAttendances = new List<EmployeeAttendance>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where  e.Dept like '%999%'  and 
e.ID  in (select EmpID from Kq_Source where 1=1
");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date )");
                stringBuilder.Append("  and convert(char(5), FDateTime, 108) >='18:00:00'  and convert(char(5), FDateTime, 108) < '23:59:00' ) ");
                stringBuilder.Append("  and e.ID  in (select EmpID from Kq_Source where  cast(FDateTime as date)  = cast( '" + date.AddDays(1).ToString("yyyyMMdd") + "' as date )  ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='08:00:00'  and convert(char(5), FDateTime, 108) < '09:00:00' ) ");

                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAttendances.Add(new EmployeeAttendance
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Shift = "Night"
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAttendances(DateTime date)", ex.Message);
            }
            return employeeAttendances;
        }
        public List<EmployeeAttendance> GetEmployeeAttendancesSeasonal(DateTime date)
        {
            List<EmployeeAttendance> employeeAttendances = new List<EmployeeAttendance>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select distinct  e.Code, e.Memo, e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
 left join Kq_Source s on s.EmpID = e.ID
 where  e.Dept  like '%999%'   and 
 
 e.ID  in (select EmpID from Kq_Source where 1=1
 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date )");
                stringBuilder.Append("  and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' ) ");
                stringBuilder.Append("  and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date )" );

                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAttendances.Add(new EmployeeAttendance
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAttendances(DateTime date)", ex.Message);
            }
            return employeeAttendances;
        }

        public List<EmployeeAttendance> GetEmployeeAttendancesSeasonalbyDept(string Dept, DateTime date)
        {
            List<EmployeeAttendance> employeeAttendances = new List<EmployeeAttendance>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select distinct  e.Code, e.Memo, e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
 left join Kq_Source s on s.EmpID = e.ID
 where  e.Dept  like '%999%'   and 
 e.Memo like '%" + Dept + "%' and e.State = 0 and " +
 "e.ID  in (select EmpID from Kq_Source where 1=1");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date )");
                stringBuilder.Append("  and convert(char(5), FDateTime, 108) >='00:00:00'  and convert(char(5), FDateTime, 108) < '23:59:59' ) ");
                stringBuilder.Append("  and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date )");

                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAttendances.Add(new EmployeeAttendance
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Memo = dt.Rows[i]["Memo"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetSeasonalEmployeeAttendancesbyDept(string Dept, DateTime date)", ex.Message);
            }
            return employeeAttendances;
        }
        public List<EmployeeAbsence> GetEmployeeAbsencesNightShift(DateTime date, int SessionID)
        {
            List<EmployeeAbsence> employeeAbsences = new List<EmployeeAbsence>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where  (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='12:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null ) ");
                stringBuilder.Append(" and p.B"+date.Day+ "  in ('03','07') and p.SessionID = '"+ SessionID +"' " );
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAbsences.Add(new EmployeeAbsence
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Shift = "Night"

                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAbsencesNightShift(DateTime date)", ex.Message);
            }
            return employeeAbsences;
        }
        
        public List<EmployeeAbsence> GetEmployeeAbsencesDayShift(DateTime date, int SessionID)
        {
            List<EmployeeAbsence> employeeAbsences = new List<EmployeeAbsence>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
 select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 left join Kq_PaiBan p on e.ID = p.EmpID 
 where (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null ) ");
                stringBuilder.Append(" and p.B" + date.Day + " not in ('03','07') and p.SessionID =  '"+ SessionID + "' ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    employeeAbsences.Add(new EmployeeAbsence
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Shift = "Day"

                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAbsencesNightShift(DateTime date)", ex.Message);
            }
            return employeeAbsences;
        }

        public List<EmployeeAbsence> GetEmployeeAbsencesDayShiftNotPaipan(DateTime date, int SessionID)
        {
            List<EmployeeAbsence> employeeAbsences = new List<EmployeeAbsence>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID not in (select distinct EmpID from Kq_Source where 1=1  ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null ) ");

                stringBuilder.Append(@" and e.ID not in (select EmpID from Kq_PaiBan where SessionID = '" + SessionID + "' ) ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAbsences.Add(new EmployeeAbsence
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Shift = "Day"

                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAbsencesNightShift(DateTime date)", ex.Message);
            }
            return employeeAbsences;
        }

        public List<EmployeeAttendance> GetEmployeeAttandanceDayShiftNotPaipan(DateTime date, int SessionID)
        {
            List<EmployeeAttendance> employeeAttendances = new List<EmployeeAttendance>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
select distinct  e.Code,e.Name, e.Dept, z.Name as DeptName, z.Manager from ZlEmployee e
 left join ZlDept z on e.Dept = z.Code
  left join Kq_Source s on e.ID = s.EmpID
 where (e.Dept not like '%999%' and e.Dept not like '%888%')  and e.State = '0'   and 
e.ID  in (select distinct EmpID from Kq_Source where 1=1  ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:01'  and convert(char(5), FDateTime, 108) < '23:59:00' and EmpID is not null ) ");

                stringBuilder.Append(@" and e.ID not in (select EmpID from Kq_PaiBan where SessionID = '" + SessionID + "' ) ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employeeAttendances.Add(new EmployeeAttendance
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        DeptCode = dt.Rows[i]["Dept"].ToString(),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        Manager = dt.Rows[i]["Manager"].ToString(),
                        Shift ="Day"
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAbsencesNightShift(DateTime date)", ex.Message);
            }
            return employeeAttendances;
        }
        // Vũ update 15/1/2022
        public List<EmployeeTimekeeping> GetEmployeeTimekeepings(DateTime date, int SessionID)
        {
            List<EmployeeTimekeeping> employeeTimekeepings = new List<EmployeeTimekeeping>();
            try
            {
                //string[] nightShiftCode = { "03", "07", "17", "18", "20", "21", "24", "27", "33", "34", "37"};
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"
 select e.Code,e.Name, e.Dept, z.LongName as DeptName, e.Memo as SeasonalDept, s.FDateTime as DateTime, p.B" + date.Day + " as ShiftCode");
                stringBuilder.Append(" from ZlEmployee e left join ZlDept z on e.Dept = z.Code");
                stringBuilder.Append(" left join Kq_Source s on e.ID = s.EmpID");
                stringBuilder.Append(" left join Kq_PaiBan p on e.ID = p.EmpID");
                stringBuilder.Append(" where e.State = '0' and ");
                stringBuilder.Append(" e.ID in (select distinct EmpID from Kq_Source where 1=1 ");
                stringBuilder.Append(" and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) ");
                stringBuilder.Append(" and convert(char(5), FDateTime, 108) >='00:00:00'  and convert(char(5), FDateTime, 108) <= '23:59:59' and EmpID is not null ) ");
                stringBuilder.Append(" and p.SessionID =  '" + SessionID + "' and cast(FDateTime as date)  = cast( '" + date.ToString("yyyyMMdd") + "' as date ) order by e.Code ASC, FDateTime ASC");

                
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int shiftCode = Convert.ToInt32(dt.Rows[i]["ShiftCode"].ToString());
                    if (dt.Rows[i]["Code"].ToString().Contains("TV"))
                    {
                        dt.Rows[i]["DeptName"] = dt.Rows[i]["SeasonalDept"].ToString().TrimEnd();
                    }
                    employeeTimekeepings.Add(new EmployeeTimekeeping
                    {
                        Date = date.ToString("dd.MM.yyyy"),
                        Dept = dt.Rows[i]["DeptName"].ToString(),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        EmpName = dt.Rows[i]["Name"].ToString(),
                        TimeCheck = dt.Rows[i]["DateTime"].ToString(),
                        ShiftCode = shiftCode.ToString("00"),
                        Shift = sqlHR.sqlExecuteScalarString("select distinct Name from Kq_BanZhi where Code = '" + dt.Rows[i]["ShiftCode"].ToString() + "'")
                    });
                }   
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetEmployeeAbsencesNightShift(DateTime date)", ex.Message);
            }
            return employeeTimekeepings;
        }
    }
}
