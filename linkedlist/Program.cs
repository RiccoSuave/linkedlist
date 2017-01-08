using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace linkedlist
{
    class Program
    {
        static void Main()
        {
            //create a linked list
            string[] words = { "Shahin", "Ansari", "the","Bright", "strong", "Good Looking", "fit",
                "potent","viral" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            Display(sentence, "The linked list values:");
            Console.WriteLine("Sentence contains (\"bright\") {0}", sentence.Contains("bright"));
            //Add the word today to the beggining of the linked list 
            sentence.AddFirst("today");
            Display(sentence, "Test1 - add the word today to the beginning of the linked list ");
            //Move the first node to the last node
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            Display(sentence, "Test 3: Move the first node to the last node: ");
            //Change the last node to be yesterday
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            Display(sentence, "Test 3: Change the last node to 'yesterday': ");
            //Move the last node to be the first node 
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            Display(sentence, "Move last node to be first node ");
            //Indicate by using parathesis, the last occurence of 'the'.
            LinkedListNode<string> current = sentence.FindLast("the");

            IndicateNode(current, "Test 5: Indicate last occurance of 'the':");

            // Add the words 'lazy' and 'old' after 'the' 
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            IndicateNode(current, "Add the words 'lazy' and 'old' after 'the' ");
            current = sentence.Find("Good Looking");
            IndicateNode(current, "Test 7: Indicate the 'fox' node:");
            // Add quick and brown before 'fox'
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            IndicateNode(current, "Add quick and brown before 'fox'");
            // keep the reference to the current node 'Good Looking'
            //and to the previous node in the list. Indicate the 'brown'
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            
            IndicateNode(mark2, "Indicate the 'brown'");
            try
            {
                sentence.AddBefore(mark1, current);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception message: {0}", ex.Message);
            }
            current = mark2;
            //remove the node marked by mark1, and then add it before the node refered to by current
            //indicate the node refered to by current 
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            IndicateNode(current, "Move a referenced node 'Good Looking' before the current node 'brown'");
            //remove the node refered to by current 
            sentence.Remove(current);
            IndicateNode(current, "Remove a node and attempt to indicate it");
            //Add a node after the node refered to by mark2
            //sentence.AddAfter(mark2, current);
            IndicateNode(current, "Add the node you removed in previous test after a referenced node ");
            //The remove method finds and remove the first node, which has the specified value 
            sentence.Remove("Shahin");
            Display(sentence, "Remove the node which has the value 'Shahin'");
            //When the linked list is cast to ICollection<string> of string type 
            //The add method adds a node to the end of the list 
            sentence.RemoveLast();
            ICollection<string> Icoll = sentence;
            Icoll.Add("rhinoceros");
            Display(sentence, "Remove the last node cast to ICollection add rhinoceros to the end of it");
            Console.WriteLine("Test 16 - Copy the list to an array ");
            // Create an array with the same number of elements as the linked list 
            string[] myArray = new string[sentence.Count];
            sentence.CopyTo(myArray,0);
            foreach (string s in myArray)
            {
                Console.WriteLine(s);
            }
            //release all the nodes 
            sentence.Clear();
            Console.WriteLine("Clear linked list, contains Ansari {0}", sentence.Contains("Ansari"));
            //sentence.Contains("Ansari");
            Console.ReadLine();
        }
        private static void IndicateNode(LinkedListNode<string> node,string test)
        {
            Console.WriteLine(test);
            if (node.List == null)
            {
                Console.WriteLine("Node '{0}' is not in the list.\n", node.Value);
                return;
            }
            StringBuilder result = new StringBuilder("("+ node.Value +")");
            LinkedListNode<string> nodeP = node.Previous;
            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }
            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }
            Console.WriteLine(result);
            Console.WriteLine();
        }
        private static void Display(LinkedList<string> words,string test )
        {
            Console.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
