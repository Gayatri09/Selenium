using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel1 = Microsoft.Office.Interop.Excel;

namespace ConsoleApplication1.Utility
{
    class TestData
    {
        public static void ReadData(String testName,String test_status)
        {
            try
            {
                //Create COM Objects. Create a COM object for everything that is referenced
                var Filepath = ConfigurationManager.AppSettings["TestDataPath"];
                Excel1.Application xlApp = new Excel1.Application();
                Excel1.Workbook xlWorkbook = xlApp.Workbooks.Open(@Filepath);
                Excel1._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel1.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                Console.Write(colCount);
                //get an object array of all of the cells in the worksheet (their values)
                object[,] valueArray = (object[,])xlRange.get_Value(
                            Excel1.XlRangeValueDataType.xlRangeValueDefault);
                
                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                for (int i = 2; i <= rowCount; i++)
                {
                    var TestCaseID = valueArray[i, 2].ToString();
     

                }
                xlWorkbook.Save();
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}