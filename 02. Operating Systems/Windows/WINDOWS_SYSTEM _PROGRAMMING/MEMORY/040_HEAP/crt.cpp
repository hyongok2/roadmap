#include <stdio.h>
#include <stdlib.h>
#include <Windows.h>

int main()
{
	HANDLE h1 = GetProcessHeap();

	void* p1 = HeapAlloc(h1, 0, 100);
	void* p2 = malloc(100);
	void* p3 = new char[100];

	printf("HeapAlloc : %p\n", p1);
	printf("malloc    : %p\n", p2);
	printf("new       : %p\n", p3);

	delete[] p3;
	free(p2);
	HeapFree(h1, 0, p1);
}