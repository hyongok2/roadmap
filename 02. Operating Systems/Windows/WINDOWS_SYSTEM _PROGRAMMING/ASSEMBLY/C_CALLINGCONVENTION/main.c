// main.c
#include <stdio.h>

int asm_main();

int main()
{
	asm_main();
}
void __cdecl    f1(int a, int b) { printf("f1 : %d, %d\n", a, b); }
void __stdcall  f2(int a, int b) { printf("f2 : %d, %d\n", a, b); }
void __fastcall f3(int a, int b) { printf("f3 : %d, %d\n", a, b); }

void __fastcall f4(int a, int b, int c, int d) 
{ 
	printf("f4 : %d, %d, %d, %d\n", a, b, c, d);
}
