using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://blog.gainlo.co/index.php/2016/06/12/flatten-a-linked-list/
namespace LinkedList_Flatten_a_LinkedList
{

    class Node
    {
        public Node Next;
        public Node Child;
        public int Data;


        public void SetValues(int d, Node next,Node child)
        {
            Data = d;
            Next = next;
            Child = child;
        }
    }
    class Program
    {
        //In place method with two pointers
        private static Node Flatten_List(Node head)
        {
            if (head == null)
                return null;

            Node a = head;
            Node b = head;

            while (b != null)
            {
                //Go deep until a hits a.Next hits all
                while (a.Next != null)
                {
                    a = a.Next;
                }
                //Move b until you find a node which has non null child node. 
                while (b != null && b.Child == null)
                    b = b.Next;
                if (b == null) //If b also reached end of the chain the means no element found which has child, means list already flatten
                    break;

                //Now set B'st child as A's next node
                a.Next = b.Child;
                b.Child = null;
                //Now move the b further
                b = b.Next;
            }
            return head;
        }

        private static void PrintList(Node head)
        {
            while(head!= null)
            {
                Console.Write(head.Data);
                head = head.Next;
                if (head != null)
                    Console.Write("-->");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Node n1 = new Node();
            Node n2 = new Node();
            Node n3 = new Node();
            Node n4 = new Node();
            Node n5 = new Node();
            Node n6 = new Node();
            Node n7 = new Node();
            Node n8 = new Node();
            Node n9 = new Node();

            //Test case 1: List as per given picture
            n1.SetValues(1, n2, null);
            n2.SetValues(2, n3, n5);
            n3.SetValues(3, n4, null);
            n4.SetValues(4, null, n7);
            n5.SetValues(5, n6, n8);
            n6.SetValues(6, null, null);
            n7.SetValues(7, null, n9);
            n8.SetValues(8, null, null);
            n9.SetValues(9, null, null);

            var flatten_listHead = Flatten_List(n1);
            PrintList(flatten_listHead);

            //Test case 2: Taking only 1,2,5, 8 from picture
            n1.SetValues(1, n2, null);
            n2.SetValues(2, null, n5);
            n5.SetValues(5, null, n8);
            n8.SetValues(8, null, null);

            flatten_listHead = Flatten_List(n1);
            PrintList(flatten_listHead);

            //Test case 3:Taking only 1 from picture
            n1.SetValues(1, null, null);
            flatten_listHead = Flatten_List(n1);
            PrintList(flatten_listHead);

            //Test case 4:Taking single node with all Childs from picture
            n1.SetValues(1, null,n2);
            n2.SetValues(2, null, n3);
            n3.SetValues(3, null, n4);
            n4.SetValues(4, null, null);

            flatten_listHead = Flatten_List(n1);
            PrintList(flatten_listHead);

            Console.ReadKey();
        }               
    }
}
