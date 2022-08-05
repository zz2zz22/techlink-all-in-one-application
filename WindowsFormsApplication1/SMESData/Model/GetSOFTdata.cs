using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class GetSOFTdata
    {      
        //total data in every line
        public static double getTotalMQC(string line, string date)
        {
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            double s;
            string temp;
            sqlGetData.Append("select SUM(CASE WHEN line = '" + line + "' and inspectdate = '" + date + "' THEN Cast(data as numeric(10,0)) END) ");
            sqlGetData.Append("from m_ERPMQC_REALTIME");
            temp = sqlSOFTCon.sqlExecuteScalarString(sqlGetData.ToString());
            s = double.Parse(temp);
            return s;
        }
        // NG, RW, OP data of MQC in every line in date
        public static double getTotalRemark(string line, string remark, string date)
        {
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            double s;
            string temp;
            sqlGetData.Append("select SUM(CASE WHEN line = '" + line + "' and remark = '" + remark + "' and inspectdate = '" + date + "' THEN Cast(data as numeric(10,0)) END) ");
            sqlGetData.Append("from m_ERPMQC_REALTIME");
            temp = sqlSOFTCon.sqlExecuteScalarString(sqlGetData.ToString());
            if (temp == string.Empty || temp == "" || temp == null)
            {
                s = 0;
            }
            else
                s = double.Parse(temp);
            return s;
        }
        // total data of PQC in every line in date
        public static double getTotalPQC(string line, string date)
        {
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            double s;
            string temp;
            sqlGetData.Append("select SUM(CASE WHEN Line = '" + line + "' and InspectDateTime like '%" + date + "%' THEN Cast(Quantity as numeric(10,0)) END) ");
            sqlGetData.Append("from ProcessHistory.PQCMesData");
            temp = sqlSOFTCon.sqlExecuteScalarString(sqlGetData.ToString());
            s = double.Parse(temp);
            return s;
        }
        // NG, RW, OP data of PQC in every line in date
        public static double getTotalAttributeType(string line, string type, string date)
        {
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            double s;
            string temp;
            sqlGetData.Append("select SUM(CASE WHEN Line = '" + line + "' and AttributeType = '" + type + "' and InspectDateTime like '%" + date + "%' THEN Cast(Quantity as numeric(10,0)) END) ");
            sqlGetData.Append("from ProcessHistory.PQCMesData");
            temp = sqlSOFTCon.sqlExecuteScalarString(sqlGetData.ToString());
            if (temp == string.Empty || temp == "" || temp == null)
            {
                s = 0;
            }
            else
                s = double.Parse(temp);
            return s;
        }
        //Get Model in table NGRate
        public static DataTable GetModel(string date)
        {
            DataTable dt = new DataTable();
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            if (SaveData.PQC == true)
            {
                sqlGetData.Append("select distinct Model from thu_SMESData_NGRate_PQC ");
                sqlGetData.Append("where Date = '" + date + "'");
                sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
            }  
            else
            {
                sqlGetData.Append("select distinct model from thu_SMESData_NGRate ");
                sqlGetData.Append("where inspectdate = '" + date + "'");
                sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
            }                
            return dt;
        }
        //Get List MQC to DataTable
        public static DataTable GetListMQC(string date, string line)
        {
            List<ListMQC> ListMQC = new List<ListMQC>();
            DataTable dt = new DataTable();
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            sqlGetData.Append("select distinct m.model as Model, m.inspectdate as Date, m.line as Line, m.OUTPUT, m.REWORK, m.NOGOOD, ");
            sqlGetData.Append("serno, ");
            sqlGetData.Append("(CASE WHEN (select top 1 rate from thu_SMESData_NGRate where model = a.model order by inspectdate desc) IS NOT NULL ");
            sqlGetData.Append("THEN (select top 1 rate from thu_SMESData_NGRate where model = a.model order by inspectdate desc) ");
            sqlGetData.Append("ELSE '2' END) as '%NG_allow', '2.5' as '%RW_allow', ");
            sqlGetData.Append("(CASE WHEN (select OUTPUT from thu_MQC_DailyTarget where model = a.model and Date = a.inspectdate) IS NOT NULL ");
            sqlGetData.Append("THEN (select OUTPUT from thu_MQC_DailyTarget where model = a.model and Date = a.inspectdate) ELSE '0' END) as DailyTarget ");
            sqlGetData.Append("FROM m_ERPMQC_REALTIME as a ");
            sqlGetData.Append("LEFT JOIN thu_SMESData_NGRate as r on a.model = r.model and a.inspectdate = r.inspectdate ");
            sqlGetData.Append("join(SELECT model,  inspectdate, line, ");
            sqlGetData.Append("COALESCE(SUM(CASE WHEN remark = 'OP' THEN Cast(data as numeric(10,0)) END), 0) AS OUTPUT, ");
            sqlGetData.Append("COALESCE(SUM(CASE WHEN remark = 'RW' THEN Cast(data as numeric(10,0)) END), 0) AS REWORK, ");
            sqlGetData.Append("COALESCE(SUM(CASE WHEN remark = 'NG' THEN Cast(data as numeric(10,0)) END), 0) AS NOGOOD ");
            sqlGetData.Append("FROM m_ERPMQC_REALTIME ");
            sqlGetData.Append("WHERE inspectdate = '" + date + "' and line like '%" + line + "%'");
            sqlGetData.Append("group by model, inspectdate, line) as m ");
            sqlGetData.Append("on a.inspectdate = m.inspectdate and a.model = m.model and a.line = m.line ");
            //Do not change this sort for correcting logic in for loop. Model have same name and diffrent line will stand side by side
            sqlGetData.Append("order by Model desc, Line ");
            sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
            ListMQC MQC = new ListMQC();
            MQC.Target = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count == 1)
                {
                    string[] serno = dt.Rows[i]["serno"].ToString().Split(';');
                    MQC.Target = MQC.Target + double.Parse(serno[4]);
                    MQC.Model = dt.Rows[i]["Model"].ToString();
                    MQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                    MQC.Line = dt.Rows[i]["Line"].ToString();
                    MQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                    MQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                    MQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                    MQC.Total = MQC.OUTPUT + MQC.REWORK + MQC.NOGOOD;
                    MQC.DailyTarget = double.Parse(dt.Rows[i]["DailyTarget"].ToString());
                    MQC.NG_rate_realtime = Math.Round(MQC.NOGOOD / MQC.Total * 100, 1);
                    MQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                    MQC.RW_rate_realtime = Math.Round(MQC.REWORK / MQC.Total * 100, 1);
                    MQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                    ListMQC.Add(MQC);
                }
                else
                {
                    if (i + 1 != dt.Rows.Count)
                    {
                        if (dt.Rows[i]["Model"].ToString() == dt.Rows[i + 1]["Model"].ToString() && dt.Rows[i]["Line"].ToString() == dt.Rows[i + 1]["Line"].ToString())
                        {
                            string[] serno = dt.Rows[i]["serno"].ToString().Split(';');
                            string[] serno1 = dt.Rows[i + 1]["serno"].ToString().Split(';');
                            if (serno[3] != serno1[3])
                                MQC.Target = MQC.Target + double.Parse(serno[4]);
                        }
                        else
                        {
                            string[] serno = dt.Rows[i]["serno"].ToString().Split(';');
                            MQC.Target = MQC.Target + double.Parse(serno[4]);
                            MQC.Model = dt.Rows[i]["Model"].ToString();
                            MQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                            MQC.Line = dt.Rows[i]["Line"].ToString();
                            MQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                            MQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                            MQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                            MQC.Total = MQC.OUTPUT + MQC.REWORK + MQC.NOGOOD;
                            MQC.DailyTarget = double.Parse(dt.Rows[i]["DailyTarget"].ToString());
                            MQC.NG_rate_realtime = Math.Round(MQC.NOGOOD / MQC.Total * 100, 1);
                            MQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                            MQC.RW_rate_realtime = Math.Round(MQC.REWORK / MQC.Total * 100, 1);
                            MQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                            ListMQC.Add(MQC);
                            MQC = new ListMQC();
                            MQC.Target = 0;
                        }
                    }
                    else
                    {
                        if (dt.Rows[i - 1]["Model"].ToString() == dt.Rows[i]["Model"].ToString() && dt.Rows[i - 1]["Line"].ToString() == dt.Rows[i]["Line"].ToString())
                        {
                            string[] serno = dt.Rows[i - 1]["serno"].ToString().Split(';');
                            string[] serno1 = dt.Rows[i]["serno"].ToString().Split(';');
                            if (serno[3] != serno1[3])
                                MQC.Target = MQC.Target + double.Parse(serno1[4]);
                            MQC.Model = dt.Rows[i]["Model"].ToString();
                            MQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                            MQC.Line = dt.Rows[i]["Line"].ToString();
                            MQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                            MQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                            MQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                            MQC.Total = MQC.OUTPUT + MQC.REWORK + MQC.NOGOOD;
                            MQC.DailyTarget = double.Parse(dt.Rows[i]["DailyTarget"].ToString());
                            MQC.NG_rate_realtime = Math.Round(MQC.NOGOOD / MQC.Total * 100, 1);
                            MQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                            MQC.RW_rate_realtime = Math.Round(MQC.REWORK / MQC.Total * 100, 1);
                            MQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                            ListMQC.Add(MQC);
                        }
                        else
                        {
                            string[] serno = dt.Rows[i]["serno"].ToString().Split(';');
                            MQC.Target = MQC.Target + double.Parse(serno[4]);
                            MQC.Model = dt.Rows[i]["Model"].ToString();
                            MQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                            MQC.Line = dt.Rows[i]["Line"].ToString();
                            MQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                            MQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                            MQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                            MQC.Total = MQC.OUTPUT + MQC.REWORK + MQC.NOGOOD;
                            MQC.DailyTarget = double.Parse(dt.Rows[i]["DailyTarget"].ToString());
                            MQC.NG_rate_realtime = Math.Round(MQC.NOGOOD / MQC.Total * 100, 1);
                            MQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                            MQC.RW_rate_realtime = Math.Round(MQC.REWORK / MQC.Total * 100, 1);
                            MQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                            ListMQC.Add(MQC);
                        }
                    }
                }
            }
            DataTable dtMQC = new DataTable();
            DataColumn[] tableColumns = new DataColumn[]
            {
                new DataColumn()
                {
                    ColumnName="Model",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="Date",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="Line",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="OUTPUT",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="REWORK",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="NOGOOD",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="Total",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="DailyTarget",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="NG_rate_realtime",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="NG_rate_allow",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="RW_rate_realtime",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="RW_rate_allow",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="Target",
                    DataType=typeof(double),
                },
            };
            dtMQC.Columns.AddRange(tableColumns);
            foreach (var data in ListMQC)
            {
                dtMQC.Rows.Add(data.Model, data.Date, data.Line, data.OUTPUT, data.REWORK, data.NOGOOD, data.Total, data.DailyTarget, data.NG_rate_realtime, data.NG_rate_allow, data.RW_rate_realtime, data.RW_rate_allow, data.Target);
            }
            dtMQC.DefaultView.Sort = "NG_rate_realtime DESC";
            dtMQC = dtMQC.DefaultView.ToTable();
            return dtMQC;
        }
        //Get List PQC to Datatable
        public static DataTable GetListPQC(string date, string line)
        {
            List<ListPQC> ListPQC = new List<ListPQC>();
            DataTable dt = new DataTable();
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            sqlGetData.Append("select distinct m.Model, m.Date, m.line as Line, m.OUTPUT, m.REWORK, m.NOGOOD, ");
            sqlGetData.Append("(CASE WHEN (select top 1 rate from thu_SMESData_NGRate_PQC where Model = a.Model order by Date desc) IS NOT NULL ");
            sqlGetData.Append("THEN (select top 1 rate from thu_SMESData_NGRate_PQC where Model = a.Model order by Date desc) ELSE '2' END) as '%NG_allow', POCode, '2.5' as '%RW_allow' ");
            sqlGetData.Append("FROM ProcessHistory.PQCMesData as a ");
            sqlGetData.Append("LEFT JOIN thu_SMESData_NGRate_PQC as r on a.Model = r.Model and CAST(a.InspectDateTime as Date) = r.Date ");
            sqlGetData.Append("join(SELECT Model, CAST(InspectDateTime as Date) as Date, line, ");
            sqlGetData.Append("COALESCE(SUM(CASE WHEN AttributeType = 'OP' THEN Cast(Quantity as numeric(10,0)) END), 0) AS OUTPUT, ");
            sqlGetData.Append("COALESCE(SUM(CASE WHEN AttributeType = 'RW' THEN Cast(Quantity as numeric(10,0)) END), 0) AS REWORK, ");
            sqlGetData.Append("COALESCE(SUM(CASE WHEN AttributeType = 'NG' THEN Cast(Quantity as numeric(10,0)) END), 0) AS NOGOOD ");
            sqlGetData.Append("FROM ProcessHistory.PQCMesData ");
            sqlGetData.Append("WHERE InspectDateTime like '%" + date + "%' and line like '%" + line + "%' ");
            sqlGetData.Append("group by Model, line, CAST(InspectDateTime as Date)) as m ");
            sqlGetData.Append("on CAST(a.InspectDateTime as Date) = m.Date and a.Model = M.model and a.line = m.line ");
            //Do not change this sort for correcting logic in for loop. Model have same name and diffrent line will stand side by side
            sqlGetData.Append("order by Model desc, Line");
            sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
            ListPQC PQC = new ListPQC();
            PQC.Target = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count == 1)
                {
                    string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
                    PQC.Target = PQC.Target + double.Parse(POCode[4]);
                    PQC.Model = dt.Rows[i]["Model"].ToString();
                    PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                    PQC.Line = dt.Rows[i]["Line"].ToString();
                    PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                    PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                    PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                    PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
                    PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
                    PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                    PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
                    PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                    ListPQC.Add(PQC);
                }
                else
                {
                    if (i + 1 != dt.Rows.Count)
                    {
                        if (dt.Rows[i]["Model"].ToString() == dt.Rows[i + 1]["Model"].ToString() && dt.Rows[i]["Line"].ToString() == dt.Rows[i + 1]["Line"].ToString())
                        {
                            string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
                            string[] POCode1 = dt.Rows[i + 1]["POCode"].ToString().Split(';');
                            if (POCode[3] != POCode1[3])
                                PQC.Target = PQC.Target + double.Parse(POCode[4]);
                        }
                        else
                        {
                            string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
                            PQC.Target = PQC.Target + double.Parse(POCode[4]);
                            PQC.Model = dt.Rows[i]["Model"].ToString();
                            PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                            PQC.Line = dt.Rows[i]["Line"].ToString();
                            PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                            PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                            PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                            PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
                            PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
                            PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                            PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
                            PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                            ListPQC.Add(PQC);
                            PQC = new ListPQC();
                            PQC.Target = 0;
                        }
                    }
                    else
                    {
                        if (dt.Rows[i - 1]["Model"].ToString() == dt.Rows[i]["Model"].ToString() && dt.Rows[i - 1]["Line"].ToString() == dt.Rows[i]["Line"].ToString())
                        {
                            string[] POCode = dt.Rows[i - 1]["POCode"].ToString().Split(';');
                            string[] POCode1 = dt.Rows[i]["POCode"].ToString().Split(';');
                            if (POCode[3] != POCode1[3])
                                PQC.Target = PQC.Target + double.Parse(POCode1[4]);
                            PQC.Model = dt.Rows[i]["Model"].ToString();
                            PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                            PQC.Line = dt.Rows[i]["Line"].ToString();
                            PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                            PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                            PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                            PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
                            PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
                            PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                            PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
                            PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                            ListPQC.Add(PQC);
                        }
                        else
                        {
                            string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
                            PQC.Target = PQC.Target + double.Parse(POCode[4]);
                            PQC.Model = dt.Rows[i]["Model"].ToString();
                            PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                            PQC.Line = dt.Rows[i]["Line"].ToString();
                            PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
                            PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
                            PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
                            PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
                            PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
                            PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
                            PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
                            PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
                            ListPQC.Add(PQC);
                        }
                    }
                }
            }
            DataTable dtPQC = new DataTable();
            DataColumn[] tableColumns = new DataColumn[]
            {
                new DataColumn()
                {
                    ColumnName="Model",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="Date",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="Line",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="OUTPUT",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="REWORK",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="NOGOOD",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="Total",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="Target",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="NG_rate_realtime",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="NG_rate_allow",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="RW_rate_realtime",
                    DataType=typeof(double),
                },
                new DataColumn()
                {
                    ColumnName="RW_rate_allow",
                    DataType=typeof(double),
                }
            };
            dtPQC.Columns.AddRange(tableColumns);
            foreach (var data in ListPQC)
            {
                dtPQC.Rows.Add(data.Model, data.Date, data.Line, data.OUTPUT, data.REWORK, data.NOGOOD, data.Total, data.Target, data.NG_rate_realtime, data.NG_rate_allow, data.RW_rate_realtime, data.RW_rate_allow);
            }
            dtPQC.DefaultView.Sort = "NG_rate_realtime DESC";
            dtPQC = dtPQC.DefaultView.ToTable();
            return dtPQC;
        }
        //public static DataTable GetListPQCTarget(string date, string line)
        //{
        //    List<ListPQC> ListPQC = new List<ListPQC>();
        //    DataTable dt = new DataTable();
        //    sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
        //    StringBuilder sqlGetData = new StringBuilder();
        //    sqlGetData.Append("select distinct m.Model, m.Date, m.line as Line, m.OUTPUT, m.REWORK, m.NOGOOD, ");
        //    sqlGetData.Append("(CASE WHEN (select top 1 rate from thu_SMESData_NGRate_PQC where Model = a.Model and line = a.line order by Date desc) IS NOT NULL ");
        //    sqlGetData.Append("THEN (select top 1 rate from thu_SMESData_NGRate_PQC where Model = a.Model and line = a.line order by Date desc) ELSE '2' END) as '%NG_allow', POCode, '2.5' as '%RW_allow', ");
        //    sqlGetData.Append("(CASE WHEN (select top 1 OutputTarget from ProcessHistory.DailyPerformanceGoal where Model = a.Model and line = a.line order by LastTimeModified desc) IS NOT NULL ");
        //    sqlGetData.Append("THEN (select top 1 OutputTarget from ProcessHistory.DailyPerformanceGoal where Model = a.Model and line = a.line order by LastTimeModified desc) ELSE '1000' END) as Target ");
        //    sqlGetData.Append("FROM ProcessHistory.PQCMesData as a ");
        //    sqlGetData.Append("LEFT JOIN thu_SMESData_NGRate_PQC as r on a.Model = r.Model and a.line = r.line and CAST(a.InspectDateTime as Date) = r.Date ");
        //    sqlGetData.Append("join(SELECT Model, CAST(InspectDateTime as Date) as Date, line, ");
        //    sqlGetData.Append("COALESCE(SUM(CASE WHEN AttributeType = 'OP' THEN Cast(Quantity as numeric(10,0)) END), 0) AS OUTPUT, ");
        //    sqlGetData.Append("COALESCE(SUM(CASE WHEN AttributeType = 'RW' THEN Cast(Quantity as numeric(10,0)) END), 0) AS REWORK, ");
        //    sqlGetData.Append("COALESCE(SUM(CASE WHEN AttributeType = 'NG' THEN Cast(Quantity as numeric(10,0)) END), 0) AS NOGOOD ");
        //    sqlGetData.Append("FROM ProcessHistory.PQCMesData ");
        //    sqlGetData.Append("WHERE InspectDateTime like '%" + date + "%' and line like '%" + line + "%' ");
        //    sqlGetData.Append("group by Model, line, CAST(InspectDateTime as Date)) as m ");
        //    sqlGetData.Append("on CAST(a.InspectDateTime as Date) = m.Date and a.Model = M.model and a.line = m.line ");
        //    //Do not change this sort for correcting logic in for loop. Model have same name and diffrent line will stand side by side
        //    sqlGetData.Append("order by Model desc, Line");
        //    sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
        //    ListPQC PQC = new ListPQC();
        //    PQC.Temp = 0;
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (dt.Rows.Count == 1)
        //        {
        //            string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
        //            PQC.Temp = PQC.Temp + double.Parse(POCode[4]);
        //            PQC.Model = dt.Rows[i]["Model"].ToString();
        //            PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
        //            PQC.Line = dt.Rows[i]["Line"].ToString();
        //            PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
        //            PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
        //            PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
        //            PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
        //            PQC.Target = double.Parse(dt.Rows[i]["Target"].ToString());
        //            PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
        //            PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
        //            PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
        //            PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
        //            ListPQC.Add(PQC);
        //        }
        //        else
        //        {
        //            if (i + 1 != dt.Rows.Count)
        //            {
        //                if (dt.Rows[i]["Model"].ToString() == dt.Rows[i + 1]["Model"].ToString() && dt.Rows[i]["Line"].ToString() == dt.Rows[i + 1]["Line"].ToString())
        //                {
        //                    string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
        //                    string[] POCode1 = dt.Rows[i + 1]["POCode"].ToString().Split(';');
        //                    if (POCode[3] != POCode1[3])
        //                        PQC.Temp = PQC.Temp + double.Parse(POCode[4]);
        //                }
        //                else
        //                {
        //                    string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
        //                    PQC.Temp = PQC.Temp + double.Parse(POCode[4]);
        //                    PQC.Model = dt.Rows[i]["Model"].ToString();
        //                    PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
        //                    PQC.Line = dt.Rows[i]["Line"].ToString();
        //                    PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
        //                    PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
        //                    PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
        //                    PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
        //                    PQC.Target = double.Parse(dt.Rows[i]["Target"].ToString());
        //                    PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
        //                    PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
        //                    PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
        //                    PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
        //                    ListPQC.Add(PQC);
        //                    PQC = new ListPQC();
        //                    PQC.Temp = 0;
        //                }
        //            }
        //            else
        //            {
        //                if (dt.Rows[i - 1]["Model"].ToString() == dt.Rows[i]["Model"].ToString() && dt.Rows[i - 1]["Line"].ToString() == dt.Rows[i]["Line"].ToString())
        //                {
        //                    string[] POCode = dt.Rows[i - 1]["POCode"].ToString().Split(';');
        //                    string[] POCode1 = dt.Rows[i]["POCode"].ToString().Split(';');
        //                    if (POCode[3] != POCode1[3])
        //                        PQC.Temp = PQC.Temp + double.Parse(POCode1[4]);
        //                    PQC.Model = dt.Rows[i]["Model"].ToString();
        //                    PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
        //                    PQC.Line = dt.Rows[i]["Line"].ToString();
        //                    PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
        //                    PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
        //                    PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
        //                    PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
        //                    PQC.Target = double.Parse(dt.Rows[i]["Target"].ToString());
        //                    PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
        //                    PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
        //                    PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
        //                    PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
        //                    ListPQC.Add(PQC);
        //                }
        //                else
        //                {
        //                    string[] POCode = dt.Rows[i]["POCode"].ToString().Split(';');
        //                    PQC.Temp = PQC.Temp + double.Parse(POCode[4]);
        //                    PQC.Model = dt.Rows[i]["Model"].ToString();
        //                    PQC.Date = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
        //                    PQC.Line = dt.Rows[i]["Line"].ToString();
        //                    PQC.OUTPUT = double.Parse(dt.Rows[i]["OUTPUT"].ToString());
        //                    PQC.REWORK = double.Parse(dt.Rows[i]["REWORK"].ToString());
        //                    PQC.NOGOOD = double.Parse(dt.Rows[i]["NOGOOD"].ToString());
        //                    PQC.Total = PQC.OUTPUT + PQC.REWORK + PQC.NOGOOD;
        //                    PQC.Target = double.Parse(dt.Rows[i]["Target"].ToString());
        //                    PQC.NG_rate_realtime = Math.Round(PQC.NOGOOD / PQC.Total * 100, 1);
        //                    PQC.NG_rate_allow = double.Parse(dt.Rows[i]["%NG_allow"].ToString());
        //                    PQC.RW_rate_realtime = Math.Round(PQC.REWORK / PQC.Total * 100, 1);
        //                    PQC.RW_rate_allow = double.Parse(dt.Rows[i]["%RW_allow"].ToString());
        //                    ListPQC.Add(PQC);
        //                }
        //            }
        //        }
        //    }
        //    DataTable dtPQC = new DataTable();
        //    DataColumn[] tableColumns = new DataColumn[]
        //    {
        //        new DataColumn()
        //        {
        //            ColumnName="Model",
        //            DataType=typeof(string),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="Date",
        //            DataType=typeof(string),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="Line",
        //            DataType=typeof(string),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="OUTPUT",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="REWORK",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="NOGOOD",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="Total",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="Target",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="NG_rate_realtime",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="NG_rate_allow",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="RW_rate_realtime",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="RW_rate_allow",
        //            DataType=typeof(double),
        //        },
        //        new DataColumn()
        //        {
        //            ColumnName="Temp",
        //            DataType=typeof(double),
        //        }
        //    };
        //    dtPQC.Columns.AddRange(tableColumns);
        //    foreach (var data in ListPQC)
        //    {
        //        dtPQC.Rows.Add(data.Model, data.Date, data.Line, data.OUTPUT, data.REWORK, data.NOGOOD, data.Total, data.Target, data.NG_rate_realtime, data.NG_rate_allow, data.RW_rate_realtime, data.RW_rate_allow, data.Temp);
        //    }
        //    dtPQC.DefaultView.Sort = "NG_rate_realtime DESC";
        //    dtPQC = dtPQC.DefaultView.ToTable();
        //    return dtPQC;
        //}
        //Get Info of product
        public static DataTable GetInfo(string model, string line, string date)
        {

            DataTable dt = new DataTable();
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            DataColumn[] tableColumns = new DataColumn[]
            {
                new DataColumn()
                {
                    ColumnName="Model",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="LotNumber",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="Line",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="Date",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="Time",
                    DataType=typeof(string),
                },
                new DataColumn()
                {
                    ColumnName="DateTime",
                    DataType=typeof(string),
                }
            };
            dt.Columns.AddRange(tableColumns);
            if (SaveData.PQC == true)
            {
                sqlGetData.Append("SELECT Model, LotNumber, Line, InspectDateTime as DateTime, Quantity, Inspector, AttributeType as Remark, POCode as Serno FROM ProcessHistory.PQCMesData ");
                sqlGetData.Append("where Model = '" + model + "' and Line = '" + line + "' and InspectDateTime like '%" + date + "%'");
                sqlGetData.Append("order by InspectDateTime desc, AttributeType");
                sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string DtIn = Convert.ToDateTime(dt.Rows[i]["DateTime"]).ToString("dd-MM-yyyy HH:mm:ss");
                    dt.Rows[i]["DateTime"] = DtIn;
                }
            }
            else
            {
                sqlGetData.Append("SELECT model as Model, lot as LotNumber, line as Line, inspectdate as Date, inspecttime as Time, data as Quantity, judge as Inspector, remark as Remark, serno as Serno FROM m_ERPMQC_REALTIME ");
                sqlGetData.Append("where model = '" + model + "' and line = '" + line + "' and inspectdate = '" + date + "'");
                sqlGetData.Append("order by inspecttime desc, remark");
                sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string DtIn = Convert.ToDateTime(dt.Rows[i]["Date"]).ToString("dd-MM-yyyy");
                    dt.Rows[i]["DateTime"] = DtIn + " " + dt.Rows[i]["Time"];
                }
            }
            return dt;
        }
        //Get all model in table m_ERPMQC_REALTIME
        public static DataTable getAllModel()
        {
            DataTable dt = new DataTable();
            sqlSOFTCon sqlSOFTCon = new sqlSOFTCon();
            StringBuilder sqlGetData = new StringBuilder();
            if (SaveData.PQC == true)
            {
                sqlGetData.Append("SELECT distinct Model FROM ProcessHistory.PQCMesData where Model != ''");
                sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
            }
            else
            {
                sqlGetData.Append("SELECT distinct model FROM m_ERPMQC_REALTIME where model != ''");
                sqlSOFTCon.sqlDataAdapterFillDatatable(sqlGetData.ToString(), ref dt);
            }
            return dt;
        }
    }
}