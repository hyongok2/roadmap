/*
// main.c
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

//#include "mydynamic.h"
//#pragma comment(lib, "mydynamic.lib")

typedef int (*F)(int, int);

int main()
{
	getchar();

	// 1. DLL Load
	HMODULE hDll = LoadLibrary(_T("MyDynamic.dll"));

	printf("DLL �ּ� : %p\n", hDll);

	// 2. DLL �ȿ��� �Լ� ã��
	F f = (F)GetProcAddress(hDll, "add");

	printf("add �Լ� �ּ� : %p\n", f);

	int ret = f(1, 2);

	printf("result : %d\n", ret);

	FreeLibrary(hDll);
}
*/








