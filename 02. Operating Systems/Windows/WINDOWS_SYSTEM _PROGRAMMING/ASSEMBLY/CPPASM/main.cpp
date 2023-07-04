// main.cpp
#include <stdio.h>

//extern "C" int asm_main();

int asm_main();

int main()
{
	int n = asm_main(); // call _asm_main
						// call ?asm_main@@YAHXZ

	printf("result : %d\n", n);
}

