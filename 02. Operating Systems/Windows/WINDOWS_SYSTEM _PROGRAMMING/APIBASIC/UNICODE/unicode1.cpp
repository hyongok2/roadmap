// unicode1.cpp
#include <stdio.h>
#include <string.h>

int main()
{
	char s[] = "abcd가나다라";

	printf("%d\n", sizeof(s));
	printf("%d\n", strlen(s));
}