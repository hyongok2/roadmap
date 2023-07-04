#include <stdio.h>
#include <Windows.h>

int main()
{
	char* p1 = (char*)VirtualAlloc(	
					(void*)0, // 0x56781234, 
					1024*1024*100,
					MEM_RESERVE | MEM_TOP_DOWN, 
					PAGE_READWRITE);

	printf("Reserved Addr : %p\n", p1);


	char* p2 = (char*)VirtualAlloc(
						p1 + 4096,  
						4096,
						MEM_COMMIT,
						PAGE_READWRITE);
	printf("Commit Addr : %p\n", p2);

	__try
	{
		*(p1+4096) = 'A'; // p2
		*p1 = 'A';
	}
	__except (1)
	{
		printf("%x\n", GetExceptionCode());
	}

	VirtualFree(p2, 4096, MEM_DECOMMIT);
	VirtualFree(p1, 0, MEM_RELEASE);

}