// findwindow3.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int main()
{
	HWND hwnd = FindWindow(0, _T("제목 없음 - 메모장"));

	TCHAR name[256];
	GetClassName(hwnd, name, 256);

	//printf("%s\n", name);
	_tprintf(_T("%s\n"), name);
}

