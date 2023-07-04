// error.cpp
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <Windows.h>

int main()
{
	FILE* f = fopen("a.txt", "rt");

	if (f == 0)
		printf("실패 : %d\n", errno);

	HWND hwnd = CreateWindow(0, 0, 0, 0, 0, 
						     0, 0, 0, 0, 0, 0);
	if ( hwnd ==  0)
		printf("실패 : %d, %d\n", errno,
							GetLastError() );

}