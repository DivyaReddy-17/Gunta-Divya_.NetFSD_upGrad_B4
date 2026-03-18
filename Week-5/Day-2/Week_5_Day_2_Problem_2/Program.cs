/*using System.Runtime.InteropServices;

Scenario:
An administrator wants to check file properties stored in a particular folder for auditing purposes.
Requirements:
1.Accept a folder path from the user.
2. Display file name, file size, and creation date.
3. Count and display the total number of files.
Technical Constraints:
• Use FileInfo class.
• Handle invalid directory paths.
Expectations:
The program should list file details clearly in the console.
Learning Outcome:
Students will understand how to retrieve file metadata using FileInfo
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Day_2_Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter folder path");
            string folderPath=Console.ReadLine();
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path");
                    return;
                }
                string[] files = Directory.GetFiles(folderPath);
                int fileCount = 0;
                Console.WriteLine("File Details:");
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine("File Name: " + fileInfo.Name);
                    Console.WriteLine("File size: " + fileInfo.Length + "bytes");
                    Console.WriteLine("created Date: " + fileInfo.CreationTime);
                    fileCount++;

                }
                Console.WriteLine("Total files:" + fileCount);
            }
            catch(Exception ex)
            {
                Console.WriteLine("error occured: " + ex.Message);
            }

        }
    }
}
