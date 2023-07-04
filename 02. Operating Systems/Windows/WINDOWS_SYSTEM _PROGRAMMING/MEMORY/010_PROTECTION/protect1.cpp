#include <Windows.h>
#include <stdio.h>

int main()
{
	int y = 0; // 지역변수, Stack 
		

	MEMORY_BASIC_INFORMATION mbi = { 0 };

	VirtualQuery(&y, &mbi, sizeof(mbi));

	printf("%p : %d\n", &y, mbi.Protect);

	int n = PAGE_READWRITE;
}