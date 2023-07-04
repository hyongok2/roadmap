#include <stdio.h>
#include <windows.h>

int main()
{
	HANDLE heap = GetProcessHeap();

	int* p1 = (int*)HeapAlloc(heap, HEAP_ZERO_MEMORY, 40);

	printf("%p\n", p1);

	int sz = HeapSize(heap, 0, p1);

	printf("%d\n", sz);

	  
	int* p2 = (int*)HeapReAlloc(heap,
	HEAP_ZERO_MEMORY | HEAP_REALLOC_IN_PLACE_ONLY, p1, 60);

	printf("%p\n", p2);

	HeapFree(heap, 0, p1);
}