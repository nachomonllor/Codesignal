https://codefights.com/challenge/FFQNC5ET3xLuSj5Jj
static int[] bearTrap(int L, int D, int X)
        {
            int min = 0, max = 0;
            for (int i = L; i <= D; i++)
            {
                int sumDig = 0;
                int n = i;
                while (n > 0)
                {
                    sumDig += n % 10;
                    n /= 10;
                }

                if (sumDig == X)
                {
                    min = i;
                    break;
                }
            }

            for (int i = D; i >= L; i--)
            {
                int sumDig = 0;
                int n = i;
                while (n > 0)
                {
                    sumDig += n % 10;
                    n /= 10;
                }

                if (sumDig == X)
                {
                     max = i;
                    break;
                }

            }
            return new int[] { min, max};

        }
