#include <Windows.h>
#include <stdio.h>

BOOL __stdcall DllMain(HINSTANCE hinstDLL, 
					   DWORD fdwReason, 
					   LPVOID lpvReserved)
{
	switch (fdwReason)
	{
	case DLL_PROCESS_ATTACH: 
		//DisableThreadLibraryCalls(hinstDLL);
		printf("DLL_PROCESS_ATTACH : %d\n", GetCurrentThreadId()); 
		printf("DLL Address : %p\n", hinstDLL);
		printf("%s Linking \n", lpvReserved ? "Implicit" : "Explicit");
		break;

	case DLL_PROCESS_DETACH: printf("DLL_PROCESS_DETACH: %d\n", GetCurrentThreadId()); break;
	case DLL_THREAD_ATTACH:  printf("DLL_THREAD_ATTACH : %d\n", GetCurrentThreadId()); break;
	case DLL_THREAD_DETACH:  printf("DLL_THREAD_DETACH : %d\n", GetCurrentThreadId()); break;
	}
	return TRUE;
}