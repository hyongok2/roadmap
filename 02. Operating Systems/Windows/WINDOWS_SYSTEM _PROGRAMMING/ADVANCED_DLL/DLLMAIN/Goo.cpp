#include <Windows.h>
#include <stdio.h>

HMODULE hDll = 0;

DWORD __stdcall goo(void* p)
{
	printf("start work\n");

	printf("finish work\n");
	FreeLibrary(hDll);
	ExitThread(0);
	return 0;
}
BOOL __stdcall DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH:
		{
			hDll = hinstDLL;
			HANDLE hThread = CreateThread(0, 0, goo, 0, 0, 0);
			CloseHandle(hThread);
		}
		break;
	}
	return TRUE;
}