using Microsoft.AspNetCore.Mvc;

namespace Week_6_Day_5_Problem_4.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            // Conditional logic
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";

            }
            return View();
        }
    }
}

        // Pass the user info to the view (optional)
        

        
   
