// exitcode.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	PROCESS_INFORMATION pi = { 0 };
	STARTUPINFO si = { 0 };
	si.cb = sizeof(si);

	TCHAR args[] = _T("Sample.exe"); 

	BOOL b = CreateProcess(0, args,	0, 0, FALSE, 
				CREATE_NEW_CONSOLE, 0, 0, &si, &pi);
	if (b)
	{
//		CloseHandle(pi.hProcess);
		CloseHandle(pi.hThread);
	}

	// pi.hProcess�� �ڽ� ���μ����� ���� ����
	while (1)
	{
		int cmd;
		scanf_s("%d", &cmd);

		if (cmd == 2)
		{
			TerminateProcess(pi.hProcess, 300);

			// ��¥�� ���� �Ǿ����� ����.!
			// �ڵ��� �ñ׳� �Ǿ����� ����
			WaitForSingleObject(pi.hProcess,
									INFINITE);

			// 
			cmd = 1;
		}





		if (cmd == 1)
		{
			DWORD code;
			GetExitCodeProcess(pi.hProcess, &code);

			if (code == STILL_ACTIVE)
				_tprintf(_T("child alive\n"));
			else
				_tprintf(_T("exit code : %d\n"),code);

		}
	}

}

