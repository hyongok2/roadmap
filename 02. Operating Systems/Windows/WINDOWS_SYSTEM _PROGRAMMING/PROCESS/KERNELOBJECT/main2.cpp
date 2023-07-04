// main2.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	HANDLE hFile = CreateFile(_T("a.txt"), GENERIC_READ | GENERIC_WRITE,
		FILE_SHARE_READ | FILE_SHARE_WRITE, 0, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

	_tprintf(_T("FILE HANDLE : %x\n"), hFile);


	HWND hwnd = FindWindow(0, _T("Friend"));

	// SendMessage(hwnd, WM_APP + 100, 0, (LPARAM)hFile); // ����..




	// FILE�� �ڵ��� �ٸ� ���μ����� �����ϴ� �ڵ�
	// 1. ���μ��� ID ���ϱ�
	DWORD pid;
	DWORD tid = GetWindowThreadProcessId(hwnd, &pid);


	// 2. ���μ��� ID�� ������ �ڵ� ���
	HANDLE hProcess = OpenProcess(PROCESS_DUP_HANDLE, 0, pid);

	 

	// 3. DuplicateHandle() �Լ��� �ڵ� ����
	HANDLE handle;
	DuplicateHandle( GetCurrentProcess(), hFile, 
					 hProcess, &handle,
					 DUPLICATE_SAME_ACCESS, 0, 0);




	_tprintf(_T("handle : %x\n"), handle);


	SendMessage(hwnd, WM_APP + 100, 0, (LPARAM)handle);


	CloseHandle(hFile);
	CloseHandle(hProcess);
}