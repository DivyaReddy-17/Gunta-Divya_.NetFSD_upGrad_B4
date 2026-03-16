/*Scenario:
A training institute wants to analyze student scores stored in an array. The system should calculate total marks, average, highest score, and count of students scoring above a threshold.
Requirements:
- Store student marks in an array.
- Use array methods (push, map, filter, reduce) for processing.
- Store subject-wise highest marks using a Map (key-value pair).
- Display total, average, and filtered results.
Technical Constraints:
- Must use array indexing and iteration.
- Use reduce() for total calculation.
- Use filter() for threshold-based filtering.
- Use Map or Dictionary for subject-highest mapping.
Sample Input:
Marks: [78, 85, 90, 67, 88]
Threshold: 80
Sample Output:
Total Marks: 408
Average Marks: 81.6
Students above 80: 3
Highest Score: 90
Expectations:
- Clean and modular implementation.
- Proper use of array methods.
- Efficient iteration logic.
Learning Outcome:
- Understand array manipulation.
- Use Map for key-value storage.
- Apply functional programming methods.
*/
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Week_4_Day_4
{
    internal class Week_4_Day_4_p1
    {
        static void Main(string[] args)
        {
            //Here I am storing the marks in an array.
            int[] marks = { 78, 85, 90, 67, 88 };
            int threshold = 80;
            //here I am using the aggregate method to aggregation.
            int Totalmarks = marks.Aggregate((sum, mark) => sum + mark);
            double Averagemarks = (double)Totalmarks / marks.Length;
            int Highestscore = marks.Max();
            var AboveThreshold = marks.Where(mark => mark > threshold);
            Console.WriteLine("Total Marks" + Totalmarks);
            Console.WriteLine("Average Marks" + Averagemarks);
            Console.WriteLine("Student above" + threshold + ":" + AboveThreshold.Count());
            Console.WriteLine("Highest Score" + " " + Highestscore);
        }
        //Here I am using the dictionary to store subject wise highest marks.
        static Dictionary<string, int> GetSubjectHighestMarks()
        {
            Dictionary<string, int[]> subjectMarks = new Dictionary<string, int[]>
            {
                { "Math", new int[] {78,85,90,67,88} },
                { "Physics", new int[] {80,70,95,88,84} },
                { "Chemistry", new int[] {60,75,89,92,77} }
            };

            Dictionary<string, int> subjectHighest = new Dictionary<string, int>();

            foreach (var subject in subjectMarks)
            {
                // Aggregate used to find highest mark
                int highest = subject.Value.Aggregate((MAX, m) => m > MAX ? m : MAX);

                subjectHighest.Add(subject.Key, highest);
            }

            return subjectHighest;
        }
    }
}











