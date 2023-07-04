// getpid1.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain()
{
	DWORD pid = GetCurrentProcessId();
	DWORD tid = GetCurrentThreadId();

	_tprintf(_T("PID : %d, TID : %d\n"), pid, tid);
}

