#include <stdio.h>
#include <windows.h>

int n = 0;

DWORD Filter(DWORD code)
{
	//int code = GetExceptionCode();

	if (code == EXCEPTION_INT_DIVIDE_BY_ZERO) // c0000094
	{
		printf("divide by zero\n");
		n = 5;

		return EXCEPTION_CONTINUE_EXECUTION; // -1
	}
	printf("other exception\n");
	return EXCEPTION_EXECUTE_HANDLER; // 1
}
int main()
{
	__try
	{
		int s = 10 / n;

		printf("result : %d\n", s);

		char* p = 0;
		*p = 0; 
	}
	__except ( Filter( GetExceptionCode() ) )
	{
		printf("exception : %x\n", GetExceptionCode());
	}
	printf("main continue \n");
}

