https://codefights.com/challenge/uT2ywJR5QtJzJGqMb

int factorial(int n)
        {
            int f = 1;
            for (int i = 2; i <= n; i++)
            {
                f *= i;
            }
            return f;
        }

        int AlternatingDigitSum(int n)
        {
            if (n >= 11)
                return 0;

            string f = factorial(n).ToString();
            int sum = 0, j = 0;

            for (int i = f.Length - 1; i >= 0; i--)
            {
                if (j % 2 == 0)
                {
                    sum += int.Parse(f[i].ToString());
                }
                else
                {
                    sum -= int.Parse(f[i].ToString());
                }
                j++;
            }

            if (sum  < 0)
                return sum + 11;
            return sum;
        }
