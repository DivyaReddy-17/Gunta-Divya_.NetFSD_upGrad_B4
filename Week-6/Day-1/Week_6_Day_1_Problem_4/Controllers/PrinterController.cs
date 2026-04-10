using Microsoft.AspNetCore.Mvc;
using Week_6_Day_1_Problem_4.Models;
using Week_6_Day_1_Problem_4.Models.Interfaces;

namespace Week_6_Day_1_Problem_4.Controllers
{
    public class PrinterController : Controller
    {
        public IActionResult Index()
        {
            // Basic Printer
            IPrinter basic = new BasicPrinter();
            ViewBag.BasicResult = basic.Print("Report.pdf");

            // Advanced Printer
            AdvancedPrinter adv = new AdvancedPrinter();
            ViewBag.PrintResult = adv.Print("Project.docx");
            ViewBag.ScanResult = adv.Scan("Project.docx");
            ViewBag.FaxResult = adv.Fax("Project.docx");

            return View();
        }
    }
}
