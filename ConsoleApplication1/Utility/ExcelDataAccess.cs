using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Dapper;

namespace ConsoleApplication1.Utility
{
    class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static DataVariables GetTestData(string testCase)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [TestData$] where TestCaseId='{0}'", testCase);
                var value = connection.Query<DataVariables>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
