// inline_asm1.c
#include <stdio.h>

int Add(int a, int b)
{
	int c = a + b;

//	return c;	// eax <= c

	__asm
	{
		mov   eax, c   // return c
	}
}

int main()
{
	int n = 0; 

	n = Add(1, 2); // n <= eax

	/*
	Add(1, 2);

	__asm
	{
		mov  n, eax
	}
	*/


	printf("result : %d\n", n);
}