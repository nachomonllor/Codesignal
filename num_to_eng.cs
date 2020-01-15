https://codefights.com/challenge/G49XMQom3c4rQevr6

static  string num_to_eng(int n)
        {
            string answer = "";

            if (n >= 20)
            {
                int dec = (n / 10) % 10;
                int uni = n % 10;

                string[] unidades = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                string[] decenas = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                //Console.WriteLine(decena + " " + unidad);
                if (uni == 0)
                {
                    answer = decenas[dec];
                }
                else
                {
                    answer = decenas[dec] + "-" + unidades[uni];
                }
            }
            else
            {
                string[] letras = 
                { "zero", "one", "two", "three","four","five","six", "seven", "eight", "nine", 
                    "ten" ,"eleven" , "twelve", "thirteen","fourteen" ,"fifteen","sixteen", "seventeen", "eighteen", "nineteen"};
                answer = letras[n];
            }

            return answer;
        }
