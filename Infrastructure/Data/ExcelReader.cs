using System.Collections.Generic;
using System.IO;
using Domain.Entities;
using OfficeOpenXml;

public class ExcelReader
{
    private readonly string _filePath;

    public ExcelReader(string filePath)
    {
        _filePath = filePath;
    }

    public List<Meeting> ReadMeetings()
    {
        var meetings = new List<Meeting>();

        // Abrir el archivo Excel
        using (var package = new ExcelPackage(new FileInfo(_filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0]; // Leer la primera hoja
            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++) // Asumiendo encabezados en la fila 1
            {
                var meeting = new Meeting
                {
                    School = worksheet.Cells[row, 1].Text,          // PLANTEL
                    Advisor = worksheet.Cells[row, 2].Text,         // ALUMNO CONSEJERO
                    MeetingDate = worksheet.Cells[row, 3].GetValue<DateTime>() // FECHA DE REUNION
                };
                meetings.Add(meeting);
            }
        }

        return meetings;
    }
}
