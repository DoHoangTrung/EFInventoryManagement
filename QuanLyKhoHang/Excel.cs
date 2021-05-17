using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKhoHang
{
    public class Excel
    {
        string path;
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel()
        {

        }

        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value != null)
            {
                return ws.Cells[i, j].Value;
            }
            else
            {
                return "";
            }
        }

        public void WriteToCell(int r, int c, int text)
        {
            r++;
            c++;
            ws.Cells[r, c].Value2 = text;
        }

        public void Save()
        {
            wb.Save();
        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void CreateNewFile()
        {
            this.wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            this.ws = excel.Worksheets[1];
        }


        public void Close()
        {
            wb.Close();
        }

        public void CreateNewSheet()
        {
            wb.Worksheets.Add(After: ws);
        }
    }
}
