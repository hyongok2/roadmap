#include <stdio.h>
#include <Windows.h>
#include <conio.h>

DWORD __stdcall threadMain(void* p)
{
	printf("Start threadMain : %d\n", GetCurrentThreadId());
	Sleep(5000);
	printf("Finish threadMain : %d\n", GetCurrentThreadId());
	return 0;
}

int main()
{
	printf("PRIMARY THREAD ID : %d\n", GetCurrentThreadId());

	_getch();
	HMODULE hDll = LoadLibraryA("Sample.dll");
	printf("ADDR : %p\n", hDll);

	_getch();
	HANDLE hThread = CreateThread(0, 0, threadMain, 0, c0, 0);
	WaitForSingleObject(hThread, INFINITE);
	
	_getch();
	FreeLibrary(hDll);
}



