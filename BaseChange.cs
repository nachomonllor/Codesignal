https://codefights.com/challenge/JFjNEbXLYL4W7FG3i
int BaseChange(int num, int base) {
   std::string result= "";
   while(num){
      result += char(num %base + '0');
      num /=base;    
    }
    std::reverse(result.begin(), result.end());
    

    int res = atoi( result.c_str() );
    return res;
}
