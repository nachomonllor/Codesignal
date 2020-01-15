https://codefights.com/arcade/code-arcade/loop-tunnel/xzeZqCQjpfDJuN72S
  static int additionWithoutCarrying(int param1, int param2)
        {
            string p1 = param1.ToString();
            string p2 = param2.ToString();

            if (p1.Length > p2.Length)
            {
                string ceros = new string('0', p1.Length - p2.Length);
                p2 = ceros + p2;
            }
            else if (p1.Length < p2.Length)
            {
                string ceros = new string('0', p2.Length - p1.Length);
                p1 = ceros + p1;
            }

            string concat = "";
            for (int i = 0; i < p1.Length; i++)
            {
                concat += ((int.Parse(p1[i].ToString()) + int.Parse(p2[i].ToString()))%10);
            }

            return int.Parse(concat);

        }
