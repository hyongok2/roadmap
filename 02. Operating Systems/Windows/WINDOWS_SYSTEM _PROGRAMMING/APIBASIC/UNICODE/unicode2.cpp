// unicode2.cpp
#include <stdio.h>
#include <string.h>
#include <Windows.h>

int main()
{
	char s1[]    =  "abcd�����ٶ�"; // DBCS

	wchar_t s2[] = L"abcd�����ٶ�";


	printf("%d\n", sizeof(s2));			// 18     
	printf("%d\n", strlen((char*)s2));	// 1
	printf("%d\n", wcslen(s2));	// 8

	printf("AA\n");
	wprintf(L"AA\n");

	MessageBoxA(0, "A", "B", MB_OK);
	MessageBoxW(0, L"A", L"B", MB_OK);
}
