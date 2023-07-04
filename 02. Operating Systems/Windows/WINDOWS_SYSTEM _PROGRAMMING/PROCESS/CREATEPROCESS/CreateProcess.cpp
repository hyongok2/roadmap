// CreateProcess.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

// Sample.exe AAA BBB
int main()
{
	PROCESS_INFORMATION pi = { 0 };
	STARTUPINFO si = { 0 };
	si.cb = sizeof(si);		
	
	//TCHAR name[] = _T("C:\\Windows\\Sample.exe");

	TCHAR name[] = _T("Sample.exe");
	TCHAR args[] = _T("Sample.exe B C D"); // argv[0] => A 

	BOOL b = CreateProcess(0,	   // 프로그램 이름  
						   args,   // command line args
						   0, 0, 
						   FALSE,  
						   CREATE_NEW_CONSOLE, 
						   0,   0,
						   &si, &pi);
	if (b)
	{
		CloseHandle(pi.hProcess);
		CloseHandle(pi.hThread);
	}
}
