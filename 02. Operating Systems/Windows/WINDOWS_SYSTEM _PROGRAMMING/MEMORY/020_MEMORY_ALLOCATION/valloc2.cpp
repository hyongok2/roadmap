#define _CRT_SECURE_NO_WARNINGS
#include <Windows.h>
#include <stdio.h>

typedef struct _CELL
{
	char data[4091];	// 4k - 5
} CELL;

int main()
{
	CELL* pCell = (CELL*)VirtualAlloc(0, sizeof(CELL) * 10, MEM_RESERVE, PAGE_READWRITE);

	printf("Reserved Addr : %p\n", pCell);

	int idx = 0;
	char s[4091];

	while (1)
	{
		printf("index >> "); scanf("%d", &idx);
		printf("data  >> "); scanf("%s", s);
		__try
		{
			strcpy(pCell[idx].data, s); // exception
		}
		__except (1)
		{
			VirtualAlloc(&pCell[idx], sizeof(CELL), MEM_COMMIT, PAGE_READWRITE);
			printf("%d CELL Commit \n", idx);
			strcpy(pCell[idx].data, s);
		}
	}
}