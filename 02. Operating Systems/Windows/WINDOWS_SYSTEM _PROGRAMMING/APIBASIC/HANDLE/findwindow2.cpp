// findwindow2.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int main()
{
	HWND hwnd = FindWindow(0, _T("���� ���� - �޸���"));

	printf("%d\n", hwnd);

	getchar(); 
	
	DestroyWindow(hwnd);
}

