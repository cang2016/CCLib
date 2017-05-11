using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Logging;

namespace CodeGen
{
    public class CodeGenerateControl
    {
        Database database = DatabaseFactory.CreateDatabase();
        public string GetServerName()
        {
            SimpleLoger.Instance.Debug("GetServerName");
            //SqlServerExecute sqlServerExe = new SqlServerExecute();
            return database.ExecuteScalar<string>("select @@@Servername");
            //return sqlServerExe.ExecuteScalarToStr("select @@Servername");
        }

        public List<string> GetDatabases()
        {
            //SqlServerExecute sqlServerExe = new SqlServerExecute();
            SimpleLoger.Instance.Debug("GetDatabases");
            return database.Fetch<string>("select name from master..sysdatabases");
        }

        public List<DataTable> GetTablesInDatabase(List<string> tableNameList)
        {
            SimpleLoger.Instance.Debug("GetTableName");
            //SqlServerExecute sqlServerExe = new SqlServerExecute();
            //DataTable userTables = sqlServerExe.FillDataTable(CommandType.Text, "select name from sysobjects where type = 'U'");
            List<DataTable> tableList = new List<DataTable>();
            foreach(String tableName in tableNameList)
            {
                string sql = string.Format("select * from {0} where 1 = 2", tableName);
                DataTable dt = database.FillDataTable(sql);
               
                dt.TableName = tableName;
                tableList.Add(dt);
            }

            return tableList;
        }

        public List<string> GetTableNamesInDatabase(string dataBaseName)
        {
            //SqlServerExecute sqlServerExe = new SqlServerExecute();
            DataTable userTables = database.FillDataTable("use " + dataBaseName + "; select name from sysobjects where type = 'U'");
            List<string> tableList = new List<string>();
            foreach(DataRow row in userTables.Rows)
            {
                string sql = string.Format("select * from {0}", row["Name"].ToString());

                if(row["name"] != DBNull.Value)
                {
                    tableList.Add(Convert.ToString(row["Name"]));
                }
            }

            return tableList;
        }



    }
}
