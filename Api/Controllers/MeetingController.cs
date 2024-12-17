using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly MeetingService _meetingService;

        public MeetingsController(MeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var meetings = _meetingService.GetAllMeetings();
            return Ok(meetings);
        }
    }
}
