#include <Windows.h>
#include <stdio.h>

char* pBuffer = 0;

extern "C" __declspec(dllexport) void SetData(const char* s)
{
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
		DisableThreadLibraryCalls(hinstDLL);
		break;

	case DLL_PROCESS_DETACH: 
		HeapFree(GetProcessHeap(), 0, pBuffer);
		break;
	}
	return TRUE;
}