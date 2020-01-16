using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {

        static bool tripletSum(int x, int[] a)
        {

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    //if (a.Contains(x - (a[i] + a[j])))
                    //{
                    //    return true;
                    //}
                    int indice_elem = Array.IndexOf(a, x - (a[i] + a[j]));
                    if (indice_elem != -1 && indice_elem != i && indice_elem != j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //----------------------------------------------
        //
        // Definition for binary tree:
        class Tree<T>
        {
            public T value { get; set; }
            public Tree<T> left { get; set; }
            public Tree<T> right { get; set; }
        }

        //http://www.geeksforgeeks.org/level-order-tree-traversal/
        //level order tree traversal
        static int[] traverseTree(Tree<int> t)
        {
            if (t == null)
            {
                return new int[0];
            }

            List<int> res = new List<int>();
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            queue.Enqueue(t);
            while (queue.Count > 0)
            {

                /* poll() removes the present head.
                For more information on poll() visit 
                http://www.tutorialspoint.com/java/util/linkedlist_poll.htm */
                Tree<int> tempNode = queue.Dequeue();
                Console.WriteLine(tempNode.value + " ");
                res.Add(tempNode.value);

                /*Enqueue left child */
                if (tempNode.left != null)
                {
                    queue.Enqueue(tempNode.left);
                }

                /*Enqueue right child */
                if (tempNode.right != null)
                {
                    queue.Enqueue(tempNode.right);
                }
            }
            return res.ToArray();
        }


        static bool sumOfTwo(int[] a, int[] b, int v)
        {
            Array.Sort(b);
            for (int i = 0; i < a.Length; i++)
            {
                int indice = Array.BinarySearch(b, v - a[i]);
                if (indice > -1)
                {
                    return true;
                }

            }
            return false;
        }

        long sumInRange(int[] nums, int[][] queries)
        {
            Dictionary<long, long> diccio = new Dictionary<long, long>();

            long sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                diccio[i] = sum;
            }

            //foreach (KeyValuePair<long, long> kvp in diccio)
            //{
            //    Console.WriteLine(kvp.Key + " " + kvp.Value);
            //}

            long ans = 0;
            foreach (int[] q in queries)
            {
                if (q[0] - 1 >= 0)
                {
                    ans += (long)((long)diccio[q[1]] - (long)diccio[q[0] - 1]);

                    ans %= 1000000007;
                    // Console.Write((diccio[q[1]] - diccio[q[0] - 1]) + " ");
                }
                else
                {
                    ans += (long)diccio[q[1]];
                    //Console.Write(diccio[q[1]] + " ");
                    ans %= 1000000007;

                }
            }

            //return ans % 1000000007;

            long m = 1000000007; //comment section removed * signs between the tens
            long modulo = ((long)Math.Abs(ans) % m);
            if (ans == modulo)
            {
                return ans;
            }
            return (m - modulo);

        }


        static bool sudoku2(char[][] grid)
        {
            //comprobar fila por fila
            for (int i = 0; i < 9; i++)
            {
                HashSet<char> filaActual = new HashSet<char>();
                HashSet<char> colActual = new HashSet<char>();
                for (int j = 0; j < 9; j++)
                {
                    if (char.IsNumber(grid[i][j]))
                    {

                        if (filaActual.Contains(grid[i][j]))
                        {
                            return false;
                        }
                        filaActual.Add(grid[i][j]);
                    }

                    if (char.IsNumber(grid[j][i]))
                    {
                        if (colActual.Contains(grid[j][i]))
                        {
                            return false;
                        }
                        colActual.Add(grid[j][i]);
                    }
                }
            }


            for (int fila = 0; fila < 9; fila += 3)
            {
                for (int col = 0; col < 9; col += 3)
                {
                    HashSet<char> cuadrante = new HashSet<char>();
                    for (int i = fila; i < fila + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            if (char.IsNumber(grid[i][j]))
                            {
                                if (cuadrante.Contains(grid[i][j]))
                                {
                                    return false;
                                }
                                cuadrante.Add(grid[i][j]);
                            }

                        }
                    }

                }

            }

            return true;

        }



        static int strstr(string s, string x)
        {
            int d = 256;
            int q = 101;

            char[] text = s.ToCharArray();
            char[] pat = x.ToCharArray();

            int M = pat.Length;
            int N = text.Length;
            int i, j;
            int p = 0; // hash value for pattern
            int t = 0; // hash value for txt
            int h = 1;

            // The value of h would be "pow(d, M-1)%q"
            for (i = 0; i < M - 1; i++)
                h = (h * d) % q;

            // Calculate the hash value of pattern and first
            // window of text
            for (i = 0; i < M; i++)
            {
                p = (d * p + pat[i]) % q;
                t = (d * t + text[i]) % q;
            }

            // Slide the pattern over text one by one
            for (i = 0; i <= N - M; i++)
            {

                // Check the hash values of current window of text
                // and pattern. If the hash values match then only
                // check for characters on by one
                if (p == t)
                {
                    /* Check for characters one by one */
                    for (j = 0; j < M; j++)
                    {
                        if (text[i + j] != pat[j])
                            break;
                    }

                    // if p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]
                    if (j == M)
                    {
                        // printf("Pattern found at index %d \n", i);
                        return i;
                    }
                }

                // Calculate hash value for next window of text: Remove
                // leading digit, add trailing digit
                if (i < N - M)
                {
                    t = (d * (t - text[i] * h) + text[i + M]) % q;

                    // We might get negative value of t, converting it
                    // to positive
                    if (t < 0)
                        t = (t + q);
                }
            }

            return -1;
        }

        static string stringReformatting(string s, int k)
        {
            string join = String.Join("", s.Split('-'));
            //Console.WriteLine(join);
            List<string> ans = new List<string>();
            string temp = "";
            int i;
            for (i = join.Length - k; i >= 0; i -= k)
            {
                temp = join.Substring(i, k);
                //Console.WriteLine(temp);
                ans.Insert(0, temp);
            }
            if (i < 0)
            {
                string resto = join.Substring(0, i + k);
                if (resto.Length > 0)
                {
                    ans.Insert(0, resto);
                }
            }
            //Console.WriteLine(i);
            return string.Join("-", ans.ToArray());
        }


        //------------------------------------------------

        static bool nextPermutation(char[] array)
        {
            // Find non-increasing suffix
            int i = array.Length - 1;
            while (i > 0 && array[i - 1] >= array[i])
                i--;
            if (i <= 0)
                return false;

            // Find successor to pivot
            int j = array.Length - 1;
            while (array[j] <= array[i - 1])
                j--;
            char temp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = temp;

            // Reverse suffix
            j = array.Length - 1;


            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
            return true;
        }


        static string[] stringPermutations(string s)
        {

            char[] ch = s.ToCharArray();
            Array.Sort(ch);
            List<string> ans = new List<string>();

            do
            {
                ans.Add(new string(ch));

            } while (nextPermutation(ch));

            return ans.ToArray();
        }


        //------------------------------------------------


        static bool[] squaresUnderQueenAttack(int n, int[][] queens, int[][] queries)
        {
            //ArrayList<Boolean> ans = new ArrayList<Boolean>();
            bool[] ans = new bool[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                bool atacada = false;
                for (int j = 0; j < queens.Length; j++)
                {
                    if (queries[i][0] == queens[j][0]
                        || queries[i][1] == queens[j][1] ||
                        (Math.Abs(queries[i][0] - queens[j][0]) == Math.Abs(queries[i][1] - queens[j][1])))
                    {
                        atacada = true;
                        break;
                    }
                }
                //ans.add(atacada);
                ans[i] = atacada;
            }

            // return ans.ToArray();

            return ans;
        }
        //---------------------------------------------------
        static void quicksort(int[] vector, int primero, int ultimo)
        {
            int i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = vector[central];
            i = primero;
            j = ultimo;
            do
            {
                while (vector[i] < pivote) i++;
                while (vector[j] > pivote) j--;
                if (i <= j)
                {
                    int temp;
                    temp = vector[i];
                    vector[i] = vector[j];
                    vector[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (primero < j)
            {
                quicksort(vector, primero, j);
            }
            if (i < ultimo)
            {
                quicksort(vector, i, ultimo);
            }
        }

        static int[] sortedSquaredArray(int[] array)
        {
            int[] squares = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i] * array[i];
            }
            quicksort(array, 0, array.Length - 1);

            return array;
        }


        //----------------------------------------------------------


        static string sortByString(string s, string t)
        {

            Dictionary<char, int> frec = s.ToCharArray().GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            string ans = "";

            for (int i = 0; i < t.Length; i++)
            {
                if (frec.ContainsKey(t[i]))
                {
                    for (int j = 0; j < frec[t[i]]; j++)
                    {
                        ans += t[i];
                    }
                }
            }
            return ans;

        }


        static int singleNumber(int[] nums)
        {
            int xor = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                xor ^= nums[i];
            }
            return xor;
        }


        static int[][] rotateImage(int[][] a)
        {
            int[][] res = new int[a.Length][];
            for (int i = 0; i < a.Length; i++)
            {
                res[i] = new int[a.Length];
                for (int j = 0; j < a.Length; j++)
                {
                    res[i][a.Length - j - 1] = a[j][i];
                }
            }
            return res;
        }

        static bool esVocal(char ch)
        {
            return "aeiouAEIOU".Contains(ch);
        }

        static string reverseVowelsOfString(string s)
        {
            char[] ch = s.ToCharArray();
            int i = 0, j = s.Length - 1;

            while (i < j)
            {
                while (i < j && !esVocal(ch[i]))
                {
                    i++;
                }
                while (i < j && !esVocal(ch[j]))
                {
                    j--;
                }
                if (i < j)
                {
                    char temp = ch[i];
                    ch[i] = ch[j];
                    ch[j] = temp;
                    i++;
                    j--;
                }
            }
            return new string(ch);
        }

        static string reverseSentence(string sentence)
        {
            string[] rev = sentence.Split(' ');
            Array.Reverse(rev);
            return string.Join(" ", rev);
        }


        static int reverseInteger(int x)
        {
            string xs = x.ToString();
            char[] rev;
            if (x < 0)
                rev = xs.Substring(1, xs.Length - 1).ToCharArray();

            else
                rev = xs.ToCharArray();

            Array.Reverse(rev);
            int res = int.Parse(new string(rev));
            if (x < 0)
            {
                return (-1) * res;
            }
            return res;
        }

        static int reverseInteger(int x)
        {
            string xs = x.ToString();
            char[] rev;
            if (x < 0)
            {
                rev = xs.Substring(1, xs.Length - 1).ToCharArray();
                Array.Reverse(rev);
                return int.Parse("-" + new string(rev));
            }
            else
            {
                rev = xs.ToCharArray();
                Array.Reverse(rev);
                return int.Parse(new string(rev));
            }


        }



        static string[] repeatedDNASequences(string s)
        {
            Dictionary<string, int> diccio = new Dictionary<string, int>();

            for (int i = 0; i <= s.Length - 10; i++)
            {
                string subs = s.Substring(i, 10);

                if (diccio.ContainsKey(subs))
                {
                    diccio[subs]++;
                }
                else
                {
                    diccio[subs] = 1;
                }
                //Console.WriteLine(subs);
            }

            List<string> keys = new List<string>();
            foreach (KeyValuePair<string, int> kvp in diccio)
            {
                if (kvp.Value > 1)
                {
                    keys.Add(kvp.Key);
                }
            }

            keys.Sort();

            return keys.ToArray();
        }


        //----------------------------------------
        //Definition for singly-linked list:
        class ListNode<T>
        {
            public T value { get; set; }
            public ListNode<T> next { get; set; }
        }

        static ListNode<int> removeKFromList(ListNode<int> l, int k)
        {
            while (l != null && l.value == k) l = l.next;
            ListNode<int> curr = l;
            while (curr != null && curr.next != null)
            {
                if (curr.next.value == k) curr.next = curr.next.next;
                else curr = curr.next;
            }
            return l;
        }


        //-----------------------------------------------------
        static int productExceptSelf(int[] nums, int m)
        {
            //http://blog.codefights.com/productexceptself-solution/?subscribe=success#451
            int p = 1;
            int g = 0;
            foreach (int x in nums)
            {
                g = (g * x + p) % m;
                p = (p * x) % m;
            }
            return g;
        }


        static long primesSum2(int n)
        {
            // Create a boolean array "prime[0..n]" and initialize
            // all entries it as true. A value in prime[i] will
            // finally be false if i is Not a prime, else true.
            bool[] prime = new bool[n + 1];
            //memset(prime, true, sizeof(prime));
            prime = Enumerable.Repeat(true, n + 1).ToArray();

            for (int p = 2; p * p <= n; p++)
            {
                // If prime[p] is not changed, then it is a prime
                if (prime[p] == true)
                {
                    // Update all multiples of p
                    for (int i = p * 2; i <= n; i += p)
                        prime[i] = false;
                }
            }

            long sum = 0;
            // Print all prime numbers
            for (int p = 2; p <= n; p++)
            {
                if (prime[p])
                {
                    //   Console.Write(p + " ");
                    sum += p;
                }
            }
            return sum % 1000000007;
        }



        public static string[] pressingButtons(String buttons)
        {
            Dictionary<int, String> map = new Dictionary<int, String>();
            map.Add(2, "abc");
            map.Add(3, "def");
            map.Add(4, "ghi");
            map.Add(5, "jkl");
            map.Add(6, "mno");
            map.Add(7, "pqrs");
            map.Add(8, "tuv");
            map.Add(9, "wxyz");
            map.Add(0, "");

            List<String> result = new List<string>();

            if (buttons == null || buttons.Length == 0)
                return result.ToArray();

            List<char> temp = new List<char>();
            getString(buttons, temp, result, map);

            return result.ToArray();
        }

        public static void getString(String digits, List<char> temp, List<String> result, Dictionary<int, String> map)
        {
            if (digits.Length == 0)
            {
                char[] arr = new char[temp.Count];
                for (int i = 0; i < temp.Count; i++)
                {
                    arr[i] = temp[i];
                }
                result.Add(new string(arr));
                return;
            }

            int curr = int.Parse(digits.Substring(0, 1)); // Integer.valueOf(digits.substring(0, 1));
            String letters = map[curr];
            for (int i = 0; i < letters.Length; i++)
            {
                temp.Add(letters[i]);
                getString(digits.Substring(1), temp, result, map);
                temp.RemoveAt(temp.Count - 1);
                //temp.remove(temp.size() - 1);
            }
        }





        //------------------------------------------

        static int pairsSum(int[] a)
        {
            Array.Sort(a);
            int ans = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (Array.BinarySearch(a, (a[i] + a[j])) > -1)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }


        static int numberOf1Bits(int n)
        {
            return Convert.ToString(n, 2).Count(e => e == '1');
        }

        public static int[] nextLarger(int[] a)
        {
            Stack<int> st = new Stack<int>();
            int[] res = new int[a.Length];
            for (int i = a.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && a[i] > st.Peek())
                {
                    st.Pop();
                }

                if (st.Count == 0)
                {
                    res[i] = -1;
                }
                else
                {
                    res[i] = st.Peek();
                }

                st.Push(a[i]);
            }
            return res;
        }


        static string multiplyTwoStrings(string s1, string s2)
        {

            string C = "";
            int next = 0;
            for (int k = 0; k < s1.Length + s2.Length - 1; k++)
            {
                int cur = next;
                int i, j;
                if (k < s1.Length)
                {
                    i = s1.Length - 1 - k;
                    j = s2.Length - 1;
                }
                else
                {
                    i = 0;
                    j = s1.Length + s2.Length - 2 - k;
                }
                while (i < s1.Length && j >= 0)
                {
                    cur += int.Parse(s1[i].ToString()) * int.Parse(s2[j].ToString());
                    i++;
                    j--;
                }

                C = C.Insert(0, (cur % 10).ToString());
                next = cur / 10;

            }
            if (next > 0)
            {
                C = C.Insert(0, next.ToString());
            }

            return C;
        }

        static int missingNumber(int[] arr)
        {
            bool[] elems = new bool[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                elems[arr[i]] = true;
            }
            return Array.IndexOf(elems, false);
        }

        string minSubstringWithAllChars(string s, string t)
        {

            if (t == "") return "";

            string min_subs = "";
            int len_min = int.MaxValue;
            for (int i = 0; i < s.Length; i++)
            {
                HashSet<char> hs = new HashSet<char>();
                for (int j = i; j < s.Length; j++)
                {
                    if (t.Contains(s[j]))
                    {
                        hs.Add(s[j]);
                        //cont++;
                    }
                    if (hs.Count == t.Length)
                    {
                        if (j - i + 1 < len_min)
                        {
                            len_min = j - i + 1;
                            min_subs = s.Substring(i, j - i + 1);
                        }
                        break;
                    }
                }

            }
            return min_subs;
        }

        static string minSubstringWithAllChars(string s, string t)
        {
            if (t == "") return "";

            string min_subs = s;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    string subs = s.Substring(i, j - i + 1);

                    int k = 0;
                    for (k = 0; k < t.Length; k++)
                    {
                        if (!subs.Contains(t[k]))
                        {
                            break;
                        }
                    }
                    if (k == t.Length)
                    {
                        if (subs.Length < min_subs.Length)
                        {
                            min_subs = subs;
                        }
                    }
                }
            }
            return min_subs;
        }


        static int mapDecoding(String message)
        {
            if (message == null)
            {
                return 0;
            }
            if (message.Length == 0) return 1;
            int n = message.Length;
            long[] dp = new long[n + 1];
            dp[0] = 1;
            dp[1] = message[0] != '0' ? 1 : 0;
            for (int i = 2; i <= n; i++)
            {
                int first = int.Parse(message.Substring(i - 1, i - (i - 1)));
                //System.out.println(first);
                int second = int.Parse(message.Substring(i - 2, i - (i - 2)));
                if (first >= 1 && first <= 9)
                {
                    dp[i] += dp[i - 1] % 1000000007;
                }
                if (second >= 10 && second <= 26)
                {
                    dp[i] += dp[i - 2] % 1000000007;
                }
            }
            return (int)(dp[n] % 1000000007);
        }



        static int CeilIndex(int[] v, int l, int r, int key)
        {
            while (r - l > 1)
            {
                int m = l + (r - l) / 2;
                if (v[m] >= key)
                    r = m;
                else
                    l = m;
            }

            return r;
        }


        static int longestIncreasingSubsequence(int[] sequence)
        {

            if (sequence.Length == 0)
                return 0;

            int[] tail = new int[sequence.Length];
            int length = 1; // always points empty slot in tail

            tail[0] = sequence[0];
            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] < tail[0])

                    tail[0] = sequence[i];
                else if (sequence[i] > tail[length - 1])

                    tail[length++] = sequence[i];
                else
                    tail[CeilIndex(tail, -1, length - 1, sequence[i])] = sequence[i];


            }

            return length;
        }



        //------------------------------------------------
        class Tree<T>
        {
            public T value { get; set; }
            public Tree<T> left { get; set; }
            public Tree<T> right { get; set; }
        }


        static int[] largestValuesInTreeRows(Tree<int> t)
        {
            // Base Case
            if (t == null) return new int[0];

            // Create an empty queue for level order tarversal
            //queue<node*> q;
            Queue<Tree<int>> q = new Queue<Tree<int>>();

            // Enqueue Root and initialize height
            q.Enqueue(t);

            List<int> ans = new List<int>();

            while (true)
            {
                // nodeCount (queue size) indicates number of nodes
                // at current lelvel.
                int nodeCount = q.Count;
                if (nodeCount == 0)
                    break;

                // Dequeue all nodes of current level and Enqueue all
                // nodes of next level
                int max = int.MinValue;
                while (nodeCount > 0)
                {
                    Tree<int> node = q.Peek();
                    // Console.Write(node.value + " ");
                    max = Math.Max(max, node.value);

                    q.Dequeue();
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                    nodeCount--;
                }
                ans.Add(max);
                // Console.WriteLine(max);
                // Console.WriteLine();
            }

            return ans.ToArray();
        }

        static int kthLargestElement(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }


        static bool isPowerOfTwo2(string n)
        {
            if (n == "1") return true;
            long l = long.Parse(n);
            while (l > 0)
            {
                if (l % 2 == 0)
                {
                    l /= 2;
                    if (l == 1) return true;

                }
                else
                {
                    return false;
                }
            }
            return l == 0;
        }



        static bool isListPalindrome(ListNode<int> l)
        {

            if (l == null)
            {
                return true;
            }
            ListNode<int> p1 = l;
            ListNode<int> p2 = l;
            ListNode<int> p3 = p1.next;
            ListNode<int> pre = p1;
            //find mid pointer, and reverse head half part
            while (p2.next != null && p2.next.next != null)
            {
                p2 = p2.next.next;
                pre = p1;
                p1 = p3;
                p3 = p3.next;
                p1.next = pre;
            }

            //odd number of elements, need left move p1 one step
            if (p2.next == null)
            {
                p1 = p1.next;
            }
            else
            {   //even number of elements, do nothing

            }
            //compare from mid to head/tail
            while (p3 != null)
            {
                if (p1.value != p3.value)
                {
                    return false;
                }
                p1 = p1.next;
                p3 = p3.next;
            }
            return true;

        }


        static bool isCryptSolution(string[] crypt, char[][] solution)
        {
            Dictionary<char, char> diccio = new Dictionary<char, char>();
            for (int i = 0; i < solution.Length; i++)
            {
                diccio[solution[i][0]] = solution[i][1];
            }

            List<string> nums = new List<string>();

            for (int i = 0; i < crypt.Length; i++)
            {
                string c = crypt[i];
                string word = "";
                for (int j = 0; j < c.Length; j++)
                {
                    word += diccio[c[j]];
                }
                if (word.Length > 1 && word[0] == '0') return false;
                nums.Add(word);
            }

            Console.WriteLine(nums[0] + " " + nums[1] + " " + nums[2]);

            if (long.Parse(nums[0]) + long.Parse(nums[1]) == long.Parse(nums[2]))
            {
                return true;
            }

            return false;
        }

        static string[] innerRanges(int[] nums, int l, int r)
        {
            nums = nums.Distinct().ToArray();

            List<string> ans = new List<string>();

            if (nums.Length == 0)
            {
                if (l < r)
                {
                    ans.Add(l.ToString() + "->" + r.ToString());
                }
                else if (l == r)
                {
                    ans.Add(l.ToString());
                }
                return ans.ToArray();
            }

            if (l == r && !nums.Contains(l))
            {
                ans.Add(l + "");
                return ans.ToArray();
            }
            else if (l == r && nums.Contains(l))
            {
                return ans.ToArray();
            }



            if (l < ((long)nums[0] - 1))
            {
                ans.Add((l).ToString() + "->" + (nums[0] - 1));
            }
            else if (l == ((long)nums[0] - 1))
            {
                ans.Add((l) + "");
            }

            int i = 0;
            for (i = 0; i < nums.Length; i++)
            {
                while (i + 1 < nums.Length && ((long)nums[i] + 1) == nums[i + 1])
                {
                    i++;
                }

                if (i + 1 < nums.Length && (long)nums[i] + 1 == (long)nums[i + 1] - 1)
                {
                    ans.Add((nums[i] + 1).ToString());
                }
                else if (i + 1 < nums.Length)
                {
                    ans.Add(((long)nums[i] + 1).ToString() + "->" + ((long)nums[i + 1] - 1).ToString());
                }
            }

            //long u = ((long)nums[nums.Length-1] + 1);
            if (((long)nums[nums.Length - 1] + 1) < r)
            {
                ans.Add(((long)nums[nums.Length - 1] + 1).ToString() + "->" + r.ToString());
            }
            else if (((long)nums[nums.Length - 1] + 1) == r)
            {
                ans.Add(r + "");
            }

            //if (r == nums[nums.Length - 1]+1)
            //{
            //    ans.Add(r.ToString());
            //}

            return ans.ToArray();
        }

        static int houseRobber(int[] nums)
        {
            int a = 0, b = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                    a = Math.Max(a + nums[i], b);

                else
                    b = Math.Max(a, b + nums[i]);
            }

            return Math.Max(a, b);

        }


        static int higherVersion2(string ver1, string ver2)
        {
            int[] a = Array.ConvertAll(ver1.Split('.'), e => int.Parse(e));
            int[] b = Array.ConvertAll(ver2.Split('.'), e => int.Parse(e));

            if (a.Length > b.Length)
            {
                return 1;
            }
            else if (a.Length < b.Length)
            {
                return -1;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    return 1;
                }
                else if (b[i] > a[i])
                {
                    return -1;
                }
            }
            return 0;
        }



        static bool happyNumber(int n)
        {
            HashSet<int> sumas = new HashSet<int>();
            while (n != 1)
            {
                if (sumas.Contains(n)) return false;
                sumas.Add(n);

                int copia = n;
                int sum = 0;
                while (copia > 0)
                {
                    sum += (copia % 10) * (copia % 10);
                    copia /= 10;
                }

                n = sum;
            }
            return true;
        }


        static int groupsOfAnagrams(string[] words)
        {
            HashSet<string> hs = new HashSet<string>();

            foreach (string w in words)
            {
                char[] sort = w.ToCharArray();
                Array.Sort(sort);
                hs.Add(new string(sort));
            }
            return hs.Count;
        }

        static string[][] groupingDishes(string[][] dishes)
        {
            Dictionary<string, List<string>> diccio = new Dictionary<string, List<string>>();

            for (int i = 0; i < dishes.Length; i++)
            {
                for (int j = 1; j < dishes[i].Length; j++)
                {
                    if (diccio.ContainsKey(dishes[i][j]))
                    {
                        diccio[dishes[i][j]].Add(dishes[i][0]);
                    }
                    else
                    {
                        diccio[dishes[i][j]] = new List<string>();
                        diccio[dishes[i][j]].Add(dishes[i][0]);
                    }
                }
            }


            int len = 0;
            foreach (KeyValuePair<string, List<string>> kvp in diccio)
            {
                if (kvp.Value.Count >= 2)
                {
                    len++;
                }
            }

            string[][] ans = new string[len][];
            int fila = 0;
            foreach (KeyValuePair<string, List<string>> kvp in diccio.OrderBy(i => i.Key, StringComparer.Ordinal))
            {
                if (kvp.Value.Count >= 2)
                {
                    // Console.WriteLine(kvp.Key);

                    string[] aux_arr = kvp.Value.ToArray();

                    //List<Order> SortedList = objListOrder.OrderBy(o => o.OrderDate).ToList();
                    Array.Sort(aux_arr, StringComparer.Ordinal);
                    List<string> aux = aux_arr.ToList();

                    ans[fila] = new string[aux.Count + 1];
                    ans[fila][0] = kvp.Key;
                    int col = 1;
                    foreach (string elem in aux)
                    {
                        //Console.Write(elem + " ");
                        ans[fila][col] = elem;
                        col++;
                    }
                    fila++;
                    // Console.WriteLine();
                }
            }

            return ans;
        }




        //----------------------------
        static bool isValid(string s)
        {
            string abierto = "(";
            string cerrado = ")";
            Stack<char> pila = new Stack<char>();
            bool balanceado = true;

            for (int i = 0; i < s.Length && balanceado; i++)
            {
                char actual = s[i];

                if (abierto.IndexOf(actual) > -1)
                {
                    pila.Push(actual);
                }
                else if (cerrado.IndexOf(actual) > -1)
                {
                    balanceado = (!(pila.Count == 0))
                    && cerrado.IndexOf(actual) == abierto.IndexOf(pila.Pop());
                }
            }
            return balanceado && pila.Count == 0;
        }



        public static bool nextPermutation(char[] array)
        {
            // Find non-increasing suffix
            int i = array.Length - 1;
            while (i > 0 && array[i - 1] >= array[i])
                i--;
            if (i <= 0)
                return false;

            // Find successor to pivot
            int j = array.Length - 1;
            while (array[j] <= array[i - 1])
                j--;
            char temp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = temp;

            // Reverse suffix
            j = array.Length - 1;


            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
            return true;
        }


        static string[] generateParentheses(int n)
        {
            List<string> permut = new List<string>();
            string s = "";

            for (int i = 0; i < n; i++)
            {
                s += "(";
            }
            for (int i = 0; i < n; i++)
            {
                s += ")";
            }

            char[] permutar = s.ToCharArray();
            //print(permutar);
            permut.Add(new string(permutar));
            //Console.WriteLine();
            while (nextPermutation(permutar))
            {
                if (isValid(new string(permutar)))
                {
                    //print(permutar);
                    permut.Add(new string(permutar));
                    //Console.WriteLine();
                }
            }

            return permut.ToArray();
        }



        //---------------------------------------

        static char firstNotRepeatingCharacter(string s)
        {
            Dictionary<char, int> dic_frec = new Dictionary<char, int>();
            Dictionary<char, int> indices = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dic_frec.ContainsKey(s[i]))
                {
                    dic_frec[s[i]]++;
                }
                else
                {
                    dic_frec[s[i]] = 1;
                }
                if (!indices.ContainsKey(s[i]))
                {
                    indices[s[i]] = i;
                }
            }

            List<char> frec_1 = new List<char>();
            foreach (KeyValuePair<char, int> kvp in dic_frec)
            {
                if (kvp.Value == 1)
                {
                    frec_1.Add(kvp.Key);
                }
            }

            int min_indice = int.MaxValue;
            char min_char = '_';

            foreach (char ch in frec_1)
            {
                if (indices[ch] < min_indice)
                {
                    min_indice = indices[ch];
                    min_char = ch;
                }
            }


            return min_char;
        }


        static int firstDuplicate(int[] a)
        {
            Dictionary<int, int> frec = new Dictionary<int, int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (frec.ContainsKey(a[i]))
                {
                    if (frec[a[i]] == -1)
                    {
                        return a[i];
                    }
                }
                else
                {
                    frec[a[i]] = -1;
                }
            }

            return -1;

        }


        static int[] findTheNumbers(int[] a)
        {
            Array.Sort(a);

            List<int> ans = new List<int>();
            for (int i = 0; i < a.Length; )
            {
                int actual = a[i];
                int cont = 0;
                while (i < a.Length && actual == a[i])
                {
                    cont++;
                    i++;
                }
                if (cont == 1)
                {
                    ans.Add(a[i - 1]);
                }
            }
            ans.Sort();
            return ans.ToArray();
        }


        static int[] findSubarrayBySum(int s, int[] arr)
        {
            int izq = 0, der = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                izq = i;
                int sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    if (sum == s)
                    {
                        der = j;
                        return new int[] { izq + 1, der + 1 };
                    }
                }
            }
            return new int[] { -1 };
        }


        static int[] findLongestSubarrayBySum(int s, int[] arr)
        {
            bool flag;
            if (s == 0)
            {
                int j = arr.Length - 1;
                int ini = 0;
                int fin = 0;
                flag = false;
                int max_consec = 0;
                int cont = 0;
                while (j >= 0)
                {
                    while (arr[j] == 0 && j >= 0)
                    {
                        if (!flag)
                        {
                            ini = j;
                        }

                        flag = true;
                        j--;
                        cont++;
                    }
                    if (j - ini + 1 >= max_consec)
                    {
                        max_consec = j - ini + 1;
                        fin = j;
                    }
                    j--;
                }
                return new int[] { ini + 1, fin };
            }
            Dictionary<long, long> diccio = new Dictionary<long, long>();

            long total = 0;
            long sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                diccio[sum] = i;
                total += arr[i];
            }

            if (arr.Length == 1 && total == s)
            {
                return new int[] { 1, 1 };
            }

            flag = false;
            int izq = arr.Length - 1;
            int min_izq = int.MaxValue;
            int der = arr.Length - 1;
            int len_longest = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                //if (diccio[i] == s)
                //{
                //    return new int[] { 1, i + 1 };
                //}
                if (diccio.ContainsKey(s))
                {
                    //Console.WriteLine(diccio[s]);
                    //if ((i + 1) - (diccio[total - s] + 2) + 1 > len_longest)
                    if (der - izq + 1 > len_longest)
                    {
                        izq = 1;
                        der = (int)(diccio[s] + 1);
                        len_longest = der - izq + 1;
                    }
                }
                if (diccio.ContainsKey(total - s))
                {

                    flag = true;

                    if (der - izq + 1 > len_longest)
                    {

                        izq = (int)(diccio[total - s] + 2);
                        der = i + 1;
                        // Console.WriteLine(izq + " " + der);
                        len_longest = der - izq + 1;
                    }
                    if ((i + 1) - (diccio[total - s] + 2) + 1 == len_longest)
                    {
                        izq = (int)(diccio[total - s] + 2);
                        der = i + 1;
                        len_longest = der - izq + 1;
                    }
                    else if ((i + 1) - (diccio[total - s] + 2) + 1 > len_longest)
                    {
                        izq = (int)(diccio[total - s] + 2);
                        der = i + 1;
                        len_longest = der - izq + 1;
                    }


                }

                total -= arr[i];
            }
            if (flag)
            {
                return new int[] { izq, der };
            }

            return new int[] { -1 };

        }



        static int excelSheetColumnNumber(string s)
        {
            int r = 0;
            for (int i = 0; i < s.Length; i++)
            {
                r = r * 26 + s[i] - 64;
            }
            return r;
        }

        static int equilibriumPoint(int[] arr)
        {
            int der = arr.Sum();
            int izq = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                izq += arr[i];
                if (izq == der)
                {
                    return i + 1;
                }
                der -= arr[i];
            }
            return -1;
        }

        //------------------------------------------------------------------
        // Definition for binary tree:
        class Tree<T>
        {
            public T value { get; set; }
            public Tree<T> left { get; set; }
            public Tree<T> right { get; set; }
        }

        static List<string> paths = new List<string>();
        static void PrintAllPossiblePath(Tree<int> node, List<Tree<int>> nodelist)
        {
            if (node != null)
            {
                nodelist.Add(node);
                if (node.left != null)
                {
                    PrintAllPossiblePath(node.left, nodelist);
                }
                if (node.right != null)
                {
                    PrintAllPossiblePath(node.right, nodelist);
                }
                else if (node.left == null && node.right == null)
                {
                    string p = "";
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        //Console.Write(nodelist[i].value);
                        p += nodelist[i].value;
                    }
                    paths.Add(p);
                    //System.out.println();
                    //Console.WriteLine();
                }
                nodelist.Remove(node);
            }
        }

        static long digitTreeSum(Tree<int> t)
        {
            PrintAllPossiblePath(t, new List<Tree<int>>());

            long sum = 0;
            foreach (string elem in paths)
            {
                //Console.WriteLine(elem);
                sum += long.Parse(elem);
            }
            return sum;
        }



        //----------------------------------------
        static int[] arrayNiveles(string s)
        {
            int[] niveles = new int[s.Length];

            int nivel = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                {
                    nivel++;
                    niveles[i] = nivel;
                }
                else if (s[i] == ']')
                {
                    niveles[i] = nivel;
                    nivel--;
                }
            }

            return niveles;

        }



        static string decodeString(string s)
        {

            if (s == String.Empty) return string.Empty;

            char[] c = s.ToCharArray();
            int[] niveles = arrayNiveles(s);
            int i;
            int max = niveles.Max();

            while (max >= 1)
            {

                i = Array.IndexOf(niveles, max);
                while (i < s.Length)
                {
                    int inicio = i;
                    while (i < s.Length)
                    {
                        if (i < niveles.Length && niveles[i] == max && s[i] == '[')
                        {
                            inicio = i;
                            break;
                        }
                        i++;
                    }
                    int fin = i + 1;
                    while (i < s.Length)
                    {
                        if (niveles[i] == max && s[i] == ']')
                        {
                            fin = i;
                            break;
                        }
                        i++;
                    }

                    if (i < niveles.Length && i >= 0)
                    {

                        //int k = int.Parse(s[inicio - 1].ToString());
                        int k = 0;
                        int j = inicio - 1;
                        string k_string = "";
                        while (j >= 0 && char.IsNumber(s[j]))
                        {
                            k_string += s[j];
                            j--;
                        }
                        char[] k_ch = k_string.ToCharArray();
                        Array.Reverse(k_ch);
                        k = int.Parse(new string(k_ch));

                        string subs = s.Substring(inicio + 1, fin - (inicio + 1));
                        //Console.WriteLine(subs);

                        string concat = "";
                        for (j = 0; j < k; j++)
                        {
                            concat += subs;
                        }

                        s = s.Remove(inicio - 1, (fin) - (inicio) + 1);
                        s = s.Remove(inicio - k_string.Length, k_string.Length);
                        s = s.Insert(inicio - k_string.Length, "" + concat + "");
                        //Console.WriteLine(s);
                    }

                    niveles = arrayNiveles(s);
                    max = niveles.Max();

                    i++;
                }
            }

            return s;
        }




        //-----------------------------------------
        static int countVowelConsonant(string s)
        {
            string vocales = "aeiou";
            int sum = 0;
            foreach (char ch in s)
            {
                if (vocales.Contains(ch))
                    sum++;
                else
                    sum += 2;

            }
            return sum;

        }



        //---------------------------------
        class Program
        {



            public class Celda
            {
                public int Fila;
                public int Columna;
                public int ColorCelda;


                public Celda(int fila, int columna)
                {
                    this.Fila = fila;
                    this.Columna = columna;
                }

                public override bool Equals(object obj)
                {
                    Celda c = (Celda)obj;

                    if (this.Fila == c.Fila && this.Columna == c.Columna)
                    {
                        return true;
                    }
                    return false;
                }

                public override int GetHashCode()
                {
                    return base.GetHashCode();
                }

            }




            public static List<Celda> FloodFill(Celda[,] matriz, int filas, int columnas, Celda nodo, int viejo, int reemplazo)
            {

                Stack<Celda> pila = new Stack<Celda>();
                if (matriz[nodo.Fila, nodo.Columna].ColorCelda != viejo)
                    return new List<Celda>();

                pila.Push(nodo);

                List<Celda> grupoSeleccionado = new List<Celda>();
                grupoSeleccionado.Add(nodo);


                while (pila.Count > 0)
                {
                    Celda c = pila.Pop();

                    matriz[c.Fila, c.Columna].ColorCelda = reemplazo;
                    if (!grupoSeleccionado.Contains(matriz[c.Fila, c.Columna]))
                    {
                        grupoSeleccionado.Add(matriz[c.Fila, c.Columna]);
                    }

                    if (c.Fila > 0)
                    {
                        if (matriz[c.Fila - 1, c.Columna].ColorCelda == viejo)
                        {
                            pila.Push(new Celda(c.Fila - 1, c.Columna));
                        }
                    }
                    if (c.Fila < filas - 1)
                    {
                        if (matriz[c.Fila + 1, c.Columna].ColorCelda == viejo)
                            pila.Push(new Celda(c.Fila + 1, c.Columna));
                    }
                    if (c.Columna > 0)
                    {
                        if (matriz[c.Fila, c.Columna - 1].ColorCelda == viejo)
                            pila.Push(new Celda(c.Fila, c.Columna - 1));
                    }
                    if (c.Columna < columnas - 1)
                    {
                        if (matriz[c.Fila, c.Columna + 1].ColorCelda == viejo)
                            pila.Push(new Celda(c.Fila, c.Columna + 1));
                    }

                }

                return grupoSeleccionado;

            }

            static int countClouds(char[][] skyMap)
            {
                if (skyMap.Length == 0) return 0;

                int _filas = skyMap.Length;
                int _columnas = skyMap[0].Length;

                Celda[,] matriz = new Celda[_filas, _columnas];


                for (int i = 0; i < _filas; i++)
                {
                    for (int j = 0; j < _columnas; j++)
                    {
                        matriz[i, j] = new Celda(i, j);
                        matriz[i, j].ColorCelda = int.Parse(skyMap[i][j].ToString());
                    }
                }



                int max = 0;
                int cont = 0;

                for (int i = 0; i < _filas; i++)
                {
                    for (int j = 0; j < _columnas; j++)
                    {
                        if (matriz[i, j].ColorCelda == 1)
                        {
                            List<Celda> sel = FloodFill(matriz, _filas, _columnas, new Celda(i, j), 1, 2);
                            // max = Math.Max(sel.Count, max);
                            cont++;
                        }

                    }
                }

                //Console.WriteLine(max);
                return cont;

            }




            static void Main(string[] args)
            {


                Console.ReadLine();

            }





        }






        //---------------------------
        static bool containsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j - i <= k && Math.Abs((long)nums[i] - (long)nums[j]) <= t)
                    {
                        return true;
                    }
                    if (j - i > k) break;
                }
            }
            return false;
        }

        static bool containsDuplicates(int[] a)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < a.Length; i++)
                if (!hs.Add(a[i])) return true;
            return false;
        }


        static string addBinaryStrings(string a, string b)
        {
            if (a.Length < b.Length)
            {
                a = new string('0', b.Length - a.Length) + a;
            }
            else if (b.Length < a.Length)
            {
                b = new string('0', a.Length - b.Length) + b;
            }
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            string res = "";

            int acarreo = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                int dig = int.Parse(a[i].ToString()) + int.Parse(b[i].ToString()) + acarreo;

                if (dig == 0)
                {
                    res = '0' + res;
                    acarreo = 0;
                }
                else if (dig == 1)
                {
                    res = '1' + res;
                    acarreo = 0;
                }
                else if (dig == 2)
                {
                    res = '0' + res;
                    acarreo = 1;
                }
                else if (dig == 3)
                {
                    res = '1' + res;
                    acarreo = 1;
                }
            }
            if (acarreo > 0)
            {
                res = acarreo + res;
            }

            return res;
        }


        static string amendTheSentence(string s)
        {
            int i = 1;
            string res = s[0].ToString();

            while (i < s.Length)
            {
                while (i < s.Length && char.IsLower(s[i]))
                {
                    res += s[i];
                    i++;
                }
                if (i >= s.Length) break;
                res += " " + s[i];
                i++;
            }
            return res.ToLower();
        }


        static bool areFollowingPatterns(string[] strings, string[] patterns)
        {
            Dictionary<string, string> diccio = new Dictionary<string, string>();

            for (int i = 0; i < strings.Length; i++)
            {
                if (diccio.ContainsKey(strings[i]))
                {
                    if (diccio[strings[i]] != patterns[i])
                    {
                        return false;
                    }

                    //diccio[strings[i]] = patterns[i];
                }
                else
                {
                    if (diccio.ContainsValue(patterns[i]))
                    {
                        return false;
                    }
                    //diccio[strings[i]] = patterns[i];
                }
                diccio[strings[i]] = patterns[i];

            }
            return true;

        }
        static int arrayMaxConsecutiveSum2(int[] inputArray)
        {
            int max_so_far = inputArray[0];
            int curr_max = inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                curr_max = Math.Max(inputArray[i], curr_max + inputArray[i]);
                max_so_far = Math.Max(max_so_far, curr_max);
            }
            return max_so_far;
        }

        static string[] chessQueen(string q)
        {
            string[,] tab = new string[8, 8];

            int fila_target = "87654321".IndexOf(q[1]);
            int col_target = "abcdefgh".IndexOf(q[0]);

            List<string> ans = new List<string>();

            int i = 0, j = 0;
            for (int num = 8; num >= 1; num--)
            {
                j = 0;
                for (char ch = 'a'; ch <= 'h'; ch++)
                {
                    tab[i, j] = ch.ToString() + (num + "");

                    if (i == fila_target || j == col_target || Math.Abs(fila_target - i) == Math.Abs(col_target - j)) tab[i, j] = "";

                    if (tab[i, j].Length > 0) ans.Add(tab[i, j]);
                    j++;
                }
                i++;
            }

            ans.Sort();

            return ans.ToArray();
        }

        static string[] chessQueen(string q)
        {
            string[,] tab = new string[8, 8];

            int fila_target = 0, col_target = 0;

            int i = 0, j = 0;
            for (int num = 8; num >= 1; num--)
            {
                j = 0;
                for (char ch = 'a'; ch <= 'h'; ch++)
                {
                    tab[i, j] = ch.ToString() + num.ToString();
                    if (tab[i, j] == q)
                    {
                        fila_target = i;
                        col_target = j;
                    }

                    j++;
                }
                i++;
            }

            //borro la fila y la columna de target

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (i == fila_target || j == col_target)
                    {
                        tab[i, j] = "";
                    }
                    if (Math.Abs(fila_target - i) == Math.Abs(col_target - j)) //PARA SABER SI ESTA EN LA MISMA COLUMNA
                    {
                        tab[i, j] = "";
                    }
                }
            }


            List<string> ans = new List<string>();

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {

                    if (tab[i, j].Length > 0)
                    {
                        ans.Add(tab[i, j]);
                    }
                }

            }
            ans.Sort();

            return ans.ToArray();
        }

        int climbStairs(int n)
        {
            n++;
            double phi = (1 + Math.Pow(5, 0.5)) / 2;
            return (int)Math.Round(Math.Pow(phi, n) / Math.Pow(5, 0.5));
        }

        static string columnTitle(int number)
        {

            string concat = "";
            while (number > 0)
            {
                int dig = number % 26;
                //Console.WriteLine(dig);
                if (dig == 0)
                {
                    number--;
                    concat = "Z" + concat; // ans.Insert(0, "Z");
                }
                else
                {
                    concat = ((char)(dig + 'A' - 1)).ToString() + concat;
                }

                number /= 26;
            }
            return concat;
        }

        static int commonCharacterCount2(string[] s)
        {
            int[] c = new int[26];

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                int min_cont = int.MaxValue;
                for (int i = 0; i < s.Length; i++)
                {
                    int cont = s[i].Count(e => e == ch);
                    min_cont = Math.Min(min_cont, cont);
                }
                c[ch - 'a'] = min_cont;
            }
            return c.Sum();
        }


        static string[] composeRanges(int[] nums)
        {
            List<string> res = new List<string>();
            int i = 0;

            while (i < nums.Length)
            {
                int izq = nums[i];
                while (i + 1 < nums.Length && nums[i] + 1 == nums[i + 1])
                {
                    i++;
                }
                int der = nums[i];
                if (izq == der)
                {
                    res.Add(izq + "");
                }
                else
                {
                    res.Add(izq + "->" + der);
                }

                i++;
            }
            return res.ToArray();
        }


        static bool containsCloseNums(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length && j < i + k; j++)
                {
                    if (nums[i] == nums[j]) return true;
                }
            }
            return false;
        }




        static void Main(string[] args)
        {
        }
    }
}
