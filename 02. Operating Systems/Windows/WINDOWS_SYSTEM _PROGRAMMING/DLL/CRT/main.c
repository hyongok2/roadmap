// main.c
#include <stdio.h>
#include <Windows.h>

//#pragma comment(lib, "user32.lib")

int main()
{
	MessageBoxA(0, "A", "B", MB_OK);

	printf("hello\n"); // C 표준 함수, CRT 함수
}

void* Alloc(int size)
{
	return malloc(size);
}

int main()
{
	void* p = Alloc(100);
	free(p);
}