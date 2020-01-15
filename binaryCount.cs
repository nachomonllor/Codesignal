https://codefights.com/challenge/saFm8RFXqef9qmPrk
int binaryCount(int n) {
 int sum = 0;
            while (n > 0)
            {
                sum += n % 2;
                n /= 2;
            }
            return sum;
}
