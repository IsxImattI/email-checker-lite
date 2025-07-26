using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;

namespace EmailChecker
{
    public static class EmailInput
    {
        public static List<string> ReadFromXlsx(string path)
        {
            var emails = new List<string>();
            using var workbook = new XLWorkbook(path);
            var worksheet = workbook.Worksheets.First();

            foreach (var row in worksheet.RowsUsed())
            {
                var cell = row.Cell(1).GetString();
                if (!string.IsNullOrWhiteSpace(cell))
                    emails.Add(cell.Trim());
            }

            return emails;
        }
    }
}
