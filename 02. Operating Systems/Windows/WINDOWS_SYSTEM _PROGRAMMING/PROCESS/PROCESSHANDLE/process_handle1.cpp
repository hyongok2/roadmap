// process_handle1.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain()
{
	HWND hwnd = FindWindow(0, _T("계산기"));

	DWORD pid;
	DWORD tid = GetWindowThreadProcessId(hwnd, &pid);

	_tprintf(_T("PID : %d, TID : %d\n"), pid, tid);

	// 프로세스 핸들 얻기

	getchar();

	HANDLE hProcess = OpenProcess( PROCESS_ALL_ACCESS, 
								   0,
								   pid);


	_tprintf(_T("HANDLE : %x\n"), hProcess);

	getchar();

	TerminateProcess(hProcess, 0);	

	CloseHandle(hProcess);
}

