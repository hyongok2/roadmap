// main2.c
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

typedef int (*F)(int, int);  // __cdecl �Լ� ����� ������

typedef int (__stdcall *F1)(int, int);

int main()
{
	getchar();

	HMODULE hDll = LoadLibrary(_T("MyDynamic.dll"));
	printf("DLL �ּ� : %p\n", hDll);


	F1 f = (F1)GetProcAddress(hDll, "_sub@8");   // __stdcall : _sub@8

	printf("sub �Լ� �ּ� : %p\n", f);

	int ret = f(1, 2);

	printf("result : %d\n", ret);

	FreeLibrary(hDll);
}









