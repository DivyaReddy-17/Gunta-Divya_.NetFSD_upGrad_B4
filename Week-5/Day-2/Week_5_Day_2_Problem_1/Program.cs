/*
 * Scenario:
A small organization wants to store simple log messages into a text file using a C# console application.
Requirements:
1. Accept a message from the user.
2. Write the message into a file using FileStream.
3. Append multiple messages to the same file.
4. Display confirmation after writing the data.
Technical Constraints:
• Use FileStream class.
• Use appropriate FileMode and FileAccess.
• Implement exception handling for file access errors.
Expectations:
The application should successfully write user messages to the file and allow multiple entries.
Learning Outcome:
Students will learn how to create and write data into files using FileStream.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Day_2_Problem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\gunta\source\repos\logfile.txt";
            try
            {
                Console.WriteLine("Enter the message");
                string msg = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(msg + Environment.NewLine);
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }
                Console.WriteLine("Message is written in file");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: + ex.Message");
            }
        }
    }
}
