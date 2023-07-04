#include <Windows.h>
#include <stdio.h>

//char* pBuffer = 0;

__declspec(thread) char* pBuffer = 0; // 정적 TLS

extern "C" __declspec(dllexport) void SetData(const char* s)
{
	printf("TID : %d, addr Buffer : %p\n", GetCurrentThreadId(), pBuffer);
	strcpy(pBuffer, s);
}

extern "C" __declspec(dllexport) void GetData(char* s)
{
	strcpy(s, pBuffer);
}

BOOL __stdcall DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH:
		pBuffer = (char*)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, 256);
		//DisableThreadLibraryCalls(hinstDLL);
		break;

	case DLL_PROCESS_DETACH:
		HeapFree(GetProcessHeap(), 0, pBuffer);
		break;

	case DLL_THREAD_ATTACH:
		pBuffer = (char*)HeapAlloc(GetProcessHeap(), HEAP_ZERO_MEMORY, 256);
		break;

	case DLL_THREAD_DETACH:
		HeapFree(GetProcessHeap(), 0, pBuffer);
		break;

	}
	return TRUE;
}