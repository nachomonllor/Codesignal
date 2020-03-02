#include <stdio.h>
#include <iostream>
#include <vector>

int zeros(int n) {
	int answer = 0;
	while(n > 0) {
		 
		if(n % 2 == 0) {
			answer ++;
		}
		n/=2;
	}
	return answer;
}

int main() {
	
	int n = zeros(5);
	printf("%d ", n);
	return 0;
}
