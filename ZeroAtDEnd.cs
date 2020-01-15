https://codefights.com/challenge/fRHHjzTpn2eN46cN3?utm_source=featuredChallenge&utm_medium=email&utm_campaign=email_notification
http://www.geeksforgeeks.org/count-trailing-zeroes-factorial-number/


        static int ZeroAtDEnd(int num)
        {
            // Initialize result
            int count = 0;

            // Keep dividing n by powers of 5 and update count
            for (int i = 5; num / i >= 1; i *= 5)
                count += num / i;

            return count;

        }
