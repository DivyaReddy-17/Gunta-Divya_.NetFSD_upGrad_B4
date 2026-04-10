using Week_6_Day_1_Problem_4.Models.Interfaces;

namespace Week_6_Day_1_Problem_4.Models
{
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public string Print(string document)
        {
            return $"AdvancedPrinter: Printing {document}";
        }

        public string Scan(string document)
        {
            return $"AdvancedPrinter: Scanning {document}";
        }

        public string Fax(string document)
        {
            return $"AdvancedPrinter: Faxing {document}";
        }

        dynamic IPrinter.Print(string v)
        {
            return Print(v);
        }
    }
}
