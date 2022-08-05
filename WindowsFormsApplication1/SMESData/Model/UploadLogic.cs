using System;
using System.Text;

namespace WindowsFormsApplication1
{
    class UploadLogic
    {
        public static string Insert(string model, string date, string NG)
        {
            StringBuilder sqlInsertData = new StringBuilder();
            if (SaveData.PQC == true)
            {
                sqlInsertData.Append("Insert into thu_SMESData_NGRate_PQC ");
                sqlInsertData.Append(@"( Model, Date, rate )");
                sqlInsertData.Append(" values ( ");
                sqlInsertData.Append("'" + model + "','" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "','" + NG + "')");
            }
            else
            {
                sqlInsertData.Append("Insert into thu_SMESData_NGRate ");
                sqlInsertData.Append(@"( model, inspectdate, rate )");
                sqlInsertData.Append(" values ( ");
                sqlInsertData.Append("'" + model + "','" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "','" + NG + "')");
            }          
            return sqlInsertData.ToString();
        }
        public static string Update(string model, string date, string NG)
        {
            StringBuilder sqlUpdateData = new StringBuilder();
            if (SaveData.PQC == true)
            {
                sqlUpdateData.Append("update thu_SMESData_NGRate_PQC set Model = '" + model + "', Date = '" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "', rate = '" + NG + "' ");
                sqlUpdateData.Append("where Model = '" + model + "' and Date = '" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "'");
            }
            else
            {
                sqlUpdateData.Append("update thu_SMESData_NGRate set model = '" + model + "', inspectdate = '" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "', rate = '" + NG + "' ");
                sqlUpdateData.Append("where model = '" + model + "' and inspectdate = '" + Convert.ToDateTime(date).ToString("yyyy-MM-dd") + "'");
            }
            return sqlUpdateData.ToString();
        }
    }
}
