using Microsoft.AspNetCore.Mvc;

namespace XUnitTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public string Index()
        {
            return "Hi Ankur!";
        }

        [HttpGet]
        public string TestGuests(int guestID)
        {
            if(guestID == 1)
            {
                return "Guest 1";
            }
            else if (guestID == 2)
            {
                return "Guest 2";
            }
            else
            {
                return "Unknown Guest";
            }
        }
    }
}
