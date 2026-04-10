/*A small institute wants a simple web page where users can enter student details and see the submitted data on another page.
Requirements:
1.Create a form to accept: 
•	Student Name 
•	Age 
•	Course 
2. Submit the form using HttpPost 
3.Redirect to another action method to display entered data 
4.  Pass data using ViewBag OR ViewData

Technical Constraints
1.  Use Attribute-based routing 
2.  Do NOT use Model or Database 
3.  Use only ViewBag/ViewData for state management 
4.  Use separate actions for: 
•	GET → Display form 
•	POST → Handle submission
Expectations
1. Clean separation of GET and POST actions 
2. Correct usage of ViewBag/ViewData 
3. Proper routing using attributes 
4.Data displayed correctly after submission
Learning Outcome
1.  Understanding of HttpGet vs HttpPost 
2. Basics of state management using ViewBag/ ViewData
3.Hands - on with attribute routing
*/

using Microsoft.AspNetCore.Mvc;

namespace Week_6_Day_5_Problem_1.Controllers
{
   
    public class StudentController : Controller
    {
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;
            return RedirectToAction("Display", new { name = name, age = age, course = course });
        }
        [HttpGet("display")]
        public IActionResult Display(string name,int age, string course)
        {
            ViewBag.Name=name;
            ViewBag.age = age;
            ViewBag.course = course;
            return View();
        }
    }
}
