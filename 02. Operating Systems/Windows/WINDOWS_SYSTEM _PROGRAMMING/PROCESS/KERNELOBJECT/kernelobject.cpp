// kernelobject.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	getchar();
	HANDLE h1 = CreateFile(_T("a.txt"),
					GENERIC_READ | GENERIC_WRITE,
					FILE_SHARE_READ | FILE_SHARE_WRITE, 
					0, CREATE_ALWAYS, 
					FILE_ATTRIBUTE_NORMAL, 0);

	getchar();	
	HANDLE h2 = CreateEvent(0, 0, 0, _T("MyEvent")); 

	getchar();
	HANDLE h3 = CreateMutex(0, 0, _T("MyMutex"));

	getchar();	CloseHandle(h3);
	getchar();	CloseHandle(h2);
	getchar();	CloseHandle(h3);
}