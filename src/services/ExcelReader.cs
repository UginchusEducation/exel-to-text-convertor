using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using windows_app.models;

namespace windows_app.services
{
    public static class ExcelReader
    {
        public static List<RowData> ReadExcelFile(string filePath)
        {
            var rows = new List<RowData>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    rows.Add(new RowData
                    {
                        LastName = worksheet.Cells[row, 1].Text,
                        FirstName = worksheet.Cells[row, 2].Text,
                        MiddleName = worksheet.Cells[row, 3].Text,
                        BloodType = worksheet.Cells[row, 4].Text,
                        PhoneNumber = worksheet.Cells[row, 5].Text
                    });
                }
            }
            return rows;
        }
    }
}