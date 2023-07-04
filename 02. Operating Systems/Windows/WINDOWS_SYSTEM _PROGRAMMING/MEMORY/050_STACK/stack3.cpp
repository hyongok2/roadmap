#include <stdio.h>
#include <Windows.h>

DWORD Filter(int cnt, int code);

// 1M : 256개(0~255)의 PAGE
#define LAST_GUARD_PAGE 253
#define PAGE_SIZE		4096

int   guard_page = 1;
char* stack_addr = 0;


int main()
{
	// 1M 예약
	stack_addr = (char*)VirtualAlloc(0, 1024 * 1024, MEM_RESERVE, PAGE_READWRITE);


	VirtualAlloc(stack_addr, PAGE_SIZE, MEM_COMMIT, PAGE_READWRITE);

	VirtualAlloc(stack_addr + guard_page * PAGE_SIZE, PAGE_SIZE, MEM_COMMIT, 
									PAGE_READWRITE | PAGE_GUARD);

	int i = 0;

	__try
	{
		for (i = 0; i < 1024*1024; i++)
		{
			stack_addr[i] = 'A';
		}
	}
	__except ( Filter(i, GetExceptionCode()) )
	{
		printf("STACK OVERFLOW : %x\n", GetExceptionCode());
	}
}





DWORD Filter(int cnt, int code)
{
	if (code == EXCEPTION_GUARD_PAGE )
	{
		if (guard_page < LAST_GUARD_PAGE)
		{
			++guard_page;
			VirtualAlloc(stack_addr + guard_page * PAGE_SIZE, PAGE_SIZE,
				MEM_COMMIT, PAGE_READWRITE | PAGE_GUARD);

			printf("%d : GUARD MOVE NEXT %d PAGE\n", cnt, guard_page);
			return -1;
		}
		else if (guard_page == LAST_GUARD_PAGE)
		{
			++guard_page;
			VirtualAlloc(stack_addr + guard_page * PAGE_SIZE, PAGE_SIZE,
				MEM_COMMIT, PAGE_READWRITE );

			printf("%d : LAST PAGE %d CMMIT\n", cnt, guard_page);
			return -1;
		}

	}
	return 1;
}