// Sample.cpp
#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain(int argc, TCHAR* argv[])
{
	for (int i = 0; i < argc; i++)
	{
		_tprintf(_T("argv[%d] : %s\n"), i, argv[i]);
	}

	TCHAR name[256] = { 0 };
	GetCurrentDirectory(256, name);
	_tprintf(_T("current directory : %s\n"), name);

	// CreateFile("a.txt" ....) : ���μ��� ���� 
	//							  ���丮�� ���� ����

	_tprintf(_T("press enter key to quit\n"));
	getchar();

	return 100;
}