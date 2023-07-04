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

	// SendMessage(hwnd, WM_APP + 100, 0, (LPARAM)hFile); // 실패..




	// FILE의 핸들을 다른 프로세스에 복사하는 코드
	// 1. 프로세스 ID 구하기
	DWORD pid;
	DWORD tid = GetWindowThreadProcessId(hwnd, &pid);


	// 2. 프로세스 ID를 가지고 핸들 얻기
	HANDLE hProcess = OpenProcess(PROCESS_DUP_HANDLE, 0, pid);

	 

	// 3. DuplicateHandle() 함수로 핸들 복사
	HANDLE handle;
	DuplicateHandle( GetCurrentProcess(), hFile, 
					 hProcess, &handle,
					 DUPLICATE_SAME_ACCESS, 0, 0);




	_tprintf(_T("handle : %x\n"), handle);


	SendMessage(hwnd, WM_APP + 100, 0, (LPARAM)handle);


	CloseHandle(hFile);
	CloseHandle(hProcess);
}