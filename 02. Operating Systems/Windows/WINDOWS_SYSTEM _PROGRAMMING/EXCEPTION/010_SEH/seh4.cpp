#include <stdio.h>
#include <windows.h>

DWORD Filter(EXCEPTION_POINTERS* ep)
{	
	DWORD code = ep->ExceptionRecord->ExceptionCode;
	void* addr = ep->ExceptionRecord->ExceptionAddress;

	ep->ContextRecord->Eip;

	return EXCEPTION_EXECUTE_HANDLER;
}

int main()
{
	int n = 0;

	int a = EXCEPTION_INT_DIVIDE_BY_ZERO;

	__try
	{
		int s = 10 / n;
	}
	__except (Filter( GetExceptionInformation() ))
	{
		printf("exception : %x\n", GetExceptionCode());
	}	
}

