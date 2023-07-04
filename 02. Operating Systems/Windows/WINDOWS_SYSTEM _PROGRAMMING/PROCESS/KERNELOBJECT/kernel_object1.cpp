// kernel_object1.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	HANDLE hFile = CreateFile(_T("a.txt"), 
		GENERIC_READ | GENERIC_WRITE,
		FILE_SHARE_READ | FILE_SHARE_WRITE, 0, 
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

	_tprintf(_T("FILE HANDLE : %x\n"), hFile);

	char data[] = "hello";

	WriteFile(hFile, data, 256, &len, 0);

	CloseHandle(hFile);
}
