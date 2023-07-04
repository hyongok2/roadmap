// main.c
#include <stdio.h>

int asm_main();

int main()
{
	int ret = asm_main(); 
			// push	main 으로 돌아올 주소
			// call	_asm_main
			
			
	printf("result : %d\n", ret);
}