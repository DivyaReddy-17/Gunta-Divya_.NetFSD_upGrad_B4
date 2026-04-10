/*Scenario:
Build a simple calculator web page that performs addition of two numbers.
Requirements:
1.Accept two numbers using a form
2.Submit using HttpPost 
3.Display result on the same or another page 
3. Pass result using ViewData
Technical Constraints
1. Use Attribute routing 
2.  No JavaScript (pure server-side processing) 
3.  No Model binding (use form collection or parameters)
Expectations
1. Correct calculation logic 
2.  Proper HttpPost handling 
3.  Result displayed using ViewData
Learning Outcome
1.  Handling user input via forms 
2. Passing computed values using ViewData 
3.Understanding request lifecycle
*/

using Microsoft.AspNetCore.Mvc;

namespace Week_6_Day_5_Problem_2.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet("calculator")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("calculator")]
        public IActionResult Index(int num1,int num2)
        {
            int result = num1 + num2;
            ViewData["Result"]=result;
            return View();
        }
    }
}
