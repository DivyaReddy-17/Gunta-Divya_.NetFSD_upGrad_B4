/*using System.Runtime.Intrinsics.X86;
using System.Text;
using Week_6_Day_1_Problem_1;
Scenario: Student Report Generator
A training institute like Codempower Academy maintains student information and generates performance reports. Currently, one class performs student data storage and report generation, which makes the code difficult to maintain.

Requirements:


1.Create a Student class with properties:
•	StudentId
•	StudentName
•	Marks
2.Create a class responsible for managing student data.
3.Create a separate class responsible for generating reports.
 4.The report should display:

Security Requirements(Secure Coding Practices)
Students must implement the following security measures:
Technical Constraints:
•	Use C# (.NET Console Application).
•	Each class must have only one responsibility.
•	Do not mix data storage and report generation logic in the same class.
Expectations:
Students should implement at least three classes:
•	Student
•	StudentRepository
•	ReportGenerator
Program Flow Diagram
 Learning Outcome:
Students will learn:
•	Meaning of Single Responsibility Principle
•	How to separate responsibilities
•	How SRP improves maintainability and testing
*/

namespace Week_6_Day_1_Problem_1
{
    public class Student
    {
        public int StudentId {  get; set; }
        public string StudentName { get; set; }
        public int Marks {  get; set; }
    }
    public class StudentRepository
    {
        private List<Student>students = new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);

        }
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
    public class ReportGenerator
    {
        public void GeneratorReport(List<Student> students)
        {
            Console.WriteLine("------Students Report------");
            foreach (var student in students)
            {
                Console.WriteLine($"ID:{student.StudentId}");
                Console.WriteLine($"Name:{student.StudentName}");
                Console.WriteLine($"Marks:{student.Marks}");
                string grade = GetGrade(student.Marks);
                Console.WriteLine($"Grade:{grade}");
            }

        }
        private string GetGrade(int marks)
        {
            return marks switch
            {

                >= 90 => "A",

                >= 75 => "B",
                >= 50 => "C",
                _ => "Fail"
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentRepository repository= new StudentRepository();
            ReportGenerator generator= new ReportGenerator();
            repository.AddStudent(new Student { StudentId = 1, StudentName = "Divya", Marks = 80 });
            repository.AddStudent(new Student { StudentId = 5, StudentName = "Deepak", Marks = 70 });
            repository.AddStudent(new Student { StudentId = 3, StudentName = "Selvaraj", Marks = 100 });
            var students=repository.GetAllStudents();
            generator.GeneratorReport(students);
            Console.WriteLine("press any key");
            Console.ReadKey();
        }
    }
}
