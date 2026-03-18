using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_5_Day_2_Problem_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Root directory path");
            string rootPath=Console.ReadLine();
            try
            {
                if(!Directory.Exists(rootPath))
                {
                    Console.WriteLine("Invalid directory path");
                    return;

                }
                DirectoryInfo dirInfo=new DirectoryInfo(rootPath);
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();
                if(subDirs.Length==0)
                {
                    Console.WriteLine("No Subdirectories found");
                    return;

                }
                Console.WriteLine("Directories Details");
                foreach(DirectoryInfo subDir in subDirs)
                {
                    FileInfo[] files = subDir.GetFiles();
                    Console.WriteLine("Folder Name:" + subDir.Name);
                    Console.WriteLine("FileCount :" + files.Length);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured :" +ex.Message);
            }
        }
    }
}
