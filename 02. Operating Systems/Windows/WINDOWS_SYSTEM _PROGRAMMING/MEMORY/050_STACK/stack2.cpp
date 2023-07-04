#include <stdio.h>
#include <Windows.h>

int main()
{
	char* p = (char*)VirtualAlloc(0, 1024 * 1024, MEM_RESERVE, PAGE_READWRITE);

	VirtualAlloc(p, 4096,		 MEM_COMMIT, PAGE_READWRITE);
	VirtualAlloc(p + 4096, 4096, MEM_COMMIT, PAGE_READWRITE | PAGE_GUARD);

	p[0] = 'A';
	p[4095] = 'B';

	__try
	{
		p[4096] = 'C';
	}
	__except (1)
	{
		printf("%x\n", GetExceptionCode()); // 80000001
		int n = EXCEPTION_GUARD_PAGE;
	}

	// 2PAGE 사용가능..
	p[4096] = 'C';

	VirtualAlloc(p + 8192, 4096, MEM_COMMIT, PAGE_READWRITE | PAGE_GUARD);

}















