/*Week_4_day_3_Hands_on_Gunta_Divya
Scenario:
A school wants to calculate the average marks of a student using a class-based approach.
Requirements:
1. Create a class Student.
2. Create method CalculateAverage(int m1, int m2, int m3).
3. Return the average marks.
4. Display grade based on average.
Technical Constraints:
1. Use return type double for average.
2. Avoid hard-coded values.
Expectations:
Clear separation of logic inside methods.
Learning Outcome:
Learn method creation, return values, and basic OOP concepts.
Sample Input: 
80 70 90
Sample Output: 
Average = 80, Grade = A
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_3_p1
{
    //here I am creating the Class name is Student
    class Student
    {
        //I am giving the method name is CalculateAverage for calculating average marks.
        public double CalculateAverage(int m1, int m2, int m3)
        {
            double average = (m1 + m2 + m3) / 3.0;
            return average;

        }
        //Here I am providing the grading depends on average.
        public void Grading(double average)
        {
            if (average >= 80)
            {
                Console.WriteLine("Grade=A");
            }
            else if (average >= 60)
            {
                Console.WriteLine("Grade=B");
            }
            else if (average >= 50)
            {
                Console.WriteLine("Grade=C");
            }
            else
            {
                Console.WriteLine("Grade=Fail");
            }
        }
    }
    internal class Week_4_Problem1
    {
        static void Main(string[] args)
        {
            Student objStudent = new Student();
            Console.WriteLine("Enter a three subject marks");
            int m1 = Convert.ToInt32(Console.ReadLine());
            int m2 = Convert.ToInt32(Console.ReadLine());
            int m3 = Convert.ToInt32(Console.ReadLine());
            double avg = objStudent.CalculateAverage(m1, m2, m3);
            Console.WriteLine($"Average = {avg}");
            objStudent.Grading(avg);
        }
    }
}
    
