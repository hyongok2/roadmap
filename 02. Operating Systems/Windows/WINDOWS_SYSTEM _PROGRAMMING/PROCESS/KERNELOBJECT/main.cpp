// main.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	HANDLE hFile = CreateFile(_T("a.txt"),  GENERIC_READ | GENERIC_WRITE,
		FILE_SHARE_READ | FILE_SHARE_WRITE, 0, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

	_tprintf(_T("FILE HANDLE : %x\n"), hFile);


	// 다른 프로세스에 파일 핸들 전달
	HWND hwnd = FindWindow(0, _T("Friend"));

	SendMessage(hwnd, WM_APP + 100, 0, (LPARAM)hFile); // 실패..
}