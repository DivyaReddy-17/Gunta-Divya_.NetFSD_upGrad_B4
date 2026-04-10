using Week_6_Day_1_Problem_4.Models.Interfaces;

namespace Week_6_Day_1_Problem_4.Models
{
    public class BasicPrinter : IPrinter
    {
        public string Print(string document)
        {
            return $"BasicPrinter: Printing {document}";
        }

        dynamic IPrinter.Print(string v)
        {
            return Print(v);
        }
    }
}
