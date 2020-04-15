//https://app.codesignal.com/challenge/XDFFwxLCs52YeJb9H

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19
{

    class Program
    {
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        static ListNode<int> insertValueIntoSortedLinkedList(ListNode<int> l, int value)
        {

            ListNode<int> current;
            ListNode<int> new_node = new ListNode<int>();
            new_node.value = value;

            /* Special case for head node */
            if (l == null || l.value >= new_node.value)
            {
                new_node.next = l;
                l = new_node;
            }
            else
            {

                /* Locate the node before  
                point of insertion. */
                current = l;

                while (current.next != null &&
                    current.next.value < new_node.value)
                    current = current.next;

                new_node.next = current.next;
                current.next = new_node;
            }

            return l;

        }

        /* Function to print linked list */
        static void printList(ListNode<int> head)
        {
            ListNode<int> temp = head;
            while (temp != null)
            {
                Console.Write(temp.value + " ");
                temp = temp.next;
            }
        }

        /* Driver code */
        public static void Main(String[] args)
        {
            ListNode<int> llist = new ListNode<int>();
            //ListNode<int> new_node;

            //new_node = new ListNode<int>();
            
            //new_node.value = 5;
            insertValueIntoSortedLinkedList(llist, 5);
            insertValueIntoSortedLinkedList(llist, 10);
            insertValueIntoSortedLinkedList(llist, 7);
            insertValueIntoSortedLinkedList(llist, 3);
            insertValueIntoSortedLinkedList(llist, 1);
            insertValueIntoSortedLinkedList(llist, 9);


            Console.WriteLine("Created Linked List");
            printList(llist);


            Console.ReadLine();

        } 
    }
}
