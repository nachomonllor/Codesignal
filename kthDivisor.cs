 static int kthDivisor(int n, int k)
        {
            //if (n > k) return -1;
            List<int> divisores = new List<int>();
            for (int i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {

                    // If divisors are equal, 
                    // print only one 
                    if (n / i == i)
                    {
                        //Console.Write(i + " ");
                        divisores.Add(i);
                    }

                    // Otherwise print both 
                    else
                    {
                       //  Console.Write(i + " "
                        //        + n / i + " ");
                        divisores.Add(i);
                        divisores.Add(n / i);
                    }
                }
            }

            if (k > divisores.Count) return -1;

            divisores.Sort();

            return divisores[k - 1];
        }