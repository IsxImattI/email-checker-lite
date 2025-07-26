using Xunit;
using System.IO;
using System.Collections.Generic;
using ClosedXML.Excel;
using EmailChecker;

namespace EmailChecker.Tests
{
    public class EmailInputTests
    {
        [Fact]
        public void ReadFromXlsx_Should_Read_Emails_From_FirstColumn()
        {
            string tempPath = "test-emails.xlsx";

            using (var wb = new XLWorkbook())
            {
                var ws = wb.AddWorksheet("Sheet1");
                ws.Cell(1, 1).Value = "alpha@mail.com";
                ws.Cell(2, 1).Value = "beta@yopmail.com";
                wb.SaveAs(tempPath);
            }

            var result = EmailInput.ReadFromXlsx(tempPath);

            Assert.Contains("alpha@mail.com", result);
            Assert.Contains("beta@yopmail.com", result);

            File.Delete(tempPath);
        }
    }
}
