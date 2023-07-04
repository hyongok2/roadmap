// target.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	DWORD pid = GetCurrentProcessId();

	char passwd[256] = { 0 };

	printf("PID : %d, buffer addr : %p\n", pid, passwd);

	while (1)
	{
		gets_s(passwd);
	}
}