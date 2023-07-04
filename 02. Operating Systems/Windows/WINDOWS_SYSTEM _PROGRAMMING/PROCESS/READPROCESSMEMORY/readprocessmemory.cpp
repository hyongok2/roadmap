// readprocessmemory.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain()
{
	char buff[256] = { 0 };

	DWORD pid = 22060;
	char* addr = (char*)0x010FFA74;
	
	// PID => PROCESS HANDLE
	HANDLE hProcess = OpenProcess(PROCESS_VM_READ,
								0, pid);

	while (1)
	{
		getchar();
		DWORD len;
		ReadProcessMemory(hProcess, addr, 
							buff, 256, &len);
		printf("읽어온 메모리 : %s\n", buff);

	}


}

