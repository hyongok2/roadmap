// calling_convetion1.c
#include <stdio.h>

int add(int a, int b)
{
	int c = a + b;
	return c;
}

int main()
{
	int ret = 0;

	//ret = add(1, 2);

	__asm
	{
		push    2
		push    1
		call    add
		add     esp, 8

		mov     ret, eax
	}

	printf("result : %d\n", ret);
}