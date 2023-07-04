// sendmessage2.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

#define WM_MYMESSAGE   WM_APP + 100

int _tmain()
{
	HWND hwnd = FindWindow(0, _T("Hello"));

	getchar();

	SendMessage(hwnd, WM_MYMESSAGE, 0, 0);
}
