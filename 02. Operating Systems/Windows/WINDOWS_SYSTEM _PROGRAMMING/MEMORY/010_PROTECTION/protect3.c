#include <stdio.h>
#include <Windows.h>

int main()
{
	char s1[] = "hello";
	char* s2 = "hello";

	*s1 = 'A'; // ok
	
	DWORD old = 0;
	VirtualProtect(s2, strlen(s2)+1, PAGE_READWRITE,
									&old);

	printf("old protection : %d\n", old);

	__try
	{
		*s2 = 'A'; // runtime error
	}
	__except (1)
	{
		printf("%x\n", GetExceptionCode());
	}
}