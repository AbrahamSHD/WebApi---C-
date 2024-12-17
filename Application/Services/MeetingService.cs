using Domain.Entities;
// using Infrastructure.Data;
using System.Collections.Generic;

namespace Application.Services
{
    public class MeetingService
    {
        private readonly ExcelReader _excelReader;

        public MeetingService(ExcelReader excelReader)
        {
            _excelReader = excelReader;
        }

        public List<Meeting> GetAllMeetings()
        {
            return _excelReader.ReadMeetings(); // Cambiado a ReadMeetings
        }
    }
}
