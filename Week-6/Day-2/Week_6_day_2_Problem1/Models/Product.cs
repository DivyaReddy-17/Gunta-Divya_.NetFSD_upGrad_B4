/*using System.Runtime.Intrinsics.X86;

Scenario:
A startup wants a basic web application to display a welcome message for users accessing their platform.

Requirements:
1.Create a new ASP.NET Core MVC project. 
2.Run the application successfully. 
3.	Modify the default Home page to display: 
a.  “Welcome to My First ASP.NET Core App” 
4.	Change the application title. 

Technical Constraints:
•	Use ASP.NET Core 8 MVC template 
•	Use Visual Studio or .NET CLI (dotnet new mvc) 
•	Do NOT delete default project structure 

Expectations:
•	Project runs without errors 
•	Default routing works 
•	UI reflects updated message 

Program Flow:
User Request → Default Route → HomeController → View → Response

Learning Outcome:
•	Understand project structure 
•	Learn how to run ASP.NET Core apps 
•	Get familiar with MVC template
create a product class with property for displaying
*/
namespace Week_6_day_2_Problem1.Models
{
    public class Product
    {
        public string ProductId {  get; set; }
        public string ProductName {  get; set; }
    }
}
