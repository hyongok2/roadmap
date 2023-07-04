// "콘솔 응용프로그램"
// sendmessage1.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain()
{
	//HWND hwnd = FindWindow(0, _T("Hello"));
	HWND hwnd = FindWindow(0, _T("계산기"));

	getchar();

	// 100, 200 => 100 | (200 << 16)
	//PostMessage(hwnd, WM_LBUTTONDOWN, 0, 100 | (200 << 16) );
	//SendMessage(hwnd, WM_LBUTTONDOWN, 0, 100 | (200 << 16));

	//DestroyWindow(hwnd); // 실패 

	SendMessage(hwnd, WM_CLOSE, 0, 0);

	printf("계속실행...\n");
}
