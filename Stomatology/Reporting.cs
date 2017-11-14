using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Stomatology
{

    public class Reporting
    {
        Main main;
        public void infoOutExcel()
        {
            //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ////Книга.
            //ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ////Таблица.
            //ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

            //for (int i = 0; i < main.dataGridView1.Rows.Count; i++)
            //{
            //    for (int j = 0; j < main.dataGridView1.ColumnCount; j++)
            //    {
            //        ExcelApp.Cells[i + 1, j + 1] = main.dataGridView1.Rows[i].Cells[j].Value;
            //    }
            //}
            ////Вызываем нашу созданную эксельку.
            //ExcelApp.Visible = true;
            //ExcelApp.UserControl = true;
        }
    }
}
