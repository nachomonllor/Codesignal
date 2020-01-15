https://codefights.com/arcade/code-arcade/loop-tunnel/scG8AFsPuqQGx8Qjf
int appleBoxes(int k)
        {
            int yellow = 0, red = 0;

            for (int i = 1; i <= k; i++)
            {
                if (i % 2 != 0)
                {
                    yellow += (i * i);
                }
                else
                {
                    red += (i * i);
                }
            }

            return red - yellow;
        }
