//https://app.codesignal.com/challenge/p6Ro6CZYq5j3vS7DY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication13
{
    class Program
    {
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }

        }


        static ListNode<int> insert(ListNode<int> root, int item)
        {
            ListNode<int> temp = new ListNode<int>();
            ListNode<int> ptr;
            temp.value = item;
            temp.next = null;

            if (root == null)
                root = temp;
            else
            {
                ptr = root;
                while (ptr.next != null)
                    ptr = ptr.next;
                ptr.next = temp;
            }
            return root;
        }

        static ListNode<int> arrayToList(int[] arr, int n)
        {
            ListNode<int> root = null;
            for (int i = 0; i < n; i++)
                root = insert(root, arr[i]);
            return root;
        }

        static ListNode<int> reverseNodesInKGroups(ListNode<int> l, int k)
        {

            List<int> a = new List<int>();

            for (ListNode<int> temp = l; temp != null; temp = temp.next)
            {
                a.Add(temp.value);
            }

            List<int> arr_out = new List<int>();
            List<int> grupo = new List<int>();
            int cont = 0;
            for (int i = 0; i < a.Count; i++)
            {
                // Console.Write(a[i] + " ");
                if (cont < k)
                {
                    grupo.Add(a[i]);
                    cont++;
                }
                else
                {
                    
                    grupo.Reverse();
                    for (int j = 0; j < grupo.Count; j++)
                    {
                        arr_out.Add(grupo[j]);
                    }

                    cont = 1;
                    grupo = new List<int>();
                    grupo.Add(a[i]);
                }

            }

            if (cont > 0)
            {
                if (grupo.Count == k)
                {
                    grupo.Reverse();
                }
                for (int j = 0; j < grupo.Count; j++)
                {
                    arr_out.Add(grupo[j]);
                }
            }


            //for (int i = 0; i < arr_out.Count; i++)
            //{
            //    Console.Write(arr_out[i] + " ");
            //}

            ListNode<int> xx = arrayToList(arr_out.ToArray(), arr_out.Count);
            //return xx;
            return xx;

        }

        static void Main(string[] args)
        {
            


            int[] arr = {1, 2, 3, 4, 5};
            int k = 2;
            ListNode<int> ll = arrayToList(arr, arr.Length);


            ListNode<int> xx = reverseNodesInKGroups(ll, k);

            for (ListNode<int> temp = xx; temp != null; temp = temp.next)
            {
                Console.Write(temp.value + " ");
            }


           


            Console.ReadLine();
        }

    }
}
