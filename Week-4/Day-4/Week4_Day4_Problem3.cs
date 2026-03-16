/*using Week_4_Day_4_Problem_3_Hands_on_Gunta_Divya;
Scenario:
A company wants to maintain employee records dynamically using a Linked List structure.
Requirements:
-Create Node structure with employee ID and name.
- Implement insertion at beginning and end.
- Implement deletion by employee ID.
- Traverse and display employee list.
Technical Constraints:
-Must implement singly linked list.
- No use of built-in list structures.
- Proper memory handling and pointer updates.
Sample Input:
Insert: (101, John), (102, Sara), (103, Mike)
Delete: 102
Sample Output:
Employee List After Deletion:
101 - John
103 – Mike
Expectations:
-Correct node linking.
-Efficient traversal logic.
-Clean insertion and deletion operations.
Learning Outcome:
-Understand linked list structure.
- Perform insertion and deletion operations.
- Learn dynamic data structure behavior.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_4_Day_4_Problem_3
{
    // here I am creating the node with EmpID,Name,Next properties
    class Node
    {
        public int EmpID;
        public string Name;
        public Node Next;
        //Here I am creating a Constructor with Node.
        public Node(int id, string name)
        {
            EmpID = id;
            Name = name;
            Next = null;
        }
    }

    class LinkedList
    {
        Node head = null;

        // Insert at beginning
        public void InsertAtBeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.Next = head;
            head = newNode;
        }

        // Insert at end
        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
        }

        // Here I am deleting the EmpId 
        public void Delete(int id)
        {
            if (head == null)
                return;

            if (head.EmpID == id)
            {
                head = head.Next;
                return;
            }

            Node temp = head;

            while (temp.Next != null && temp.Next.EmpID != id)
            {
                temp = temp.Next;
            }

            if (temp.Next != null)
            {
                temp.Next = temp.Next.Next;
            }
        }

        // Display employees
        public void Display()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.WriteLine(temp.EmpID + " - " + temp.Name);
                temp = temp.Next;
            }
        }
    }
    internal class Week4_Day4_Problem3
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            // Sample Input
            list.InsertAtEnd(2, "Divya");
            list.InsertAtEnd(3, "Jaya sri");
            list.InsertAtEnd(4,"Ambika");

            list.Delete(4);

            Console.WriteLine("Employee List After Deletion:");
            list.Display();
        }
    }
}
