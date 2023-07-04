#include <stdio.h>
#include <windows.h>

int main()
{
	void* p = VirtualAlloc(0,	// 메모리 주소
				100,			// 크기(4096)
				MEM_RESERVE | MEM_COMMIT,
				PAGE_READWRITE);

	// ......
	VirtualFree(p, 0, MEM_RELEASE);
}