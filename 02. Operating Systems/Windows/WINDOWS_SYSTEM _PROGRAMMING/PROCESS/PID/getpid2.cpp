// getpid2.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain()
{
	DWORD pid = 0;
	DWORD tid = 0;

	// 1. ������ �ڵ� ���ϱ�.
	HWND hwnd = FindWindow(0, _T("����"));


	// 2. HWND => PID, TID �� ���ϱ�
	tid = GetWindowThreadProcessId(hwnd, &pid);


	_tprintf(_T("PID : %d, TID : %d\n"), pid, tid);
}
