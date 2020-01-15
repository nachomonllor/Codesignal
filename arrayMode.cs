https://app.codesignal.com/challenge/J6DuW9RqENKaJjkGS
   static int arrayMode(int[] sequence)
        {
            Dictionary<int, int> dic =
                new Dictionary<int, int>();

            int max_key = -1, max_val = -1;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (dic.ContainsKey(sequence[i]))
                {
                    dic[sequence[i]]++;
                }
                else
                {
                    dic[sequence[i]] = 1;
                }
                if (dic[sequence[i]] > max_val)
                {
                    max_val = dic[sequence[i]];
                    max_key = sequence[i];
                }
            }

            return max_key;


        }
