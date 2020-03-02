https://codefights.com/challenge/kA3KCeg6aPYpDLaiQ
#include <iostream>
#include <stdio.h>
#include <vector>
 
using namespace std;
 
int NumberGameIII(std::vector<int> S) {
   
    for(int i = 0; i < S.size(); i++)
    {  
        bool divisorDeTodos = true;
        for(int j = 0; j < S.size(); j++){
            if(S[j] % S[i] != 0){
                divisorDeTodos = false;
                break;
            }
        }
       
        if(divisorDeTodos){
            return S[i];
        }
       
    }
    return -1;
   
}
 
int main(){
    //NumberGameIII([3,6,3,15,9])
    return 0;
}
