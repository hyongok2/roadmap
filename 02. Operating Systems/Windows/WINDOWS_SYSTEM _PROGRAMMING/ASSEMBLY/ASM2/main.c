// main.c
#include <stdio.h>

int asm_main();

//void foo();

int main()
{
	//foo();

	int n = asm_main(); // call _asm_main	

	printf("result : %d\n", n);
}

