#include <stdio.h>
#include <Windows.h>

int main()
{
	HANDLE heap1 = GetProcessHeap();
	HANDLE heap2 = HeapCreate(0, 4096, 0);

	//int cnt = GetProcessHeaps(0, 0);

	HANDLE handle[256];
	int cnt = GetProcessHeaps(256, handle);

	printf("default : %x\n", heap1);
	printf("heap2   : %x\n", heap2);

	for (int i = 0; i < cnt; i++)
	{
		printf("%d : %x\n", i, handle[i]);
	}


	HeapDestroy(heap2);
}