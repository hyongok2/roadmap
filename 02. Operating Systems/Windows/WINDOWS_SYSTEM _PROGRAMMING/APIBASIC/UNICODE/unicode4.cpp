// unicode4.cpp
#undef UNICODE
#undef _UNICODE

#include <stdio.h>
#include <Windows.h>
#include <tchar.h>

int _tmain()
{
	TCHAR s[] = _T("ABCD가나다라");

	_tprintf(_T("%d, %d\n"), sizeof(s), _tcslen(s));
}