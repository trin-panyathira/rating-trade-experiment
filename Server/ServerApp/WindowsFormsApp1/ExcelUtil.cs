using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Claims;

namespace WindowsFormsApp1
{
    internal class ExcelUtil
    {
        public static void ExportExcel(List<BuyingModel> resultList, string address)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;

            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = false;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                int rowIndex = 1;
                oSheet.Cells[rowIndex, 1] = "Round";
                oSheet.Cells[rowIndex, 2] = "Quality";
                oSheet.Cells[rowIndex, 3] = "Rating";
                oSheet.Cells[rowIndex, 4] = "Buy";
                oSheet.Cells[rowIndex, 5] = "Claim";
                oSheet.Cells[rowIndex, 6] = "Feedback";
                oSheet.Cells[rowIndex, 7] = "Payoff";
                oSheet.Cells[rowIndex, 8] = "Rebate";
                oSheet.Cells[rowIndex, 9] = "Epp";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "I1").Font.Bold = true;
                oSheet.get_Range("A1", "I1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                // Create an array to multiple values at once.
                string[,] saNames = new string[resultList.Count, 9];
                
                rowIndex++;
                resultList.ForEach(item =>
                {
                    oSheet.Cells[rowIndex, 1] = item.round;
                    oSheet.Cells[rowIndex, 2] = item.quality;
                    oSheet.Cells[rowIndex, 3] = item.rating;
                    oSheet.Cells[rowIndex, 4] = item.buy;
                    oSheet.Cells[rowIndex, 5] = item.claim;
                    oSheet.Cells[rowIndex, 6] = item.feedback;
                    oSheet.Cells[rowIndex, 7] = item.payoff;
                    oSheet.Cells[rowIndex, 8] = item.rebate;
                    oSheet.Cells[rowIndex, 9] = item.epp;

                    rowIndex++;
                });

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "I1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = false;
                oXL.UserControl = false;

                string folderPath = Directory.GetCurrentDirectory();
                string fileName = "result_" + address.Replace(".", "-") + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                string filePath = folderPath + "\\excel_result\\" + fileName;
                Console.WriteLine("Save File: {0}", filePath);
                oWB.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
                oXL.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Write Excel Error: " + e.Message);
            }
        }

        #region
        //public void ExportExcel()
        //{
        //    Microsoft.Office.Interop.Excel.Application oXL;
        //    Microsoft.Office.Interop.Excel._Workbook oWB;
        //    Microsoft.Office.Interop.Excel._Worksheet oSheet;
        //    Microsoft.Office.Interop.Excel.Range oRng;
        //    object misvalue = System.Reflection.Missing.Value;

        //    try
        //    {
        //        //Start Excel and get Application object.
        //        oXL = new Microsoft.Office.Interop.Excel.Application();
        //        oXL.Visible = false;

        //        //Get a new workbook.
        //        oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
        //        oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

        //        //Add table headers going cell by cell.
        //        oSheet.Cells[1, 1] = "First Name";
        //        oSheet.Cells[1, 2] = "Last Name";
        //        oSheet.Cells[1, 3] = "Full Name";
        //        oSheet.Cells[1, 4] = "Salary";

        //        //Format A1:D1 as bold, vertical alignment = center.
        //        oSheet.get_Range("A1", "D1").Font.Bold = true;
        //        oSheet.get_Range("A1", "D1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

        //        // Create an array to multiple values at once.
        //        string[,] saNames = new string[5, 2];

        //        saNames[0, 0] = "John";
        //        saNames[0, 1] = "Smith";
        //        saNames[1, 0] = "Tom";

        //        saNames[4, 1] = "Johnson";

        //        //Fill A2:B6 with an array of values (First and Last Names).
        //        oSheet.get_Range("A2", "B6").Value2 = saNames;

        //        //Fill C2:C6 with a relative formula (=A2 & " " & B2).
        //        oRng = oSheet.get_Range("C2", "C6");
        //        oRng.Formula = "=A2 & \" \" & B2";

        //        //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
        //        oRng = oSheet.get_Range("D2", "D6");
        //        oRng.Formula = "=RAND()*100000";
        //        oRng.NumberFormat = "$0.00";

        //        //AutoFit columns A:D.
        //        oRng = oSheet.get_Range("A1", "D1");
        //        oRng.EntireColumn.AutoFit();

        //        oXL.Visible = false;
        //        oXL.UserControl = false;

        //        string folderPath = Directory.GetCurrentDirectory();
        //        string fileName = "result_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
        //        string filePath = folderPath + "\\excel_result\\" + fileName;
        //        Console.WriteLine("Save File: {0}", filePath);
        //        oWB.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
        //            false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        //            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //        oWB.Close();
        //        oXL.Quit();
        //    }
        //    catch (Exception e)
        //    { 
        //        Console.WriteLine("Write Excel Error: " + e.Message);
        //    }
        //}
        #endregion
    }
}
