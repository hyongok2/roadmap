#include <stdio.h>
#include <windows.h>

int main()
{
	HANDLE heap = GetProcessHeap();

	int* p1 = (int*)HeapAlloc(heap,
						HEAP_ZERO_MEMORY,
						sizeof(int) * 10);
	printf("%p\n", p1);

	p1[0] = 10;
	p1[2] = 20;

	HeapFree(heap, 0, p1);

}