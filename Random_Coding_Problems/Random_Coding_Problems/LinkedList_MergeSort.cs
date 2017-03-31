using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://www.geeksforgeeks.org/merge-two-sorted-linked-lists/
//http://www.geeksforgeeks.org/merge-sort-for-linked-list/
namespace Random_Coding_Problems
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int d)
        {
            Data = d;
        }
    }
    

    public class LinkedList_MergeSort
    {
        public static Node Listhead;

        public static void PerformLinkedList_MergeSort()
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);

            n4.Next = n2;
            n2.Next = n1;
            n1.Next = n3;

            Node head = n4;

            PrintList(head);
            MergeSort(ref head);
            Console.WriteLine();
            PrintList(head);

            Listhead = head;

            ReverseListRecursively(ref head);

        }
        static void PrintList(Node n)
        {
            if (n == null)
                return;
            Console.Write(n.Data);
            if (n.Next != null)
                Console.Write("-->");
            PrintList(n.Next);
        }
        private static void MergeSort(ref Node head)
        {
            Node curr = head;
            if (curr == null || curr.Next == null)
                return;

            Node firsthalf = null, secondHalf= null;


            SplitList(curr, ref firsthalf, ref secondHalf);


            MergeSort(ref firsthalf);
            MergeSort(ref secondHalf);

            head = MergeLists(firsthalf, secondHalf);
        }

        private static Node MergeLists(Node firsthalf, Node secondHalf)
        {
            Node dummyNode = new Node(11);

            Node tail = dummyNode;

            while(true)
            {
                if(firsthalf == null)
                {
                    tail.Next = secondHalf;
                    break;
                }
                if (secondHalf == null)
                {
                    tail.Next = firsthalf;
                    break;
                }
                if(firsthalf.Data <= secondHalf.Data)
                {
                    //var nextOffirstHalf = firsthalf.Next;
                    tail.Next = firsthalf;
                    firsthalf = firsthalf.Next;
                }
                else
                {
                    tail.Next = secondHalf;
                    secondHalf = secondHalf.Next;
                }
                tail = tail.Next;
            }

            return dummyNode.Next;
        }

        private static void SplitList(Node currHead, ref Node firsthalf, ref Node secondHalf)
        {
            //if only 0 or 1 element
            if (currHead == null || currHead.Next == null)
            {
                firsthalf = currHead;
                secondHalf = null;
                return;
            }

            Node slow = currHead;
            Node fast = currHead.Next;

            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            firsthalf = currHead;
            secondHalf = slow.Next;
            slow.Next = null; //removing the link between first half and second half            
        }



        //http://www.geeksforgeeks.org/write-a-function-to-reverse-the-nodes-of-a-linked-list/
        private static void ReverseListRecursively(ref Node node)
        {
            Node first = node;
            Node rest = node.Next;
            //0 nodes or 1 node, no need to do anything
            if (first == null || rest == null)
                return;

            ReverseListRecursively(ref rest);

            first.Next.Next = first;

            first.Next = null;

            node = rest;

        }
    }
}
