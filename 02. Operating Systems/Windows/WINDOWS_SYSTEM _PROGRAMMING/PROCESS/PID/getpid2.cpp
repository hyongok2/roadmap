// getpid2.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain()
{
	DWORD pid = 0;
	DWORD tid = 0;

	// 1. 윈도우 핸들 구하기.
	HWND hwnd = FindWindow(0, _T("계산기"));


	// 2. HWND => PID, TID 를 구하기
	tid = GetWindowThreadProcessId(hwnd, &pid);


	_tprintf(_T("PID : %d, TID : %d\n"), pid, tid);
}
