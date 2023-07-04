#include <stdio.h>
#include <Windows.h>

int main()
{
	const char* s = "aaa";

	//printf("s");

	MessageBoxA(0, s, s, 0);

	__asm
	{
		push    s
		call    printf    // _printf
		add     esp, 4

		push    0
		push    s
		push    s
		push    0
		call    MessageBoxA  // _MessageBoxA@16
		//add    esp, 16
 	}

}
