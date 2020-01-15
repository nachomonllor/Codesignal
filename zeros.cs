https://codefights.com/challenge/4ZTivuTy4hJ2Ef3b4/main
static int zeros(int n)
        {
            int ans = 0;
            while (n > 0)
            {
                if (n % 2 == 0)
                {
                    ans++;
                }
                n /= 2;
            }
            return ans;
        }
