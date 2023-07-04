// api1.cpp
#include <stdio.h>
#include <Windows.h>

int main()
{
	printf("Hello, C\n");

	// api 함수 사용가능.
	MessageBoxA(0, "Hello", "API", MB_OK);
}
