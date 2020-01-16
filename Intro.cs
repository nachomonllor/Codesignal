using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static int absoluteValuesSumMinimization(int[] a)
        {
            int ans = 0;
            int min_sum = int.MaxValue;
            for (int i = 0; i < a.Length; i++)
            {
                int sum = 0;
                int x = a[i];
                for (int j = 0; j < a.Length; j++)
                {
                    sum += Math.Abs(a[j] - x);
                }
                if (sum < min_sum)
                {
                    min_sum = sum;
                    ans = a[i];
                }
            }
            return ans;
        }

        static int absoluteValuesSumMinimization(int[] a)
        {
            int ans = 0;
            int min_sum = int.MaxValue;
            for (int i = 0; i < a.Length; i++)
            {
                int sum = 0;
                int x = a[i];
                for (int j = 0; j < a.Length; j++)
                {
                    sum += Math.Abs(a[j] - x);
                }
                if (sum < min_sum)
                {
                    min_sum = sum;
                    ans = a[i];
                }
            }
            return ans;
        }



        static string[] addBorder(string[] picture)
        {

            int f = picture.Length, c = picture[0].Length;

            char[,] asteriscos = new char[f + 2, c + 2];

            for (int i = 0; i < asteriscos.GetLength(0); i++)
            {
                for (int j = 0; j < asteriscos.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == asteriscos.GetLength(0) - 1 || j == asteriscos.GetLength(1) - 1)
                    {
                        asteriscos[i, j] = '*';
                    }
                    else
                    {
                        asteriscos[i, j] = picture[i - 1][j - 1];
                    }
                }

            }


            string[] res = new string[f + 2];

            int index = 0;
            for (int i = 0; i < asteriscos.GetLength(0); i++)
            {
                for (int j = 0; j < asteriscos.GetLength(1); j++)
                {
                    res[index] += asteriscos[i, j];
                }
                index++;
            }
            return res;
        }


        static string[] addBorder(string[] picture)
        {
            string[] ans = new string[picture.Length + 2];
            int j = 0;
            for (int i = 0; i < ans.Length; i++)
            {
                if (i == 0 || i == ans.Length - 1)
                {
                    ans[i] = new string('*', picture[0].Length + 2);
                }
                else
                {
                    ans[i] = '*' + picture[j++] + '*';
                }
            }

            return ans;
        }
        static int adjacentElementsProduct(int[] inputArray)
        {
            int max = int.MinValue;
            for (int i = 0; i + 1 < inputArray.Length; i++)
            {
                max = Math.Max(inputArray[i] * inputArray[i + 1], max);
            }
            return max;
        }
        string[] allLongestStrings(string[] inputArray)
        {
            List<string> ans = new List<string>();
            int max_len = 0;
            foreach (string elem in inputArray)
            {
                if (elem.Length == max_len)
                {
                    ans.Add(elem);
                }
                else if (elem.Length > max_len)
                {
                    max_len = elem.Length;
                    ans = new List<string>();
                    ans.Add(elem);
                }
            }
            return ans.ToArray();
        }


        static bool almostIncreasingSequence(int[] sequence)
        {
            int repetidos = 0;
            Dictionary<int, int> diccio = new Dictionary<int, int>();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (diccio.ContainsKey(sequence[i]))
                {
                    repetidos++;
                    continue;
                }
                diccio[sequence[i]] = i;
            }
            if (repetidos > 1) return false;

            int[] keys = diccio.Keys.ToArray();
            int[] values = diccio.Values.ToArray();

            Array.Sort(keys, values);

            bool[] marcas = new bool[sequence.Length];

            int cont = 0;
            for (int i = 0; i < values.Length; i++)
            {

                int a = i - 1;
                while (a >= 0 && marcas[a])
                {
                    a--;
                }
                if (a >= 0 && values[a] > values[i])
                {
                    marcas[i] = true;
                    cont++;
                }
            }

            if (repetidos > 0 && cont > 0) return false;

            return cont <= 1;
        }

        static string alphabeticShift(string inputString)
        {
            char[] res = inputString.ToCharArray();

            for (int i = 0; i < res.Length; i++)
            {
                if (res[i] == 'z')
                {
                    res[i] = 'a';
                }
                else
                {
                    res[i] = (char)(res[i] + 1);
                }
            }
            return new string(res);
        }


        static int[] alternatingSums(int[] a)
        {
            int x = 0, y = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0) x += a[i];
                else y += a[i];
            }
            return new int[] { x, y };
        }


        static bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            int[] a = { yourLeft, yourRight };
            int[] b = { friendsLeft, friendsRight };

            Array.Sort(a);
            Array.Sort(b);

            for (int i = 0; i < 2; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }

        static bool areSimilar(int[] A, int[] B)
        {
            int cont = 0;

            List<int> x = new List<int>();
            List<int> y = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i])
                {
                    x.Add(A[i]);
                    y.Add(B[i]);
                }
            }
            if (x.Count > 2 || y.Count > 2) return false;

            x.Sort();
            y.Sort();

            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }

        static int arrayChange(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i + 1 < inputArray.Length; i++)
            {
                if (inputArray[i + 1] <= inputArray[i])
                {
                    int dif = inputArray[i] - inputArray[i + 1] + 1;
                    inputArray[i + 1] += dif;
                    sum += dif;
                }
            }

            return sum;
        }

        static int arrayMaxConsecutiveSum(int[] inputArray, int k)
        {

            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += inputArray[i];
            }
            int max = sum;

            for (int i = 0; i + k < inputArray.Length; i++)
            {
                sum -= inputArray[i];
                sum += inputArray[i + k];
                max = Math.Max(max, sum);
            }
            return max;
        }

        static int arrayMaximalAdjacentDifference(int[] inputArray)
        {
            int max = 0;
            for (int i = 0; i + 1 < inputArray.Length; i++)
            {
                max = Math.Max(Math.Abs(inputArray[i] - inputArray[i + 1]), max);
            }
            return max;
        }
        static int[] arrayReplace(int[] inputArray, int elemToReplace, int substitutionElem)
        {

            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = (inputArray[i] == elemToReplace) ? substitutionElem : inputArray[i];
            }
            return inputArray;
        }
        static int avoidObstacles(int[] inputArray)
        {
            Array.Sort(inputArray);
            int min_salto = 0;

            for (int salto = 1; salto <= inputArray[inputArray.Length - 1] + 1; salto++)
            {
                int i = 0;
                for (i = 0; i <= inputArray[inputArray.Length - 1] + 1; i += salto)
                {
                    if (inputArray.Contains(i))
                    {
                        break;
                    }

                }
                if (i >= inputArray[inputArray.Length - 1] + 1)
                {
                    min_salto = salto;
                    break;
                }
            }
            return min_salto;
        }

        static bool bishopAndPawn(string bishop, string pawn)
        {
            string letras = "abcdefgh";
            string nums = "87654321";

            return Math.Abs(letras.IndexOf(bishop[0]) - letras.IndexOf(pawn[0])) ==
                Math.Abs(nums.IndexOf(bishop[1]) - nums.IndexOf(pawn[1]));
        }
        static int[][] boxBlur(int[][] image)
        {
            /* instancio cada fila de res e inicializo cada uno 
             * de sus elementos a cero*/
            int[][] res = new int[image.Length - 2][];
            for (int i = 0; i < image.Length - 2; i++)
            {
                res[i] = new int[image[i].Length - 2];
                for (int j = 0; j < image[i].Length - 2; j++)
                {
                    res[i][j] = 0;
                }
            }

            for (int i = 1; i < image.Length - 1; i++)
            {
                for (int j = 1; j < image[i].Length - 1; j++)
                {
                    /*hago la sumatoria de los 9 casilleros
                     con centro i,j y divido esa sumatoria por 9*/
                    int pixel = (image[i - 1][j - 1] + image[i - 1][j] + image[i - 1][j + 1]
                              + image[i][j - 1] + image[i][j] + image[i][j + 1]
                              + image[i + 1][j - 1] + image[i + 1][j] + image[i + 1][j + 1]) / 9;

                    res[i - 1][j - 1] = pixel;

                }
            }

            return res;
        }

        static bool esPalin(string s)
        {
            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                if (s[i] != s[j]) return false;
            }
            return true;

        }

        static string buildPalindrome(string st)
        {
            int ind = 0;
            for (int i = 0; i < st.Length; i++)
            {
                string subs = st.Substring(i, st.Length - i);
                //Console.WriteLine(subs);
                ind = i;
                if (esPalin(subs))
                {

                    break;
                }
            }

            string resto = st.Substring(0, ind);
            char[] rr = resto.ToCharArray();
            Array.Reverse(rr);

            //Console.WriteLine(resto);

            return resto + st.Substring(ind) + new string(rr);
        }


        static int centuryFromYear(int year)
        {
            int century = 1;
            for (int i = 100; i <= 2100; i += 100)
            {
                if (year >= i - 99 && year <= i)
                {
                    break;
                }
                century++;
            }
            return century;
        }

        static bool checkPalindrome(string inputString)
        {
            int i = 0, j = inputString.Length - 1;

            while (i < j)
            {
                if (inputString[i] != inputString[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        bool chessBoardCellColor(string cell1, string cell2)
        {
            string letras = "ABCDEFGH";
            string nums = "12345678";

            string ca = "";
            if (((letras.IndexOf(cell1[0]) + 1) % 2 == 0 && (nums.IndexOf(cell1[1]) + 1) % 2 == 0) ||
               ((letras.IndexOf(cell1[0]) + 1) % 2 != 0 && (nums.IndexOf(cell1[1]) + 1) % 2 != 0))
            {
                ca = "negro";
            }
            else
            {
                ca = "blanco";
            }



            string cb = "";
            if (((letras.IndexOf(cell2[0]) + 1) % 2 == 0 && (nums.IndexOf(cell2[1]) + 1) % 2 == 0) ||
               ((letras.IndexOf(cell2[0]) + 1) % 2 != 0 && (nums.IndexOf(cell2[1]) + 1) % 2 != 0))
            {
                cb = "negro";
            }
            else
            {
                cb = "blanco";
            }

            return ca == cb;
        }

        static int chessKnight(string cell)
        {
            int row = cell[1] - '1' + 1,
                column = cell[0] - 'a' + 1;

            int[][] steps =
            {
                new int[]{-2,-1},
                new int[] {-1,-2},
                new int[]{1,-2},
                new int[]{2,-1},
                new int[]{2,1},
                new int[]{1,2},
                new int[]{-1,2},
                new int[]{-2,1}
            };

            int ans = 0;
            for (int i = 0; i < 8; i++)
            {
                int tmpRow = row + steps[i][0];
                int tmpColumn = column + steps[i][1];
                if (tmpRow >= 1 && tmpRow <= 8 &&
                    tmpColumn >= 1 && tmpColumn <= 8)
                {
                    ans++;
                }
            }
            return ans;
        }

        static int circleOfNumbers(int n, int firstNumber)
        {
            int mitad = n / 2;

            if (firstNumber < mitad)
            {
                return firstNumber + mitad;
            }
            else
            {
                return firstNumber - mitad;
            }

        }


        static int commonCharacterCount(string s1, string s2)
        {
            Dictionary<char, int> a = new Dictionary<char, int>();
            Dictionary<char, int> b = new Dictionary<char, int>();
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                a[ch] = 0;
                b[ch] = 0;
            }

            foreach (char ch in s1)
            {
                a[ch]++;
            }
            foreach (char ch in s2)
            {
                b[ch]++;
            }
            int sum = 0;
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                sum += Math.Min(a[ch], b[ch]);
            }
            return sum;

        }


        static int deleteDigit(int n)
        {
            string s = n + "";
            int max = 0;
            for (int borra = 0; borra < s.Length; borra++)
            {
                string copia = s;
                copia = copia.Remove(borra, 1);

                max = Math.Max(max, int.Parse(copia));
            }
            return max;
        }

        static int depositProfit(int deposit, int rate, int threshold)
        {
            float d = deposit;
            int years = 0;
            while (d < threshold)
            {
                d *= (100 + rate) / 100f;
                years++;
            }
            return years;
        }


        static int differentSquares(int[][] matrix)
        {
            int f = matrix.Length, c = matrix[0].Length;
            HashSet<string> hs = new HashSet<string>();

            for (int i = 0; i < f - 1; i++)
            {
                for (int j = 0; j < c - 1; j++)
                {
                    string concat = "";
                    concat += matrix[i][j].ToString() + matrix[i][j + 1].ToString();
                    concat += matrix[i + 1][j].ToString() + matrix[i + 1][j + 1].ToString();

                    hs.Add(concat);
                }
            }
            return hs.Count;
        }


        static int differentSymbolsNaive(string s)
        {
            HashSet<char> hs = new HashSet<char>();
            foreach (char ch in s) hs.Add(ch);
            return hs.Count;
        }

        static int digitDegree(int n)
        {
            string s = n + "";

            int cont = 0;
            while (s.Length > 1)
            {
                int sum = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    sum += int.Parse(s[i].ToString());
                }

                s = sum.ToString();
                cont++;
            }
            return cont;
        }

        int digitsProduct(int product)
        {
            for (int i = 1; i < product * product + 11; i++)
            {
                int p = 1;
                int t = i;
                while (t != 0)
                {
                    p *= t % 10;
                    t /= 10;
                }
                if (p == product)
                {
                    return i;
                }
            }
            return -1;
        }


        static int electionsWinners(int[] votes, int k)
        {
            int ma = votes.Max();
            int cnt = 0;
            for (int i = 0; i < votes.Length; i++)
                if (votes[i] + k > ma)
                    cnt++;
            if (cnt == 0)
            {
                for (int i = 0; i < votes.Length; i++)
                    if (votes[i] == ma)
                        cnt++;
                if (cnt > 1)
                    cnt = 0;
            }
            return cnt;
        }

        static bool evenDigitsOnly(int n)
        {
            while (n > 0)
            {
                if ((n % 10) % 2 != 0) return false;
                n /= 10;
            }
            return true;

        }


        static int[] extractEachKth(int[] inputArray, int k)
        {

            bool[] borrar = new bool[inputArray.Length];

            for (int i = 1; k * i - 1 < inputArray.Length; i++)
            {
                borrar[k * i - 1] = true;
            }

            List<int> ans = new List<int>();
            for (int i = 0; i < borrar.Length; i++)
            {
                if (!borrar[i]) ans.Add(inputArray[i]);
            }

            return ans.ToArray();
        }


        static string findEmailDomain(string address)
        {
            int indiceArroba = address.LastIndexOf('@');
            return address.Substring(indiceArroba + 1, address.Length - indiceArroba - 1);
        }


        char firstDigit(string inputString)
        {
            char ans = ' ';
            foreach (char ch in inputString)
            {
                if (char.IsDigit(ch))
                {
                    ans = ch;
                    break;
                }
            }
            return ans;
        }

        static int growingPlant(int upSpeed, int downSpeed, int desiredHeight)
        {
            int c = upSpeed;
            int indDia = 1;

            while (c < desiredHeight)
            {
                c += upSpeed - downSpeed;
                indDia++;
            }
            return indDia;
        }


        static bool isBeautifulString(string inputString)
        {
            Dictionary<char, int> diccio = new Dictionary<char, int>();
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                diccio[ch] = 0;
            }

            foreach (char ch in inputString)
            {
                diccio[ch]++;
            }

            for (char ch = 'a'; ch < 'z'; ch++)
            {
                char sig = ch;
                sig++;
                if (diccio[sig] > diccio[ch]) return false;
            }

            return true;
        }


        bool isDigit(char symbol)
        {
            return char.IsDigit(symbol);
        }

        static bool isIPv4Address(string inputString)
        {
            string[] s = inputString.Split('.');

            if (s.Length != 4) return false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length == 0) return false;
                //true if it doesn't contain letters
                for (int j = 0; j < s[i].Length; j++)
                {
                    if (char.IsLetter(s[i][j])) return false;
                }


                int num = int.Parse(s[i].ToString());
                if (num < 0 || num > 255) return false;
            }
            return true;
        }



        static bool isLucky(int n)
        {
            string s = n.ToString();

            string a = s.Substring(0, s.Length / 2);
            string b = s.Substring(s.Length / 2, s.Length / 2);

            return a.Sum(e => e - '0') == b.Sum(e => e - '0');

        }



        static bool isMAC48Address(string inputString)
        {
            string[] s = inputString.Split('-');

            if (s.Length != 6) return false;

            foreach (string elem in s)
            {
                if (elem.Length != 2) return false;


                if ((char.IsNumber(elem[0]) && (elem[0] < '0' || elem[0] > '9'))
                    || (char.IsLetter(elem[0]) && (elem[0] < 'A' || elem[0] > 'F')))
                {
                    return false;
                }
                if ((char.IsNumber(elem[1]) && (elem[1] < '0' || elem[1] > '9'))
                    || (char.IsLetter(elem[1]) && (elem[1] < 'A' || elem[1] > 'F')))
                {
                    return false;
                }
            }
            return true;

        }


        static bool isSkewSymmetricMatrix(int[][] matrix)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != -matrix[j][i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        int knapsackLight(int value1, int weight1,
                   int value2, int weight2, int maxW)
        {

            if (weight1 + weight2 <= maxW)
            {
                return value1 + value2;
            }
            if (Math.Min(weight1, weight2) > maxW)
            {
                return 0;
            }
            if (weight1 <= maxW && (value1 >= value2 || weight2 > maxW))
            {
                return value1;
            }
            return value2;
        }

        static string lineEncoding(string s)
        {
            int i = 0;
            string res = "";

            while (i < s.Length)
            {
                char a = s[i];
                int cont = 0;
                while (i < s.Length && a == s[i])
                {
                    cont++;
                    i++;
                }
                if (cont > 1)
                {
                    res += cont + "";
                }
                res += a;
            }
            return res;
        }


        static string longestDigitsPrefix(string inputString)
        {
            string num = "";
            for (int i = 0; i < inputString.Length && char.IsDigit(inputString[i]); i++)
            {
                num += inputString[i];
            }
            return num;
        }


        static string longestWord(string text)
        {
            string max_text = "";
            int i = 0;
            while (i < text.Length)
            {
                string concat = "";
                while (i < text.Length && char.IsLetter(text[i]))
                {
                    concat += text[i];
                    i++;
                }
                if (concat.Length > max_text.Length)
                {
                    max_text = concat;
                }
                i++;
            }
            return max_text;
        }

        static int makeArrayConsecutive2(int[] statues)
        {
            return (statues.Max() - statues.Min()) - statues.Length + 1;
        }

        static int matrixElementsSum(int[][] matrix)
        {
            int sum = 0;
            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int fila = 0; fila < matrix.Length; fila++)
                {
                    if (matrix[fila][col] == 0) break;
                    sum += matrix[fila][col];
                }
            }
            return sum;
        }

        static string messageFromBinaryCode(string code)
        {
            string concat = "";
            for (int i = 0; i < code.Length; i += 8)
            {
                string subs = code.Substring(i, 8);
                int s = Convert.ToInt32(subs, 2);

                concat += (char)s;
            }
            return concat;

        }
        static string messageFromBinaryCode(string code)
        {
            string ans = "";
            for (int i = 0; i < code.Length; i += 8)
            {
                string subs = code.Substring(i, 8);
                int entero = Convert.ToInt32(subs, 2);
                ans += (char)entero;
            }
            return ans;
        }



        static int[][] minesweeper(bool[][] matrix)
        {
            int[][] res = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                res[i] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    res[i][j] = 0;
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int minasAdyacentes = 0;
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        if (matrix[i - 1][j - 1])
                        {
                            minasAdyacentes++;
                        }
                    }
                    if (i - 1 >= 0)
                    {
                        if (matrix[i - 1][j])
                        {
                            minasAdyacentes++;
                        }
                    }
                    if (i - 1 >= 0 && j + 1 < matrix[i].Length)
                    {
                        if (matrix[i - 1][j + 1])
                        {
                            minasAdyacentes++;
                        }
                    }

                    if (j - 1 >= 0)
                    {
                        if (matrix[i][j - 1])
                        {
                            minasAdyacentes++;
                        }
                    }
                    //if (matrix[i][j])
                    //{
                    //    minasAdyacentes++;
                    //}
                    if (j + 1 < matrix[i].Length)
                    {
                        if (matrix[i][j + 1])
                        {
                            minasAdyacentes++;
                        }
                    }
                    if (i + 1 < matrix.Length && j - 1 >= 0)
                    {
                        if (matrix[i + 1][j - 1])
                        {
                            minasAdyacentes++;
                        }
                    }
                    if (i + 1 < matrix.Length)
                    {
                        if (matrix[i + 1][j])
                        {
                            minasAdyacentes++;
                        }
                    }

                    if (i + 1 < matrix.Length && j + 1 < matrix[i].Length)
                    {
                        if (matrix[i + 1][j + 1])
                        {
                            minasAdyacentes++;
                        }
                    }

                    res[i][j] = minasAdyacentes;
                }
            }
            return res;
        }

        static bool palindromeRearranging(string inputString)
        {

            Dictionary<char, int> frec = inputString.ToCharArray().GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            int impares = 0;
            foreach (KeyValuePair<char, int> kvp in frec)
                if (kvp.Value % 2 != 0) impares++;

            return impares < 2;
        }


        static int[] arrayNiveles2(string s)
        {

            int[] niveles = new int[s.Length];

            int nivel = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    nivel++;
                    niveles[i] = nivel;
                }
                else if (s[i] == ')')
                {
                    niveles[i] = nivel;
                    nivel--;
                }
            }

            return niveles;

        }


        static int shapeArea(int n)
        {
            int sum = 1;
            for (int i = 0; i < n; i++)
            {
                sum += (i * 4);
            }
            return sum;
        }

        static int[] sortByHeight(int[] a)
        {
            List<int> copia = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != -1) copia.Add(a[i]);
            }
            copia.Sort();
            int indice = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != -1)
                {
                    a[i] = copia[indice];
                    indice++;
                }
            }
            return a;
        }


        //---------------------------------
        static int CargarFilaArriba(int num, int en_fila, int[][] m, int col_izq, int col_der)
        {
            for (int i = col_izq; i <= col_der; i++)
            {
                m[en_fila][i] = num++;
            }
            return num;
        }

        static int CargarFilaAbajo(int num, int en_fila, int[][] m, int col_izq, int col_der)
        {
            for (int i = col_der; i >= col_izq; i--)
            {
                m[en_fila][i] = num++;
            }
            return num;
        }

        static int CargarColDer(int num, int en_col, int[][] m, int fila_arriba, int fila_abajo)
        {
            for (int i = fila_arriba; i <= fila_abajo; i++)
            {
                m[i][en_col] = num++;
            }

            return num;
        }

        static int CargarColIzq(int num, int en_col, int[][] m, int fila_arriba, int fila_abajo)
        {
            for (int i = fila_abajo; i >= fila_arriba; i--)
            {
                m[i][en_col] = num++;
            }
            return num;
        }



        static int[][] spiralNumbers(int n)
        {
            int i = 0;
            int j = n;
            int[][] matriz = new int[n][];

            for (i = 0; i < n; i++)
            {
                matriz[i] = new int[n];
            }

            int num = 1;

            int fila_arriba = 0, fila_abajo = n - 1;
            int col_izq = 0, col_der = n - 1;

            while (fila_arriba <= fila_abajo &&
                col_izq <= col_der)
            {
                num = CargarFilaArriba(num, fila_arriba, matriz, col_izq, col_der);
                fila_arriba++;
                num = CargarColDer(num, col_der, matriz, fila_arriba, fila_abajo);
                col_der--;
                num = CargarFilaAbajo(num, fila_abajo, matriz, col_izq, col_der);
                fila_abajo--;
                num = CargarColIzq(num, col_izq, matriz, fila_arriba, fila_abajo);
                col_izq++;
            }

            return matriz;
        }

        //-------------------------------------------
        public static bool nextPermutation(int[] array, string[] s)
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
            int temp = array[i - 1];
            array[i - 1] = array[j];
            array[j] = temp;

            string ts = s[i - 1];
            s[i - 1] = s[j];
            s[j] = ts;

            // Reverse suffix
            j = array.Length - 1;


            while (i < j)
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;

                ts = s[i];
                s[i] = s[j];
                s[j] = ts;

                i++;
                j--;
            }
            return true;
        }


        static bool difiereEn1(string s1, string s2)
        {

            int n = s1.Length;

            int count = 0; // Count of edits

            int i = 0, j = 0;
            while (i < n && j < n)
            {
                // If current characters don't match
                if (s1[i] != s2[j])
                {
                    if (count == 1)
                        return false;


                    i++;
                    j++;

                    count++;
                }

                else // If current characters match
                {
                    i++;
                    j++;
                }
            }

            // If last character is extra in any string
            if (i < n || j < n)
                count++;

            return count == 1;
        }

        static bool stringsRearrangement(string[] inputArray)
        {
            int[] indices = new int[inputArray.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = i;
            }

            do
            {
                int i = 0;
                for (i = 0; i + 1 < inputArray.Length; i++)
                {
                    // Console.Write(inputArray[i] + " ");
                    if (!difiereEn1(inputArray[i], inputArray[i + 1]))
                    {
                        break;
                    }
                }
                if (i == inputArray.Length - 1) return true;
                // Console.WriteLine();
            } while (nextPermutation(indices, inputArray));

            return false;
        }

        //----------------------------------------------

        //public bool IsValidSudoku(char[,] board)
        static bool sudoku(int[][] grid)
        {

            //fila por fila
            for (int i = 0; i < grid.Length; i++)
            {
                HashSet<int> hashFila = new HashSet<int>();
                for (int j = 0; j < grid[i].Length; j++)
                {

                    if (hashFila.Contains(grid[i][j]))
                    {
                        return false;
                    }
                    hashFila.Add(grid[i][j]);

                }
            }

            //col por col
            for (int j = 0; j < grid[0].Length; j++)
            {
                HashSet<int> hashCol = new HashSet<int>();
                for (int i = 0; i < grid.Length; i++)
                {


                    if (hashCol.Contains(grid[i][j]))
                    {
                        return false;
                    }
                    hashCol.Add(grid[i][j]);


                }
            }

            //grupo por grupo

            for (int fila = 0; fila < grid.Length; fila += 3)
            {
                for (int col = 0; col < grid[fila].Length; col += 3)
                {
                    HashSet<int> hashGrupo = new HashSet<int>();
                    for (int i = fila; i < fila + 3; i++)
                    {
                        for (int j = col; j < col + 3; j++)
                        {
                            if (hashGrupo.Contains(grid[i][j]))
                            {
                                return false;
                            }
                            hashGrupo.Add(grid[i][j]);
                        }
                    }
                }
            }

            return true;
        }


        static int sumUpNumbers(string inputString)
        {
            int i = 0;

            int sum = 0;

            while (i < inputString.Length)
            {
                string num = "";
                while (i < inputString.Length && char.IsNumber(inputString[i]))
                {
                    num += inputString[i];
                    i++;
                }
                if (num.Length > 0)
                    sum += int.Parse(num);

                i++;
            }
            return sum;
        }


        static bool validTime(string time)
        {
            string[] s = time.Split(':');
            int horas = int.Parse(s[0].ToString());
            int minutos = int.Parse(s[1].ToString());

            if (horas < 0 || horas > 23) return false;
            if (minutos < 0 || minutos > 59) return false;

            return true;
        }


        bool variableName(string name)
        {
            if (char.IsNumber(name[0])) return false;

            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i]) && name[i] != '_')
                {
                    return false;
                }
            }
            return true;
        }





        static void Main(string[] args)
        {

        }
    }
}
