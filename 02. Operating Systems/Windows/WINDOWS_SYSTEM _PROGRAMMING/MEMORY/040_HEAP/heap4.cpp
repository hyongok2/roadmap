#include <stdio.h>
#include <Windows.h>

int main()
{
	HANDLE heap1 = GetProcessHeap();

	HANDLE heap2 = HeapCreate(HEAP_NO_SERIALIZE,
		4096, // 확정할 크기(Commit)
		0);   // 최대 크기 

	void* p1 = HeapAlloc(heap1, HEAP_ZERO_MEMORY, 100);
	void* p2 = HeapAlloc(heap2, HEAP_ZERO_MEMORY, 100);

	printf("%p\n", p1);
	printf("%p\n", p2);

	HeapFree(heap1, 0, p1);
	HeapFree(heap2, 0, p2);	

	HeapDestroy(heap2);
}