// "�ܼ� �������α׷�"
// sendmessage1.cpp
#include <stdio.h>
#include <windows.h>
#include <tchar.h>

int _tmain()
{
	//HWND hwnd = FindWindow(0, _T("Hello"));
	HWND hwnd = FindWindow(0, _T("����"));

	getchar();

	// 100, 200 => 100 | (200 << 16)
	//PostMessage(hwnd, WM_LBUTTONDOWN, 0, 100 | (200 << 16) );
	//SendMessage(hwnd, WM_LBUTTONDOWN, 0, 100 | (200 << 16));

	//DestroyWindow(hwnd); // ���� 

	SendMessage(hwnd, WM_CLOSE, 0, 0);

	printf("��ӽ���...\n");
}
