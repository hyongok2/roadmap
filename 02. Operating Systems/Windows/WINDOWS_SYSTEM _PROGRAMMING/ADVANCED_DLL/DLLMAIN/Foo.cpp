#include <Windows.h>
#include <stdio.h>

DWORD __stdcall foo(void* p)
{
	printf("foo\n");
	return 0;
}
BOOL __stdcall DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH:
		{
			HANDLE hThread = CreateThread(0, 0, foo, 0, 0, 0);
									// 1. DllMain 호출
									// 2. foo 호출

			WaitForSingleObject(hThread, INFINITE); // 주스레드가 새로운 스레드 종료 대기
		}
		break;
	}
	return TRUE;
}